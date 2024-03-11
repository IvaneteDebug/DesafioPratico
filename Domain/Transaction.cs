using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Transaction
    {
        public long Id { get; private set}
        public decimal Amount { get; private set; }
        public User Sender { get; private set; }
        public User Receiver { get; private set; }

        public class Transaction { }

        public Transaction(long id, decimal amount, User sender, User receiver)
        {
            Id = id;
            Amount = amount;
            Sender = sender;
            Receiver = receiver;
        }
    }
}