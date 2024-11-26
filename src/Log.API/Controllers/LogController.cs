

using Log.Application.Services;
using Log.Contract.Entities;
using Log.Contract.Shared.ExampleData;
using Log.Domain.Abstractions;
using Log.Domain.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.API.Controllers
{
    [EnableCors("AllowAll")]
    [ApiController]
    [Route("[controller]")]
    public class LogController : Controller
    {
        private readonly ILogger<LogController> _logger;
        private readonly ILogService _logService;
        public LogController(ILogger<LogController> logger, ILogService logService)
        {
            _logger = logger;
            _logService = logService;
        }
       
        [HttpGet("/getone")]
        public IActionResult GetOne()
        {
            Task<List<LogModel>> logs = _logService.GetAll();
            return Ok(logs.Result[0]);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            Task<List<LogModel>> logs = _logService.GetAll();
            return Ok(logs.Result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LogModel log)
        {
            await _logService.Create(log);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] LogModel log)
        {
            var reponse = await _logService.Update(log);
            return Ok(reponse);
        }
    }
}