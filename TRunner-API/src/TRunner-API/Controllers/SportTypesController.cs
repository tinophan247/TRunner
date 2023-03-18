using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TRunner.Application.Services.Interfaces;

namespace TRunner_API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("v{version:apiVersion}/sport-types")]
    [ApiVersion("1")]
    public class SportTypesController : ControllerBase
    {
        #region Private Members
        private readonly ISportTypeService _sportTypeService;
        #endregion

        #region Constructors
        public SportTypesController(ISportTypeService sportTypeService)
        {
            _sportTypeService = sportTypeService;
        }
        #endregion

        [HttpGet]
        public async Task<ActionResult> GetListOfSportTypes()
        {
            var result = await _sportTypeService.GetAllSportTypes();

            return Ok(result);
        }
    }
}