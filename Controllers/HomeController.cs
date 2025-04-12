using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
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

        [HttpGet("getAll")]
        public IActionResult GetAllUser()
        {
            try
            {
                var result = userService.GetAllUsers();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var result = userService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateUser(Guid id, [FromBody] UpdateUserDto userDto)
        {
            try
            {
                userService.UpdateUser(id, userDto);
                return Ok("User Updated Successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id: guid}")]
        public IActionResult DeleteUser(Guid id)
        {
            try
            {
                userService.DeleteUser(id);
                return Ok("User deleted successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{id:guid}")]
        public IActionResult UpdateResult(Guid id, [FromBody] UpdateUserDto dto)
        {
            try
            {
                userService.UpdateUser(id, dto);
                return Ok("User updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }

}