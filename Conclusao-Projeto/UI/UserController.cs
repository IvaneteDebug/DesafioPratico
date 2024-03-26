using Conclusao_Projeto.DTOs;
using Conclusao_Projeto.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Conclusao_Projeto.UI
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _logger = logger;
        }

        [HttpPost("CreateUser")]
        public IActionResult CreateUser(UserDTO user)
        {
            try
            {
                _logger.LogInformation("Valor do campo UserType recebido no JSON: {0}", user.Type);

                var newUser = _userService.CreateUser(user);

                return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);
            }
            catch (UserValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao processar a criação do usuário");
                return StatusCode(500, "Internal Server Error");
            }
        }

        //Obtém os detalhes de um usuário com base no ID fornecido
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                var user = _userService.FindUserById(id);
                if (user == null)
                    return NotFound();

                return Ok(user);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        //Obtém uma lista de todos os usuários cadastrados no sistema
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _userService.GetAllUsers();
                return Ok(users);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
