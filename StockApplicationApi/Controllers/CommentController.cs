using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockApplicationApi.Exceptions;
using StockApplicationApi.Models;
using StockApplicationApi.Models.DTOs.CommentDTOs;
using StockApplicationApi.Models.DTOs.StockDTOs;
using StockApplicationApi.Services.CommentServices;
using StockApplicationApi.Services.StockServices;
using System.Net;
using System.Security.Claims;

namespace StockApplicationApi.Controllers
{
    [Route("api/Comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _IComment;
        private readonly IValidator<CreateComment> _CreateValidator;
        private readonly IValidator<CommentUpdateDTO> _UpdateValidator;
        public CommentController(ICommentService commentService, IValidator<CreateComment> validator, IValidator<CommentUpdateDTO> UpdateValidator)
        {
            _IComment = commentService;
            _CreateValidator = validator;
            _UpdateValidator = UpdateValidator;
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
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateComment dto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
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
            var createdComment =await _IComment.AddComment(dto, dto.StockId, userId!);

            return Ok(new APIResponse
            {
                IsSuccess = true,
                statusCode = HttpStatusCode.Created,
                Message = "Comment created successfully",
                Result = createdComment
            }
             );    
        }
        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
           
            var comment = await _IComment.GetCommentById(id);
            return Ok(new APIResponse
            {
                IsSuccess = true,
                statusCode = HttpStatusCode.OK,
                Result = comment
            });
        }

        [HttpPut("{id:int}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, [FromBody] CommentUpdateDTO dto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var validationResult = await _UpdateValidator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .GroupBy(x => x.PropertyName)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Select(e => e.ErrorMessage).ToArray()
                    );

                throw new AppValidationException(errors);
            }

            var updatedStock = await _IComment.UpdateComment(id, dto, userId!);

            return Ok(new APIResponse
            {
                IsSuccess = true,
                statusCode = HttpStatusCode.OK,
                Message = "Comment updated successfully",
                Result = updatedStock
            });
        }
    }
}