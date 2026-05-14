using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using StockApplicationApi.Exceptions;
using StockApplicationApi.Mapper;
using StockApplicationApi.Models;
using StockApplicationApi.Models.DTOs.CommentDTOs;
using StockApplicationApi.Models.DTOs.StockDTOs;
using StockApplicationApi.Repositary.CommentRepositary;
using StockApplicationApi.Repositary.StockRepositary;
using StockApplicationApi.Services.CommentServices;
using StockApplicationApi.Services.RedisService;
using System.Linq.Expressions;

namespace StockApplication.UnitTests.Services
{
    public class CommentServiceTests
    {
        private readonly IMapper _Imapper;
        private readonly Mock<IComment> _mockRepo;
        private readonly CommentService _service;
        private readonly Mock<IStock>  _IStock;
        private readonly Mock<ILogger<CommentService>> _mockLogger;
        private readonly Mock<IRedisService> _mockRedisService;

        public CommentServiceTests()
        {
            var config = new MapperConfiguration(cfg =>
            {

                cfg.AddProfile<MapConfig>();
            });
            _Imapper = config.CreateMapper();
            _mockRepo = new Mock<IComment>();
            _IStock = new Mock<IStock>();
                _mockLogger = new Mock<ILogger<CommentService>>();
            _mockRedisService = new Mock<IRedisService>();
            _service = new CommentService(_mockRepo.Object,_Imapper, _IStock.Object, _mockLogger.Object, _mockRedisService.Object);
        }
        [Fact]
        public async Task AddComment_StockNotFound_ThrowsConflictException()
        {

            var createCommentDto = new CreateComment
            {
                Title = "Test Comment",
                Content = "This is a test comment",
                StockId = 1
            };
           var userId = "123";
            _IStock.Setup(r => r.StockExists(createCommentDto.StockId)).ReturnsAsync(false);
            var ex = await Assert.ThrowsAsync<ConflictException>(
             () => _service.AddComment(createCommentDto,createCommentDto.StockId, userId)        
         );

            Assert.Contains("This stock doesnt exist in stock database", ex.Message );

        }
            [Fact]
        public async Task AddComment_ValidComment_ReturnsCommentDTO()
        {
            var userID = "123";
            var CommentEntity = new Comment
            {
                Id = 1,
                Title = "Test Comment",
                Content = "This is a test comment",
                CreatedOn = DateTime.UtcNow,
                StockId = 2
            };

            var commentDto = new CommentDto
            {
                Id = 1,
                Title = "Test Comment",
                Content = "This is a test comment",
                CreatedOn = DateTime.UtcNow,
                StockId = 2
            };
            var createCommentDto = new CreateComment
            {
                Title = "New Comment",
                Content = "This is a new comment",
                StockId = 2
            };
        
            _IStock.Setup(r => r.StockExists(createCommentDto.StockId))
       .ReturnsAsync(true);

            // fake repo: pretend DB save succeeded
            _mockRepo.Setup(r => r.AddComment(CommentEntity))
                     .Returns(Task.CompletedTask);

            // ACT
            var result = await _service.AddComment(createCommentDto,createCommentDto.StockId, userID);

            Assert.NotNull(result);
            Assert.Contains("This is a new comment", result.Content);
            Assert.Contains("New Comment", result.Title);

            _mockRepo.Verify(r => r.AddComment(It.Is<Comment>(s => s.Title == "New Comment"
            && s.Content == "This is a new comment"
            && s.StockId == 2)), Times.Once);

        }

        [Fact]
        public async Task UpdateComment_CommentNotFound_ThrowsNotFoundException()
        {
            var userID = "123";
            CommentUpdateDTO commentUpdateDTO = new();
            int id = 1;


            // mock repo returns null → stock not found in DB
            _mockRepo.Setup(r => r.GetComment(It.IsAny<Expression<Func<Comment, bool>>>(), true))
                     .ReturnsAsync((Comment)null);

            // ACT
            var ex = await Assert.ThrowsAsync<NotFoundException>(
                () => _service.UpdateComment(id, commentUpdateDTO, userID)
            );

            // ASSERT
            Assert.Contains("Does this Comment exists?", ex.Message);
          _mockRepo.Verify(r => r.GetComment(It.IsAny<Expression<Func<Comment, bool>>>(), true), Times.Once);
        }
        [Fact]
        public async Task UpdateComment_ValidComment_FieldsAreCorrectlyMapped()
        {
            var userID = "123";
            CommentUpdateDTO commentUpdateDTO = new()
            {
              Title = "TITLEUPDATED",
              Content= "THIS IS CONTENT"
            };
            Comment existingComment = new()
            {
                Id = 1,
              Title = "TITLE",
              Content="THIS IS CONTENT"
            };
            int id = 1;
         
            _mockRepo.Setup(r => r.GetComment(It.IsAny<Expression<Func<Comment, bool>>>(), true))
             .ReturnsAsync(existingComment);

            await _service.UpdateComment(id, commentUpdateDTO, userID);

            Assert.NotNull(existingComment);
            Assert.Contains("TITLEUPDATED", existingComment.Title);
            Assert.Contains("THIS IS CONTENT", existingComment.Content);
           

            _mockRepo.Verify(r => r.UpdateComment(existingComment), Times.Once);

        }
    }
}