using Conclusao_Projeto.DTOs;
using Conclusao_Projeto.Domain;

namespace Conclusao_Projeto.Services
{
    public interface ITransactionService
    {
        Transaction CreateTransaction(TransactionDTO transaction);
        bool AuthorizeTransaction(User sender, decimal amount);
        List<Transaction> GetAllTransactions();
    }
}