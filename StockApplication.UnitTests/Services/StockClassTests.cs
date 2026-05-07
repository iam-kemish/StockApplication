using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using StockApplicationApi.Exceptions;
using StockApplicationApi.Mapper;
using StockApplicationApi.Models;
using StockApplicationApi.Models.DTOs.StockDTOs;
using StockApplicationApi.Repositary.StockRepositary;
using StockApplicationApi.Services.RedisService;
using StockApplicationApi.Services.StockServices;
using System.Linq.Expressions;

namespace StockApplicationApi.UnitTests.Services
{
    public class StockClassTests
    {
        private readonly Mock<IStock> _mockRepo;
        private readonly IMapper _Imapper;
        private readonly StockClass _service;
        private readonly Mock<ILogger<StockClass>> _mockLogger;
        private readonly Mock<IRedisService> _mockRedisService;     

        public StockClassTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
               
                cfg.AddProfile<MapConfig>();
            });         
            _Imapper = config.CreateMapper();

            _mockRepo = new Mock<IStock>();
            _mockLogger = new Mock<ILogger<StockClass>>();
            _mockRedisService = new Mock<IRedisService>();
            _service = new StockClass(_mockRepo.Object, _Imapper, _mockLogger.Object, _mockRedisService.Object);
        }

        [Fact]
        public async Task AddStock_DuplicateExists_ThrowsConflictException()
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
            var existingStock = new Stock
            {
              
                CompanyName = "Apple",
                Industry = "Tech",
                Symbol = "AAPL",
                Purchase = 150.00m,
                LastDiv = 0.5m,
                MarketCap = 1000000000
            };
           _mockRepo.Setup(r=>r.GetStock(It.IsAny<Expression<Func<Stock, bool>>>(), It.IsAny<bool>()))
                    .ReturnsAsync(existingStock);
            var ex = await Assert.ThrowsAsync<ConflictException>(
                () => _service.AddStock(createDTO)
            );
            Assert.Contains("already exists", ex.Message);
          
            _mockRepo.Verify(r => r.GetStock(It.IsAny<Expression<Func<Stock, bool>>>(), It.IsAny<bool>()), Times.Once);
        }                                     
          
        
        [Fact]
        public async Task AddStock_ValidStock_ReturnsStockDTO()
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

          _mockRepo.Setup(r=>r.GetStock(It.IsAny<Expression<Func<Stock, bool>>>(), It.IsAny<bool>()))
                   .ReturnsAsync((Stock)null);

        
            // fake repo: pretend DB save succeeded
            _mockRepo.Setup(r => r.AddStock(stockEntity))
                     .Returns(Task.CompletedTask);
            _mockRedisService.Setup(r => r.RemoveDataAsync(It.IsAny<string>()))
                 .ReturnsAsync(true);

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
          _mockRedisService.Verify(r => r.RemoveDataAsync(It.IsAny<string>()), Times.Once);
           
        }


        // TEST 5 — stock not found → throws NotFoundException
        [Fact]
        public async Task DeleteStock_StockNotFound_ThrowsNotFoundException()
        {

            int stockId = 1;

           
            _mockRepo.Setup(r => r.GetStock(It.IsAny<Expression<Func<Stock, bool>>>(), It.IsAny<bool>()))
                     .ReturnsAsync((Stock)null);

          
            var ex = await Assert.ThrowsAsync<NotFoundException>(
                () => _service.DeleteStock(stockId)
            );

            Assert.Contains("Does this Stock exists?", ex.Message);

          
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

         
            _mockRepo.Setup(r => r.GetStock(It.IsAny<Expression<Func<Stock, bool>>>(), It.IsAny<bool>()))
                     .ReturnsAsync(stockEntity);

           
            _mockRepo.Setup(r => r.DeleteStock(stockEntity))
                     .Returns(Task.CompletedTask);

            _mockRedisService.Setup(r => r.RemoveDataAsync(It.IsAny<string>()))
                 .ReturnsAsync(true);
    
            await _service.DeleteStock(stockId);


            _mockRepo.Verify(r => r.GetStock(It.IsAny<Expression<Func<Stock, bool>>>(), It.IsAny<bool>()), Times.Once);
           _mockRedisService.Verify(r => r.RemoveDataAsync(It.IsAny<string>()), Times.Once);
            // prove delete was actually called once
            _mockRepo.Verify(r => r.DeleteStock(stockEntity), Times.Once);
        }
        [Fact]
        public async Task UpdateStock_StockNotFound_ThrowsNotFoundException()
        {
            StockUpdateDTO stockUpdateDTO = new();
            int id = 1;


            // mock repo returns null → stock not found in DB
            _mockRepo.Setup(r => r.GetStock(It.IsAny<Expression<Func<Stock, bool>>>(), It.IsAny<bool>())).ReturnsAsync((Stock)null);

            // ACT
            var ex = await Assert.ThrowsAsync<NotFoundException>(
                () => _service.UpdateStock(id, stockUpdateDTO)
            );

            // ASSERT
            Assert.Contains("Does this Stock exists?", ex.Message);

            // prove update was never called because stock was not found
         _mockRepo.Verify(r=>r.GetStock(It.IsAny<Expression<Func<Stock, bool>>>(), It.IsAny<bool>()), Times.Once);

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
          
            _mockRepo.Setup(r => r.GetStock(It.IsAny<Expression<Func<Stock, bool>>>(), true)).ReturnsAsync(existingStock);
            _mockRedisService.Setup(r=>r.RemoveDataAsync(It.IsAny<string>())).ReturnsAsync(true);
          
            //_mockMapper.Setup(m => m.Map<StockDTO>(It.IsAny<Stock>()))
            //  .Returns(new StockDTO());
            await _service.UpdateStock(id, stockUpdateDTO);

            Assert.NotNull(existingStock);
            Assert.Equal("Tesla Updated", existingStock.CompanyName);
            Assert.Equal("TSLA", existingStock.Symbol);
            Assert.Equal(9000, existingStock.MarketCap);
            Assert.Equal(200, existingStock.Purchase);
            Assert.Equal(3.0m, existingStock.LastDiv);
            Assert.Equal("Automotive", existingStock.Industry);

            _mockRepo.Verify(r=>r.UpdateStock(existingStock), Times.Once);
            _mockRedisService.Verify(r => r.RemoveDataAsync("stock"), Times.Once);
            _mockRedisService.Verify(r => r.RemoveDataAsync($"stock_{id}"), Times.Once);

        }
    }
}