using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UI
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ILogger<TransactionController> _logger;
        private readonly ITransactionService _transactionService;

        public TransactionController(ILogger<TransactionController> logger, ITransactionService transactionService)
        {
            _logger = logger;
            _transactionService = transactionService;
        }

        [HttpPost("CreateTransaction")]
        public IActionResult CreateTransaction([FromBody] TransactionDTO transaction)
        {
            try
            {
                Transaction newTransaction = _transactionService.CreateTransaction(transaction);
                return Ok(newTransaction);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao criar transação: {ex.Message}");
                return BadRequest("Erro ao criar transação");
            }
        }
    }
}