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
       List<Fada> fadas = GetFadas();
       List<Tipo> tipos = GetTipos();
       ViewData["Tipos"] = tipos;
       return View(fadas);
    }

    public IActionResult Details(int id)
    {
       List<Fada> fadas = GetFadas();
       List<Tipo> tipos = GetTipos();
        DetailsVM details = new() {
            Tipos = tipos,
            Atual = fadas.FirstOrDefault(p => p.Numero == id),
            Anterior = fadas.OrderByDescending(p => p.Numero).FirstOrDefault(p => p.Numero < id),
            Proximo = fadas.OrderBy(p => p.Numero).FirstOrDefault(p => p.Numero > id),
        };
        return View(details);
    }

    private List<Fada> GetFadas()
    {
        using (StreamReader leitor = new("Data\\fadas.json"))
        {
            string dados = leitor.ReadToEnd();
            return JsonSerializer.Deserialize<List<Fada>>(dados);
        }
    }

    private List<Tipo> GetTipos()
    {
        using (StreamReader leitor = new("Data\\tipos.json"))
        {
            string dados = leitor.ReadToEnd();
            return JsonSerializer.Deserialize<List<Tipo>>(dados);
        }
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
