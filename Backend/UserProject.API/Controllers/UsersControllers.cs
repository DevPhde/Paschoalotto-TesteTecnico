using ExternalServices;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using UserProject.API.Entities;
using UserProject.API.Exceptions;
using UserProject.API.Interfaces.Hub;
using UserProject.API.Interfaces.Users;

namespace UserProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersControllers : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly IUsersHub _hub;
        public UsersControllers(IConfiguration configuration, IUsersHub hub)
        {
            _configuration = configuration;
            _hub = hub;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers([FromServices] IGetAllUsersHandler _handler)
        {
            try
            {
                List<User> users = await _handler.Handle();
                return Ok(users);

            } catch (Exception)
            {
                return StatusCode(500, new { Message = "Erro interno. Tente novamente mais tarde." });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User?>> GetUserById([FromServices] IGetUserByIdHandler _handler, [FromRoute] int id)
        {
            try
            {
                User user = await _handler.Handle(id);
                return Ok(user);

            } catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            } catch (Exception)
            {
                return StatusCode(500, new { Message = "Erro interno. Tente novamente mais tarde." });
            }
        }

        [HttpPost("{numberOfUsers}")]
        public async Task<ActionResult<User>> CreateUser([FromServices] ICreateUsersHandler _handler, [FromRoute] int numberOfUsers)
        {
            try
            {
                List<User> users = await _handler.Handle(numberOfUsers);
                await _hub.SendUsers();
                return CreatedAtAction("GetAllUsers", null, users);

            } catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser([FromServices] IRemoveUserHandler _handler, [FromRoute] int id)
        {
            try
            {
                await _handler.Handle(id);
                await _hub.SendUsers();
                return Ok(new { Message = "Usuário removido com sucesso!" });

            } catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            } catch (Exception)
            {
                return StatusCode(500, new { Message = "Erro interno. Tente novamente mais tarde." });
            }
        }
    }
}
