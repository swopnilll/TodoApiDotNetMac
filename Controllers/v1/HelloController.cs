using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystemApi.Controllers.v1;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class HelloController:ControllerBase {

    [HttpGet("", Name = "Hello")]    
    public string Hello() {
        return "Hello World";
    }

}