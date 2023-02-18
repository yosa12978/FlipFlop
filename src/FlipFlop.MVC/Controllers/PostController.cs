using FlipFlop.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FlipFlop.Domain.Models;
using FlipFlop.Helpers.Exceptions;

namespace FlipFlop.MVC.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly IUserService _userService;

        public PostController(IPostService postService, IUserService userService)
        {
            _userService = userService;
            _postService = postService;
        }

        [HttpGet("/posts/detail/{id}")]
        public async Task<IActionResult> Detail([FromRoute]string id)
        {
            ViewBag.Post = await _postService.GetPostById(id);
            return View();
        }

        [Authorize]
        [HttpGet("/posts/create")]
        public IActionResult Create()
        {
            return View();
        }


        [Authorize]
        [HttpPost("/posts/create")]
        public async Task<IActionResult> Create(string title, string body, bool nsfw)
        {
            User? author = await _userService.GetUserByUsername(HttpContext.User.Identity.Name);
            if (author == null)
                throw new ForbiddenException("forbidden");
            Post post = new Post
            {
                Id = Guid.NewGuid().ToString(),
                Title = title,
                Body = body,
                NSFW = nsfw,
                AuthorId = author.Id,
                Author = author,
                CommentCount = 0,
            };
            await _postService.CreatePost(post);
            return Redirect("/posts/detail/"+post.Id);
        }

        [HttpGet("/posts/search")]
        public async Task<IActionResult> Search([FromQuery] string q)
        {
            ViewBag.Posts = await _postService.SearchPost(q);
            return View();
        }
    }
}