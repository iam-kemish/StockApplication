using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using StockApplicationApi.Exceptions;
using StockApplicationApi.Models;
using StockApplicationApi.Models.DTOs.CommentDTOs;
using StockApplicationApi.Models.DTOs.StockDTOs;
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
        private readonly Mock<ILogger<CommentService>> _mockLogger;

        public CommentServiceTests()
        {
            _mockMapper = new Mock<IMapper>();
            _mockRepo = new Mock<IComment>();
            _IStock = new Mock<IStock>();
                _mockLogger = new Mock<ILogger<CommentService>>();  
            _service = new CommentService(_mockRepo.Object, _mockMapper.Object, _IStock.Object, _mockLogger.Object);
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
             () => _service.AddComment(createCommentDto,createCommentDto.StockId)        
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
            var result = await _service.AddComment(createCommentDto,createCommentDto.StockId);

            Assert.NotNull(result);
            Assert.Equal("This is a test comment", result.Content);
            Assert.Equal("Test Comment", result.Title);

            _mockRepo.Verify(r => r.AddComment(CommentEntity), Times.Once);

           
            _mockMapper.Verify(m => m.Map<Comment>(createCommentDto), Times.Once);

            
            _mockMapper.Verify(m => m.Map<CommentDto>(CommentEntity), Times.Once);
        }

        [Fact]
        public async Task UpdateComment_CommentNotFound_ThrowsNotFoundException()
        {
            CommentUpdateDTO commentUpdateDTO = new();
            int id = 1;


            // mock repo returns null → stock not found in DB
            _mockRepo.Setup(r => r.GetCommentForUpdate(id))
                     .ReturnsAsync((Comment)null);

            // ACT
            var ex = await Assert.ThrowsAsync<NotFoundException>(
                () => _service.UpdateComment(id, commentUpdateDTO)
            );

            // ASSERT
            Assert.Equal("Does this Comment exists?", ex.Message);

            // prove update was never called because stock was not found
            _mockRepo.Verify(r => r.UpdateComment(), Times.Never);

        }
        [Fact]
        public async Task UpdateComment_ValidComment_FieldsAreCorrectlyMapped()
        {
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
         
            _mockRepo.Setup(r => r.GetCommentForUpdate(id))
             .ReturnsAsync(existingComment);

            _mockRepo.Setup(r => r.UpdateComment()).Returns(Task.CompletedTask);
            _mockMapper.Setup(m => m.Map<StockDTO>(It.IsAny<Stock>()))
              .Returns(new StockDTO());
            await _service.UpdateComment(id, commentUpdateDTO);

            Assert.NotNull(existingComment);
            Assert.Equal("TITLEUPDATED", existingComment.Title);
            Assert.Equal("THIS IS CONTENT", existingComment.Content);
           

            _mockRepo.Verify(r => r.UpdateComment(), Times.Once);


            _mockMapper.Verify(m => m.Map<CommentDto>(existingComment), Times.Once);


        }
    }
}