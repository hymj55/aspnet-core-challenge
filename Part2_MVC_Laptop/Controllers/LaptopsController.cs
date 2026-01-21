using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Part2_MVC_Laptop.Models;


namespace Part2_MVC_Laptop.Controllers;

public class LaptopsController : Controller
{
    private readonly ILogger<LaptopsController> _logger;

    public LaptopsController(ILogger<LaptopsController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Laptop> laptops = LaptopStore.Laptops;
        return View(laptops);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Laptop laptop)
    {
        LaptopStore.AddLaptop(laptop);
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
