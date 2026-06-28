using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using StockApplicationApi.Exceptions;
using StockApplicationApi.Features.Stocks.Commands;
using StockApplicationApi.Features.Stocks.Handlers;
using StockApplicationApi.Mapper;
using StockApplicationApi.Models;
using StockApplicationApi.Repositary.StockRepositary;
using StockApplicationApi.Services.RedisService;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using static StockApplicationApi.Helpers.RedisCacheStrings;

namespace StockApplication.UnitTests.Features.Stocks
{
    public class DeleteStockHandlerTests
    {
        private readonly Mock<IStock> _mockRepo;
       
        private readonly Mock<ILogger<DeleteStockHandler>> _mockLogger;
        private readonly Mock<IRedisService> _mockRedisService;
        private readonly DeleteStockHandler _handler;

        public DeleteStockHandlerTests()
        {
            _mockRepo = new Mock<IStock>();
           
            _mockLogger = new Mock<ILogger<DeleteStockHandler>>();
            _mockRedisService = new Mock<IRedisService>();
            _handler = new DeleteStockHandler(_mockRedisService.Object, _mockLogger.Object,_mockRepo.Object);
        }
        [Fact]
        public async Task DeleteStock_StockNotFound_ThrowsNotFoundException()
        {

            int stockId = 1;


            _mockRepo.Setup(r => r.GetStock(It.IsAny<Expression<Func<Stock, bool>>>(), It.IsAny<System.Threading.CancellationToken>(), true))
                     .ReturnsAsync((Stock)null);


            var ex = await Assert.ThrowsAsync<NotFoundException>(
                () => _handler.Handle(new DeleteStockCommand(stockId), It.IsAny<System.Threading.CancellationToken>())
            );

            Assert.Contains("Does this Stock exists?", ex.Message);


            _mockRepo.Verify(r => r.DeleteStock(It.IsAny<Stock>(), It.IsAny<System.Threading.CancellationToken>()), Times.Never);
        }
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


            _mockRepo.Setup(r => r.GetStock(It.IsAny<Expression<Func<Stock, bool>>>(), It.IsAny<System.Threading.CancellationToken>(), It.IsAny<bool>()))
                     .ReturnsAsync(stockEntity);


            _mockRepo.Setup(r => r.DeleteStock(stockEntity, It.IsAny<System.Threading.CancellationToken>()))
                     .Returns(Task.CompletedTask);

            _mockRedisService.Setup(r => r.RemoveDataAsync(It.IsAny<string>()))
                 .ReturnsAsync(true);
            _mockRedisService.Setup(r => r.RemoveByPrefixAsync(It.IsAny<string>()))
                 .Returns(Task.CompletedTask);

            await _handler.Handle(new DeleteStockCommand(stockId), It.IsAny<System.Threading.CancellationToken>());


            _mockRepo.Verify(r => r.GetStock(It.IsAny<Expression<Func<Stock, bool>>>(), It.IsAny<System.Threading.CancellationToken>(), It.IsAny<bool>()), Times.Once);
            // Verify the list cache was cleared
            _mockRedisService.Verify(r => r.RemoveByPrefixAsync(CacheKeys.StockList), Times.Once);

            // Verify the specific item cache was cleared
            _mockRedisService.Verify(r => r.RemoveDataAsync(CacheKeys.StockDetail(stockId)), Times.Once);
            // prove delete was actually called once
            _mockRepo.Verify(r => r.DeleteStock(stockEntity, It.IsAny<System.Threading.CancellationToken>()), Times.Once);
        }

    }
}
