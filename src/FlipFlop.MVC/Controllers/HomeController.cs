using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FlipFlop.MVC.Models;
using FlipFlop.Services.Interfaces;

namespace FlipFlop.MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IPostService _postService;

    public HomeController(ILogger<HomeController> logger, IPostService postService)
    {
        _logger = logger;
        _postService = postService;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.Posts = await _postService.GetAll();
        return View();
    }

    [HttpGet("/privacy")]
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
