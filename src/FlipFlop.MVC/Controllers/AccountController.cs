using System.Security.Claims;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FlipFlop.MVC.Models;
using FlipFlop.Services.Interfaces;
using FlipFlop.Domain.Models;
using FlipFlop.Helpers;
using Microsoft.AspNetCore.Authentication;

namespace FlipFlop.MVC.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUserService _userService;

    public AccountController(ILogger<HomeController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpGet("/account/login")]
    public IActionResult Login()
    {
        return View();
    }


    [HttpPost("/account/login")]
    public async Task<IActionResult> Login(string username, string password)
    {
        User? usr = await _userService.GetUser(username, password);
        if (usr == null)
        {
            ViewBag.Error = "Invalid credentials";
            return View();
        }
        List<Claim> claims = new List<Claim> {
            new Claim(ClaimTypes.Name, username), 
            new Claim(ClaimTypes.Role, usr.Role),
        };
        ClaimsIdentity identity = new ClaimsIdentity(claims, "login");
        ClaimsPrincipal principal = new ClaimsPrincipal(identity);
        await HttpContext.SignInAsync(principal);
        return Redirect("/");
    }

    [HttpGet("/account/signup")]
    public IActionResult Signup()
    {
        return View();
    }

    [HttpPost("/account/signup")]
    public async Task<IActionResult> Signup([FromForm] string username, [FromForm] string password, [FromForm] string passwordC)
    {
        if (password != passwordC)
            return Redirect("/account/signup");
        
        try
        {
            var usr = await _userService.CreateUser(username, password);
            if (usr == null)
                return Redirect("/account/signup");
        }catch(Exception e)
        {
            ViewBag.Error = e.Message;
            return View();
        }
        return Redirect("/account/login");
    }

    [HttpGet("/account/logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return Redirect("/account/login");
    }
}
