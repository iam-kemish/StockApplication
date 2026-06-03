using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using StockApplicationApi.Models;
using StockApplicationApi.Models.DTOs.CommentDTOs;
using StockApplicationApi.Services.CommentServices;
using StockApplicationApi.Validators;
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
        [EnableRateLimiting("FixedPolicy")]
        [ServiceFilter(typeof(ValidateFilter<CreateComment>))]
        public async Task<IActionResult> Create([FromBody] CreateComment dto)
        {
            bool isCustomer  = User.IsInRole("Customer");
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
           
            var createdComment =await _IComment.AddComment(dto, dto.StockId, userId!,isCustomer);

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
        [ServiceFilter(typeof(ValidateFilter<CommentUpdateDTO>))]
        public async Task<IActionResult> Update(int id, [FromBody] CommentUpdateDTO dto)
        {
            bool isCustomer  = User.IsInRole("Customer");
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
           
            var updatedStock = await _IComment.UpdateComment(id, dto, userId!, isCustomer);

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