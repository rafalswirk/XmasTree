using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using XmasTreeService.Core.LedControl.PythonControl;
using Service = XmasTreeService.Services;

namespace XmasTreeServiceWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class XmasTreeController : ControllerBase
{
    Service.XmasTreeService _service = new Service.XmasTreeService(new PythonLedControl());

    [HttpGet(Name = "GetLightingModes")]
    [Route("")]
    public IEnumerable<string> Get()
    {
        return _service.GetAllLightingModes().Select(m => m.Id).ToList();
    }
    
}