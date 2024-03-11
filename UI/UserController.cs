using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UI
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("CreateUser")]
        public IActionResult CreateUser(UserDTO user)
        {
            try
            {
                User newUser = _userService.CreateUser(user);
                return new ObjectResult(newUser) { StatusCode = (int)HttpStatusCode.Created };
            }
            catch (Exception ex)
            {
                // Trate o erro conforme necessário, por exemplo, registre no log
                return BadRequest($"Erro ao criar usuário: {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                List<User> users = _userService.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                // Trate o erro conforme necessário, por exemplo, registre no log
                return BadRequest($"Erro ao obter usuários: {ex.Message}");
            }
        }
    }
}