using EmployeeManagementSystemApi.Data;
using EmployeeManagementSystemApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystemApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly DataContextDapper _dataContextDapper;
        private readonly DataContextEf _dataContextEFCore;

        public UserController(DataContextDapper dataContextDapper, DataContextEf dataContextEFCore)
        {
            _dataContextDapper = dataContextDapper;

            _dataContextEFCore = dataContextEFCore;
        }

        [HttpGet("TestConnectionDapper")]
        public ActionResult<DateTime> TestConnectionDapper()
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

        [HttpGet("TestConnectionEFCore")]
        public ActionResult<IEnumerable<User>> TestConnectionEFCore()
        {
            try
            {
                return Ok(_dataContextEFCore.Users.ToList());
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
