using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using StockApplicationApi.Models;
using StockApplicationApi.Models.DTOs.CommentDTOs;
using StockApplicationApi.Services.CommentServices;
using System.Net;

namespace StockApplicationApi.Controllers
{
    [Route("api/Comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _IComment;
        private readonly IValidator<CreateComment> _CreateValidator;

        public CommentController(ICommentService commentService, IValidator<CreateComment> validator)
        {
            _IComment = commentService;
            _CreateValidator = validator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _IComment.GetAllComments();

            return Ok(new APIResponse
            {
                IsSuccess = true,
                statusCode = HttpStatusCode.OK,
                Result = comments
            });
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateComment dto)
        {
            var validationResult = await _CreateValidator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .GroupBy(x => x.PropertyName)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Select(e => e.ErrorMessage).ToArray()
                    );

                return BadRequest(
                    new APIResponse
                    {
                        Errors = errors,
                        IsSuccess = false,
                        statusCode = HttpStatusCode.BadRequest,
                        Result = null,
                        Message = "something went wrong."
                    }

                    );
            }
            var createdComment =await _IComment.AddComment(dto);

            return Ok(new APIResponse
            {
                IsSuccess = true,
                statusCode = HttpStatusCode.Created,
                Message = "Stock created successfully",
                Result = createdComment
            }
             );    
        }
    }
}