using AutoMapper;
using Moq;
using StockApplicationApi.Exceptions;
using StockApplicationApi.Models;
using StockApplicationApi.Models.DTOs.StockDTOs;
using StockApplicationApi.Repositary.StockRepositary;
using StockApplicationApi.Services.StockServices;
using System.Linq.Expressions;

namespace StockApplicationApi.UnitTests.Services
{
    public class StockClassTests
    {
        private readonly Mock<IStock> _mockRepo;
        private readonly Mock<IMapper> _mockMapper;
        private readonly StockClass _service;

        public StockClassTests()
        {
            _mockMapper = new Mock<IMapper>();
            _mockRepo = new Mock<IStock>();
            _service = new StockClass(_mockRepo.Object, _mockMapper.Object);
        }

        // TEST 1 — company name duplicate → throws
        [Fact]
        public async Task AddStock_CompanyNameAlreadyExists_ThrowsConflictException()
        {
            // ARRANGE
            var createDTO = new StockCreateDTO
            {
                CompanyName = "Apple",
                Industry = "Tech",
                Symbol = "AAPL",

            };

            _mockRepo.SetupSequence(r => r.GetStock(It.IsAny<Expression<Func<Stock, bool>>>()))
                     .ReturnsAsync(new Stock())
                     .ReturnsAsync((Stock)null)
                     .ReturnsAsync((Stock)null);

            // ACT
            var ex = await Assert.ThrowsAsync<ConflictException>(
                () => _service.AddStock(createDTO)
            );

            // ASSERT
            Assert.Equal("This Company name already exists.", ex.Message);

        }

        // TEST 2 — industry duplicate → throws
        [Fact]
        public async Task AddStock_IndustryAlreadyExists_ThrowsConflictException()
        {

            var createDTO = new StockCreateDTO
            {
                CompanyName = "Apple",
                Industry = "Tech",
                Symbol = "AAPL",
                Purchase = 150.00m,
                LastDiv = 0.5m,
                MarketCap = 1000000000
            };

            _mockRepo.SetupSequence(r => r.GetStock(It.IsAny<Expression<Func<Stock, bool>>>()))
                     .ReturnsAsync((Stock)null)
                     .ReturnsAsync(new Stock())
                     .ReturnsAsync((Stock)null);


            var ex = await Assert.ThrowsAsync<ConflictException>(
                () => _service.AddStock(createDTO)
            );


            Assert.Equal("This Industry name already exists.", ex.Message);

        }

        // TEST 3 — symbol duplicate → throws
        [Fact]
        public async Task AddStock_SymbolAlreadyExists_ThrowsConflictException()
        {

            var createDTO = new StockCreateDTO
            {
                CompanyName = "Apple",
                Industry = "Tech",
                Symbol = "AAPL",
                Purchase = 150.00m,
                LastDiv = 0.5m,
                MarketCap = 1000000000
            };

            _mockRepo.SetupSequence(r => r.GetStock(It.IsAny<Expression<Func<Stock, bool>>>()))
                     .ReturnsAsync((Stock)null)    // company → no duplicate
                     .ReturnsAsync((Stock)null)    // industry → no duplicate
                     .ReturnsAsync(new Stock());   // symbol → duplicate found


            var ex = await Assert.ThrowsAsync<ConflictException>(
                () => _service.AddStock(createDTO)
            );


            Assert.Equal("This Symbol name already exists.", ex.Message);

        }

        // TEST 4 — valid stock → adds successfully
        [Fact]
        public async Task AddStock_ValidStock_ReturnsStockDTO()
        {
            // ARRANGE
            var createDTO = new StockCreateDTO
            {
                CompanyName = "Apple",
                Industry = "Tech",
                Symbol = "AAPL",
                Purchase = 150.00m,
                LastDiv = 0.5m,
                MarketCap = 1000000000
            };

            var stockEntity = new Stock
            {
                Id = 1,
                CompanyName = "Apple",
                Industry = "Tech",
                Symbol = "AAPL",
                Purchase = 150.00m,
                LastDiv = 0.5m,
                MarketCap = 1000000000
            };

            var stockDTO = new StockDTO
            {
                Id = 1,
                CompanyName = "Apple",
                Industry = "Tech",
                Symbol = "AAPL",
                Purchase = 150.00m,
                LastDiv = 0.5m,
                MarketCap = 1000000000,
                Comments = new List<Comment>()
            };

            // all 3 guard clauses → no duplicates → skip past them
            _mockRepo.SetupSequence(r => r.GetStock(It.IsAny<Expression<Func<Stock, bool>>>()))
                     .ReturnsAsync((Stock)null)    // company → no duplicate
                     .ReturnsAsync((Stock)null)    // industry → no duplicate
                     .ReturnsAsync((Stock)null);   // symbol → no duplicate


            _mockMapper.Setup(m => m.Map<Stock>(createDTO))
                       .Returns(stockEntity);


            _mockMapper.Setup(m => m.Map<StockDTO>(stockEntity))
                       .Returns(stockDTO);

            // fake repo: pretend DB save succeeded
            _mockRepo.Setup(r => r.AddStock(stockEntity))
                     .Returns(Task.CompletedTask);

            // ACT
            var result = await _service.AddStock(createDTO);

            // ASSERT
            Assert.NotNull(result);
            Assert.Equal("Apple", result.CompanyName);
            Assert.Equal("Tech", result.Industry);
            Assert.Equal("AAPL", result.Symbol);
            Assert.Equal(150.00m, result.Purchase);
            Assert.Equal(0.5m, result.LastDiv);
            Assert.Equal(1000000000, result.MarketCap);
            Assert.Empty(result.Comments);

            // prove DB save was called once
            _mockRepo.Verify(r => r.AddStock(stockEntity), Times.Once);

            // prove mapping DTO → entity was called once
            _mockMapper.Verify(m => m.Map<Stock>(createDTO), Times.Once);

            // prove mapping entity → DTO was called once
            _mockMapper.Verify(m => m.Map<StockDTO>(stockEntity), Times.Once);
        }


        // TEST 5 — stock not found → throws NotFoundException
        [Fact]
        public async Task DeleteStock_StockNotFound_ThrowsNotFoundException()
        {

            int stockId = 1;

           
            _mockRepo.Setup(r => r.GetStock(It.IsAny<Expression<Func<Stock, bool>>>()))
                     .ReturnsAsync((Stock)null);

          
            var ex = await Assert.ThrowsAsync<NotFoundException>(
                () => _service.DeleteStock(stockId)
            );

            Assert.Equal("Does this Stock exists?", ex.Message);

          
            _mockRepo.Verify(r => r.DeleteStock(It.IsAny<Stock>()), Times.Never);
        }

        // TEST 6 — stock found → deletes successfully
        [Fact]
        public async Task DeleteStock_StockFound_DeletesSuccessfully()
        {
            // ARRANGE
            int stockId = 1;

            var stockEntity = new Stock
            {
                Id = 1,
                CompanyName = "Apple",
                Industry = "Tech",
                Symbol = "AAPL",
                Purchase = 150.00m,
                LastDiv = 0.5m,
                MarketCap = 1000000000
            };

         
            _mockRepo.Setup(r => r.GetStock(It.IsAny<Expression<Func<Stock, bool>>>()))
                     .ReturnsAsync(stockEntity);

           
            _mockRepo.Setup(r => r.DeleteStock(stockEntity))
                     .Returns(Task.CompletedTask);

         
            await _service.DeleteStock(stockId);


            _mockRepo.Verify(r => r.GetStock(It.IsAny<Expression<Func<Stock, bool>>>()), Times.Once);

            // prove delete was actually called once
            _mockRepo.Verify(r => r.DeleteStock(stockEntity), Times.Once);
        }
        [Fact]
        public async Task UpdateStock_StockNotFound_ThrowsNotFoundException()
        {
            StockUpdateDTO stockUpdateDTO = new();
            int id = 1;


            // mock repo returns null → stock not found in DB
            _mockRepo.Setup(r => r.GetStock(It.IsAny<Expression<Func<Stock, bool>>>()))
                     .ReturnsAsync((Stock)null);

            // ACT
            var ex = await Assert.ThrowsAsync<NotFoundException>(
                () => _service.UpdateStock(id, stockUpdateDTO)
            );

            // ASSERT
            Assert.Equal("Does this Stock exists?", ex.Message);

            // prove update was never called because stock was not found
            _mockRepo.Verify(r => r.UpdateStock(It.IsAny<Stock>()), Times.Never);

        }
        [Fact]
        public async Task UpdateStock_ValidStock_FieldsAreCorrectlyMapped()
        {
            StockUpdateDTO stockUpdateDTO = new()
            {
               
                CompanyName = "Tesla Updated",
                Symbol = "TSLA",
                MarketCap = 9000,
                Purchase = 200,
                LastDiv = 3.0m,
                Industry = "Automotive"
            };
            Stock existingStock = new()
            {
                Id = 1,
                CompanyName = "Tesla",
                Symbol = "TSLA",
                MarketCap = 7000,
                Purchase = 180,
                LastDiv = 2.0m,
                Industry = "Auto"
            };
            int id = 1;
            Stock result = null;
            _mockRepo.Setup(r => r.GetStock(It.IsAny<Expression<Func<Stock, bool>>>()))
             .ReturnsAsync(existingStock);

            _mockRepo.Setup(r => r.UpdateStock(It.IsAny<Stock>())).Callback<Stock>(u=>result =u)
                    .Returns(Task.CompletedTask);
            _mockMapper.Setup(m => m.Map<StockDTO>(It.IsAny<Stock>()))
              .Returns(new StockDTO());
            await _service.UpdateStock(id, stockUpdateDTO);

            Assert.NotNull(result);
            Assert.NotNull(result);
            Assert.Equal("Tesla Updated", result.CompanyName);
            Assert.Equal(9000, result.MarketCap);
            Assert.Equal(200, result.Purchase);
            Assert.Equal(3.0m, result.LastDiv);
            Assert.Equal("Automotive", result.Industry);

            _mockRepo.Verify(r => r.UpdateStock(result), Times.Once);

           
            _mockMapper.Verify(m => m.Map<StockDTO>(existingStock), Times.Once);

          
        }
    }
}