using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_intro.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            string[] names = { "Eli", "Jale", "Pervin" };
            return Ok(names);
        }

        //[HttpGet("GetEmployeeByTestId")] - spesifik çağırırıqsa bu qaydada çağırmalıyıq.Amma hər metod üçün yazmaq lazımdır.        
        //[Route("GetEmployeeByTestId")] - və yaxud spesifik bu cürə
        [HttpGet]
        public IActionResult GetById(int? id)
        {
            if (id is null) return BadRequest();
            return Ok("Eli - " + " " + id);
        }
    }
}
