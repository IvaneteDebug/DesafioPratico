using Conclusao_Projeto.Domain;
using Conclusao_Projeto.Persistence;
using Conclusao_Projeto.Repository;

namespace Dev.DesafioPratico.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly UserDbContext _dbContext;

        public TransactionRepository(UserDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public List<Transaction> GetAllTransactions()
        {
            return _dbContext.Transactions.ToList();
        }

        public Transaction FindTransactionById(int id)
        {
            return _dbContext.Transactions.FirstOrDefault(t => t.Id == id);
        }

        public void SaveTransaction(Transaction transaction)
        {
            _dbContext.Transactions.Add(transaction);
            _dbContext.SaveChanges();
        }
    }
}