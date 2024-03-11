using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public interface ITransactionService
    {
         Transaction CreateTransaction(TransactionDTO transaction);
         bool AuthorizeTransaction(User sender, decimal value);

    }
}