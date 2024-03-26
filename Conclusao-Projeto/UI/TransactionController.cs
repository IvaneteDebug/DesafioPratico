using Conclusao_Projeto.Domain;
using Conclusao_Projeto.DTOs;
using Conclusao_Projeto.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Conclusao_Projeto.UI
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ILogger<TransactionController> _logger;
        private readonly ITransactionService _transactionService;
        private readonly IUserService _userService;

        public TransactionController(
            ILogger<TransactionController> logger,
            ITransactionService transactionService,
            IUserService userService
        )
        {
            _logger = logger;
            _transactionService = transactionService;
            _userService = userService;
        }

        // Cria uma nova transação com base nos dados fornecidos.
        [HttpPost("CreateTransaction")]
        public IActionResult CreateTransaction([FromBody] TransactionDTO transaction)
        {
            try
            {
                var transactionDTO = new TransactionDTO
                {
                    Value = transaction.Value,
                    SenderId = transaction.SenderId,
                    ReceiverId = transaction.ReceiverId
                };

                var newTransaction = _transactionService.CreateTransaction(transactionDTO);

                return Ok("Transferência concluída com sucesso!");
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Erro ao criar transação: {ex.Message}");
                return BadRequest($"Erro ao criar transação: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao criar transação: {ex.Message}");
                return StatusCode(500, "Erro interno ao processar a transação");
            }
        }
    }
}

