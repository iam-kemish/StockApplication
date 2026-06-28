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
using static StockApplicationApi.Helpers.RedisCacheStrings;

namespace StockApplication.UnitTests.Features.Stocks
{
    public class UpdateStockHandlerTests
    {
        private readonly Mock<IStock> _mockRepo;
        private readonly IMapper _Imapper;
        private readonly UpdateStockHandler _handler;
        private readonly Mock<ILogger<UpdateStockHandler>> _mockLogger;
        private readonly Mock<IRedisService> _mockRedisService;
        public UpdateStockHandlerTests()
        {
            _mockRepo = new Mock<IStock>();
            var config = new MapperConfiguration(cfg =>
            {

                cfg.AddProfile<MapConfig>();
            });
            _Imapper = config.CreateMapper();
            _mockLogger = new Mock<ILogger<UpdateStockHandler>>();
            _mockRedisService = new Mock<IRedisService>();
            _handler = new UpdateStockHandler(_mockRepo.Object, _mockLogger.Object, _mockRedisService.Object, _Imapper);
        }
        [Fact]
        public async Task UpdateStock_StockNotFound_ThrowsNotFoundException()
        {
            StockUpdateDTO stockUpdateDTO = new();
            int id = 1;

            _mockRepo
        .Setup(r => r.GetStock(It.IsAny<Expression<Func<Stock, bool>>>(), It.IsAny<System.Threading.CancellationToken>(), It.IsAny<bool>()))
    .ReturnsAsync((Stock?)null);


            // ACT
            var ex = await Assert.ThrowsAsync<NotFoundException>(
                () => _handler.Handle(new UpdateStockCommand(id, stockUpdateDTO), default)
            );

            // ASSERT
            Assert.Contains("Does this Stock exists?", ex.Message);

            // prove update was never called because stock was not found
            _mockRepo.Verify(r => r.GetStock(It.IsAny<Expression<Func<Stock, bool>>>(), It.IsAny<System.Threading.CancellationToken>(), It.IsAny<bool>()), Times.Once);

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

            _mockRepo.Setup(r => r.GetStock(It.IsAny<Expression<Func<Stock, bool>>>(), It.IsAny<System.Threading.CancellationToken>(), true)).ReturnsAsync(existingStock);
            _mockRedisService.Setup(r => r.RemoveDataAsync(It.IsAny<string>())).ReturnsAsync(true);
            _mockRedisService.Setup(r => r.RemoveByPrefixAsync(It.IsAny<string>())).Returns(Task.CompletedTask);
            //_mockMapper.Setup(m => m.Map<StockDTO>(It.IsAny<Stock>()))
            //  .Returns(new StockDTO());
            await _handler.Handle(new UpdateStockCommand(id, stockUpdateDTO), default);

            Assert.NotNull(existingStock);
            Assert.Equal("Tesla Updated", existingStock.CompanyName);
            Assert.Equal("TSLA", existingStock.Symbol);
            Assert.Equal(9000, existingStock.MarketCap);
            Assert.Equal(200, existingStock.Purchase);
            Assert.Equal(3.0m, existingStock.LastDiv);
            Assert.Equal("Automotive", existingStock.Industry);

            _mockRepo.Verify(r => r.UpdateStock(existingStock, It.IsAny<System.Threading.CancellationToken>()), Times.Once);
            _mockRedisService.Verify(r => r.RemoveDataAsync(CacheKeys.StockDetail(id)), Times.Once);
            _mockRedisService.Verify(r => r.RemoveByPrefixAsync(CacheKeys.StockList), Times.Once);

        }
    }
}