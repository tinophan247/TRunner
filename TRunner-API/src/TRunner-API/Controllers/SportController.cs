using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TRunner.Application.Services.Interfaces;
using TRunner.Domain.Extensions;
using TRunner.Domain.Models.Request;

namespace TRunner_API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("v{version:apiVersion}/sports")]
    [ApiVersion("1")]
    public class SportController : ControllerBase
    {
        #region Private Members
        private ILogger _logger;
        private readonly ISportService _sportService;
        #endregion

        #region Constructors
        public SportController(ISportService sportService, ILoggerFactory loggerFactory)
        {
            _sportService = sportService;
            _logger = loggerFactory.CreateLogger(nameof(SportController));
        }
        #endregion

        [HttpGet]
        public async Task<ActionResult> GetListOfSportsWithPaging([FromQuery] PaginationRequest request)
        {
            try
            {
                var result = await _sportService.GetListOfSportsWithPaging(request);

                return result != null
                    ? StatusCode(StatusCodes.Status200OK, result)
                    : StatusCode(StatusCodes.Status500InternalServerError, null);
            }
            catch (Exception ex)
            {
                var error = $"GetListOfSportsWithPaging - {Helpers.BuildErrorMessage(ex)}";
                _logger.LogError(error);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateSport(CreateSportRequest request)
        {
            var result = await _sportService.CreateSport(request);

            return Created("/create-sport", result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateSport([FromQuery] int id, SportRequestModel request)
        {
            try
            {
                var result = await _sportService.UpdateSport(id, request);

                if (result == 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Sport name has already existed!");
                }

                return result != null
                    ? StatusCode(StatusCodes.Status200OK, result)
                    : StatusCode(StatusCodes.Status500InternalServerError, null);
            }
            catch (Exception ex)
            {
                var error = $"UpdateSport - {Helpers.BuildErrorMessage(ex)}";
                _logger.LogError(error);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
