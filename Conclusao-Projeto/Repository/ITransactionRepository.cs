using Conclusao_Projeto.Domain;

namespace Conclusao_Projeto.Repository
{
    public interface ITransactionRepository
    {
        List<Transaction> GetAllTransactions();
        Transaction FindTransactionById(int id);
        void SaveTransaction(Transaction transaction);
    }
}
