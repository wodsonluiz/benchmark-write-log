using System.Threading;
using System.Threading.Tasks;
using BenchmarkWriteLog.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace BenchmarkWriteLog.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RegistrosController: ControllerBase
    {
        private readonly IWriteLogService _service;

        public RegistrosController(IWriteLogService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]LogRequest logRequest, CancellationToken cancellationToken)
        {
            var wasWritten = await _service.WriteLogV2Async(logRequest);

            if(wasWritten)
                return StatusCode(200);

            return StatusCode(500);
        }
    }
}