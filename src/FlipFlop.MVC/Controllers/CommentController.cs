using System.Net.Mime;
using FlipFlop.Domain.Models;
using FlipFlop.Helpers.Exceptions;
using FlipFlop.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlipFlop.MVC.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IUserService _userService;
        public CommentController(ICommentService commentService, IUserService userService)
        {
            _userService = userService;
            _commentService = commentService;
        }

        [Authorize]
        [HttpPost("/comments/create/{postId}")]
        public async Task<IActionResult> Create([FromRoute]string postId, [FromForm]string text)
        {
            User? user = await _userService.GetUserByUsername(HttpContext.User.Identity.Name);
            if (user == null) {
                return Redirect("/account/login/");
            }
            Comment comment = new Comment {
                PostId = postId,
                Body = text,
                Author = user,
                AuthorId = user.Id,
            };
            await _commentService.CreateComment(comment, postId);
            return Redirect("/posts/"+postId);
        }
    }
}