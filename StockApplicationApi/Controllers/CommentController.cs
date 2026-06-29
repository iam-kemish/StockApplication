using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using StockApplicationApi.Features.Comments.Commands;
using StockApplicationApi.Features.Comments.Queries;
using StockApplicationApi.Models;
using StockApplicationApi.Models.DTOs.CommentDTOs;
using StockApplicationApi.Validators;
using System.Net;
using System.Security.Claims;

namespace StockApplicationApi.Controllers
{
    [Route("api/Comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
      
        private readonly IValidator<CreateComment> _CreateValidator;
        private readonly IValidator<CommentUpdateDTO> _UpdateValidator;
        private readonly IMediator _IMediatr;

        public CommentController(IValidator<CreateComment> validator, IValidator<CommentUpdateDTO> UpdateValidator, IMediator mediatr)
        {
        
            _CreateValidator = validator;
            _UpdateValidator = UpdateValidator;
            _IMediatr = mediatr;
        }
        [HttpGet]
       
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var query = new GetAllCommentsQuery();
            var comments = await _IMediatr.Send(query, cancellationToken);
            return Ok(new APIResponse
            {
                IsSuccess = true,
                statusCode = HttpStatusCode.OK,
                Result = comments
            });
        }
        [HttpPost("{StockId:int}")]
        [Authorize]
        [EnableRateLimiting("BucketPolicy")]
        [ServiceFilter(typeof(ValidateFilter<CreateComment>))]
        public async Task<IActionResult> Create([FromBody] CreateComment dto,[FromRoute] int StockId, CancellationToken cancellationToken)
        {
            bool isCustomer  = User.IsInRole("Customer");
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            
            var query = new AddCommentCommand(dto,StockId, userId!, isCustomer);
            var comment = await _IMediatr.Send(query, cancellationToken);

            return Ok(new APIResponse
            {
                IsSuccess = true,
                statusCode = HttpStatusCode.Created,
                Message = "Comment created successfully",
                Result = comment
            }
             );    
        }
        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {

            var query = new GetCommentById(id);
            var comment = await _IMediatr.Send(query, cancellationToken);
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
        public async Task<IActionResult> Update(int id, [FromBody] CommentUpdateDTO dto, CancellationToken cancellationToken)
        {
            bool isCustomer  = User.IsInRole("Customer");
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var query = new UpdateCommentCommand(id, dto, userId!, isCustomer);
            var comment = await _IMediatr.Send(query, cancellationToken);
           

            return Ok(new APIResponse
            {
                IsSuccess = true,
                statusCode = HttpStatusCode.OK,
                Message = "Comment updated successfully",
                Result = comment
            });
        }
    }
}