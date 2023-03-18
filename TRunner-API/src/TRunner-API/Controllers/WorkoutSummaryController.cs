using Microsoft.AspNetCore.Mvc;
using TRunner.Application.Middleware.JwtAuthorization;
using TRunner.Application.Services.Interfaces;
using TRunner.Domain.Models.Request;

namespace TRunner_API.Controllers
{
    [Authorize]
    [Route("v{version:apiVersion}")]
    [ApiController]
    [ApiVersion("1")]
    public class WorkoutSummaryController : ControllerBase
    {
        #region Private Members
        private readonly IWorkoutSummaryService _workoutSummaryService;
        #endregion

        #region Constructors
        public WorkoutSummaryController(IWorkoutSummaryService workoutSummaryService)
        {
            _workoutSummaryService = workoutSummaryService;
        }
        #endregion

        [HttpPost("workout-summary")]
        public async Task<IActionResult> CreateWorkoutSummary(CreateWorkoutSummaryRequest request)
        {
            var response = await _workoutSummaryService.CreateWorkoutSummary(request);
            return Created("/workout-summary", response);
        }
    }
}
