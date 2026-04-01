using AutoMapper;
using Moq;
using StockApplicationApi.Exceptions;
using StockApplicationApi.Models;
using StockApplicationApi.Models.DTOs;
using StockApplicationApi.Repositary.StockRepositary;
using StockApplicationApi.Services.StockServices;
using System.Linq.Expressions;

namespace StockApplicationApi.UnitTests.Services
{
    public class StockClassTests
    {
        private readonly Mock<IStock> _mockRepo;
        private readonly Mock<IMapper> _mockMapper;
        private readonly StockClass  _service;
        public StockClassTests()
        {
            _mockMapper = new Mock<IMapper>();
            _mockRepo = new Mock<IStock>();
            _service = new StockClass(_mockRepo.Object, _mockMapper.Object);
        }
        // TEST 1 - Company name duplicate
        [Fact]
        public async Task AddStock_CompanyNameAlreadyExists_ThrowConflictException()
        {
            var createDTO = new StockCreateDTO { CompanyName = "Apple", Industry = "Tech", Symbol = "AAPL" };

            _mockRepo.SetupSequence(r => r.GetStock(It.IsAny<Expression<Func<Stock, bool>>>()))
                     .ReturnsAsync(new Stock())   // 1st call (company) = duplicate = throws here
                     .ReturnsAsync((Stock)null)   // 2nd call (industry) = never reached
                     .ReturnsAsync((Stock)null);  // 3rd call (symbol) = never reached

            var ex = await Assert.ThrowsAsync<ConflictException>(() => _service.AddStock(createDTO));


            Assert.Equal("This Company name already exists.", ex.Message);
        }

        // TEST 2 - Industry duplicate
        [Fact]
        public async Task AddStock_IndustryAlreadyExists_ThrowConflictException()
        {
            var createDTO = new StockCreateDTO { CompanyName = "Apple", Industry = "Tech", Symbol = "AAPL" };

            _mockRepo.SetupSequence(r => r.GetStock(It.IsAny<Expression<Func<Stock, bool>>>()))
                     .ReturnsAsync((Stock)null)  
                     .ReturnsAsync(new Stock())   
                     .ReturnsAsync((Stock)null);

            var ex = await Assert.ThrowsAsync<ConflictException>(() => _service.AddStock(createDTO));

          
            Assert.Equal("This Industry name already exists.", ex.Message);
        }

        // TEST 3 - Symbol duplicate
        [Fact]
        public async Task AddStock_SymbolAlreadyExists_ThrowConflictException()
        {
            var createDTO = new StockCreateDTO { CompanyName = "Apple", Industry = "Tech", Symbol = "AAPL" };

            _mockRepo.SetupSequence(r => r.GetStock(It.IsAny<Expression<Func<Stock, bool>>>()))
                     .ReturnsAsync((Stock)null)   
                     .ReturnsAsync((Stock)null)  
                     .ReturnsAsync(new Stock());

            var ex = await Assert.ThrowsAsync<ConflictException>(() => _service.AddStock(createDTO));

            // Now the test checks the RIGHT thing was validated
            Assert.Equal("This Symbol name already exists.", ex.Message);
        }
        [Fact]
        public async Task AddStock_ValidStock_ReturnsStockDTO()
        {
            // Arrange
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

        //to skip this part we are writnig these clauses
            _mockRepo.SetupSequence(r => r.GetStock(It.IsAny<Expression<Func<Stock, bool>>>()))
                     .ReturnsAsync((Stock)null)   // company → no duplicate
                     .ReturnsAsync((Stock)null)   // industry → no duplicate
                     .ReturnsAsync((Stock)null);  // symbol → no duplicate

            // AutoMapper: StockCreateDTO → Stock entity
            _mockMapper.Setup(m => m.Map<Stock>(createDTO))
                       .Returns(stockEntity);

            // AutoMapper: Stock entity → StockDTO
            _mockMapper.Setup(m => m.Map<StockDTO>(stockEntity))
                       .Returns(stockDTO);

            // Repository save
            _mockRepo.Setup(r => r.AddStock(stockEntity))
                     .Returns(Task.CompletedTask);

            // Act
         
            var result = await _service.AddStock(createDTO);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Apple", result.CompanyName);
            Assert.Equal("Tech", result.Industry);
            Assert.Equal("AAPL", result.Symbol);
            Assert.Equal(150.00m, result.Purchase);
            Assert.Equal(0.5m, result.LastDiv);
            Assert.Equal(1000000000, result.MarketCap);
            Assert.Empty(result.Comments);

            // verify DB save was actually called
            _mockRepo.Verify(r => r.AddStock(stockEntity), Times.Once);
        }
    }
}
