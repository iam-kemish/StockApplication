using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using StockApplicationApi.Exceptions;
using StockApplicationApi.Models;
using StockApplicationApi.Models.DTOs.CommentDTOs;
using StockApplicationApi.Repositary.CommentRepositary;
using StockApplicationApi.Repositary.StockRepositary;
using StockApplicationApi.Services.CommentServices;

namespace StockApplication.UnitTests.Services
{
    public class CommentServiceTests
    {
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IComment> _mockRepo;
        private readonly CommentService _service;
        private readonly Mock<IStock>  _IStock;

        public CommentServiceTests()
        {
            _mockMapper = new Mock<IMapper>();
            _mockRepo = new Mock<IComment>();
            _IStock = new Mock<IStock>();
            _service = new CommentService(_mockRepo.Object, _mockMapper.Object, _IStock.Object);
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
            _IStock.Setup(r => r.StockExists(createCommentDto.StockId)).ReturnsAsync(false);
            var ex = await Assert.ThrowsAsync<ConflictException>(
             () => _service.AddComment(createCommentDto)        
         );

            Assert.Equal("This stock doesnt exist in stock database", ex.Message );

        }
            [Fact]
        public async Task AddComment_ValidComment_ReturnsCommentDTO()
        {
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
            _mockMapper.Setup(m => m.Map<Comment>(createCommentDto))
                     .Returns(CommentEntity);
            _IStock.Setup(r => r.StockExists(createCommentDto.StockId))
       .ReturnsAsync(true);

            _mockMapper.Setup(m => m.Map<CommentDto>(CommentEntity))
                       .Returns(commentDto);

            // fake repo: pretend DB save succeeded
            _mockRepo.Setup(r => r.AddComment(CommentEntity))
                     .Returns(Task.CompletedTask);

            // ACT
            var result = await _service.AddComment(createCommentDto);

            Assert.NotNull(result);
            Assert.Equal("This is a test comment", result.Content);
            Assert.Equal("Test Comment", result.Title);

            _mockRepo.Verify(r => r.AddComment(CommentEntity), Times.Once);

           
            _mockMapper.Verify(m => m.Map<Comment>(createCommentDto), Times.Once);

            
            _mockMapper.Verify(m => m.Map<CommentDto>(CommentEntity), Times.Once);
        }
    }
}