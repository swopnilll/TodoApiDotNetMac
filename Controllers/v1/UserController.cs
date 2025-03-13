using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystemApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly DataContextDapper _dataContextDapper;

        public UserController(IConfiguration configuration)
        {
            _dataContextDapper = new DataContextDapper(configuration);
        }

        [HttpGet("TestConnection")]
        public ActionResult<DateTime> TestConnection()
        {
            try
            {
                return Ok(_dataContextDapper.LoadDataSingle<DateTime>("SELECT GETDATE()"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("GetUsers")]
        public ActionResult<string> GetUsers([FromQuery] string testValue)
        {
            if (string.IsNullOrWhiteSpace(testValue))
            {
                return BadRequest("testValue is required.");
            }

            return Ok($"Hello World {testValue}");
        }
    }
}
