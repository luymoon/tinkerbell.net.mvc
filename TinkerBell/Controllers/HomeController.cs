using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using TinkerBell.Models;

namespace TinkerBell.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
       List<Fada> fadas = [];
       using (StreamReader leitor = new("Data\\fadas.json"))
       {
        string dados = leitor.ReadToEnd();
        fadas = JsonSerializer.Deserialize<List<Fada>>(dados);
       }
       return View(fadas);
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
