using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using StockApplicationApi.Exceptions;
using StockApplicationApi.Features.Stocks.Commands;
using StockApplicationApi.Features.Stocks.Handlers;
using StockApplicationApi.Mapper;
using StockApplicationApi.Models;
using StockApplicationApi.Models.DTOs.StockDTOs;
using StockApplicationApi.Repositary.StockRepositary;
using StockApplicationApi.Services.RedisService;
using System.Linq.Expressions;
using System.Reflection.Metadata;

namespace StockApplication.UnitTests.Features.Stocks
{
    public class CreateStockHandlerTests
    {
        private readonly Mock<IStock> _mockRepo;
        private readonly IMapper _Imapper;
        private readonly Mock<ILogger<AddStockHandler>> _mockLogger;
        private readonly Mock<IRedisService> _mockRedisService;
        private readonly AddStockHandler _handler;

        public CreateStockHandlerTests()
        {
            _mockRepo = new Mock<IStock>();
            var config = new MapperConfiguration(cfg =>
            {

                cfg.AddProfile<MapConfig>();
            });
            _Imapper = config.CreateMapper();
            _mockLogger = new Mock<ILogger<AddStockHandler>>();
            _mockRedisService = new Mock<IRedisService>();
            _handler = new AddStockHandler(_mockRepo.Object, _Imapper, _mockLogger.Object, _mockRedisService.Object);
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
            _mockRepo.Setup(r => r.GetStock(It.IsAny<Expression<Func<Stock, bool>>>(), It.IsAny<System.Threading.CancellationToken>(), It.IsAny<bool>()))
                     .ReturnsAsync(existingStock);
            var ex = await Assert.ThrowsAsync<ConflictException>(
                () => _handler.Handle(new AddStockCommand(createDTO), It.IsAny<System.Threading.CancellationToken>())
            );
            Assert.Contains("already exists", ex.Message);
            _mockRepo.Verify(r => r.GetStock(It.IsAny<Expression<Func<Stock, bool>>>(), It.IsAny<System.Threading.CancellationToken>(), It.IsAny<bool>()), Times.Once);
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

            _mockRepo.Setup(r => r.GetStock(It.IsAny<Expression<Func<Stock, bool>>>(), It.IsAny<System.Threading.CancellationToken>(), true))
                     .ReturnsAsync((Stock)null);


            // fake repo: pretend DB save succeeded
            _mockRepo.Setup(r => r.AddStock(It.IsAny<Stock>(), It.IsAny<System.Threading.CancellationToken>()))
                     .Returns(Task.CompletedTask);
            _mockRedisService.Setup(r => r.RemoveByPrefixAsync(It.IsAny<string>()))
                 .Returns(Task.CompletedTask);

            // ACT
            var result = await _handler.Handle(new AddStockCommand(createDTO), It.IsAny<System.Threading.CancellationToken>());

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
            _mockRepo.Verify(r => r.AddStock(It.Is<Stock>(s => s.CompanyName == "Apple"
            && s.Industry == "Tech"
            && s.Symbol == "AAPL"
            && s.Purchase == 150.00m
            && s.LastDiv == 0.5m
            && s.MarketCap == 1000000000), It.IsAny<System.Threading.CancellationToken>()), Times.Once);

            _mockRedisService.Verify(r => r.RemoveByPrefixAsync(It.IsAny<string>()), Times.Once);

        }

    }
}
