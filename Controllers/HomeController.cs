using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Dtos;
using WebApplication1.Entities;
using WebApplication1.Services.Interface;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/home")]
    public class HomeController(IUserService userService) : Controller
    {

        [HttpPost("Add")]
        public IActionResult AddUser([FromBody] InsertUserDto userDto)
        {
            try
            {
               userService.AddUser(userDto);
               return Ok("User added successfully");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}