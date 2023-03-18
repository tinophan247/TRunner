using Microsoft.AspNetCore.Mvc;
using TRunner.Core.Resources;

namespace TRunner_API.Controllers
{
    [ApiController]
    [Route("v{version:apiVersion}/health-check")]
    [ApiVersion("1")]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetHealthCheckStatus()
        {
            return Ok(Resources.HealthCheck_Success);
        }
    }
}