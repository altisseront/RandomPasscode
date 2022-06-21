using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RandomPasscode.Models;

namespace RandomPasscode.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }


    public IActionResult Index()
    {   
        if(HttpContext.Session.GetInt32("Count") == null)
        {
            HttpContext.Session.SetInt32("Count", 0);
        }
        return View();
    }
    [HttpPost("Redir")]
    public IActionResult Redir()
    {
        int? og = HttpContext.Session.GetInt32("Count");
        if (og != null){
            og++;
            int x = (int)og;
            HttpContext.Session.SetInt32("Count",  x);
        }
        Random rnd = new Random();
        HttpContext.Session.SetInt32("RandomNum", rnd.Next(0, 1000000));
        return RedirectToAction("Index");
    }
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
