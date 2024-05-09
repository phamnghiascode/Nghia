using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Nghia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllStudents()
        {

            string[] StudentList = ["nghia", "trang", "blabla"];
            return Ok(StudentList);
        }
    }
}
