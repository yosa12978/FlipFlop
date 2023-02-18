using System.Net.Mime;
using FlipFlop.Domain.Models;
using FlipFlop.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlipFlop.MVC.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [Authorize]
        [HttpPost("/comments/create/{postId}")]
        public async Task<IActionResult> Create([FromRoute]string postId, [FromForm]string text)
        {
            Comment comment = new Comment {
                PostId = postId,
                Body = text,
                // todo : add author id and author;
            };
            await _commentService.CreateComment(comment);
            return Redirect("/posts/"+postId);
        }
        
    }
}