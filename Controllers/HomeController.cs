using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using agentmodedemo.Models;

namespace agentmodedemo.Controllers;

public class HomeController : Controller
{
    private readonly IWebHostEnvironment _environment;

    public HomeController(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        var employees = LoadEmployees();
        return View(employees);
    }

    public IActionResult EmployeeDetails(int id)
    {
        var employees = LoadEmployees();

        if (id < 0 || id >= employees.Count)
        {
            return NotFound();
        }

        return View(employees[id]);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    private List<EmployeeRecord> LoadEmployees()
    {
        var dataPath = Path.Combine(_environment.ContentRootPath, "sampledata.json");

        if (!System.IO.File.Exists(dataPath))
        {
            return new List<EmployeeRecord>();
        }

        var rawJson = System.IO.File.ReadAllText(dataPath);
        return JsonSerializer.Deserialize<List<EmployeeRecord>>(rawJson) ?? new List<EmployeeRecord>();
    }
}
