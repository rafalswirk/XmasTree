using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace XmasTreeServiceWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    static Process PythonProcess;
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    [Route("")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet()]
    [Route("[action]")]
    public ActionResult<string> TurnOnTree()
    {
        ProcessStartInfo start = new ProcessStartInfo();
        start.FileName = "python";
        start.Arguments = "scripts//spin.py";
        start.UseShellExecute = false;
        start.CreateNoWindow = false;
        start.RedirectStandardOutput = false;
        start.RedirectStandardError = false;

        Debug.WriteLine($"Is python process null: {PythonProcess is null}");
        if(PythonProcess is not null)
        {
            Debug.WriteLine($"Process with ID: {PythonProcess.Id} is going to be killed");

            PythonProcess.Kill(true);
        }

        var process = Process.Start(start);       
        var message = $"New process rised with ID: {process?.Id}";
        Debug.WriteLine(message);
                
        return message;
    
    }

      [HttpGet()]
    [Route("[action]")]
    public ActionResult<string> TurnOffTree()
    {
        ProcessStartInfo start = new ProcessStartInfo();
        start.FileName = "python";
        start.Arguments = "scripts//treeoff.py"; //Path.Combine("scripts", "script.py");
        start.UseShellExecute = false;
        start.CreateNoWindow = false;
        start.RedirectStandardOutput = false;
        start.RedirectStandardError = false;

        Debug.WriteLine($"Is python process null: {PythonProcess is null}");
        if(PythonProcess is not null)
        {
            Debug.WriteLine($"Process with ID: {PythonProcess.Id} is going to be killed");

            PythonProcess.Kill(true);
        }

        var process = Process.Start(start);       
        var message = $"New process rised with ID: {process?.Id}";
        Debug.WriteLine(message);
                
        return message;
    
    }

}
