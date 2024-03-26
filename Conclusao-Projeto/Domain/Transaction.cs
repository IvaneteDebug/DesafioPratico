namespace Conclusao_Projeto.Domain
{
    public class Transaction
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public User Sender { get; set; }
        public User Receiver { get; set; }
        public DateTime Timestamp { get; set; }

        public Transaction() { }

        public Transaction(decimal amount, User sender, User receiver)
        {
            Amount = amount;
            Sender = sender;
            Receiver = receiver;
            Timestamp = DateTime.Now;
        }
    }
}
