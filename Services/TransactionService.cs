using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    private UserService userService;
    private TransactionRepository transactionRepository;
    public class TransactionService
    {
        private readonly IUserService userService;
        private readonly UserRepository userRepository;
        private readonly NotificationService notificationService;

        public TransactionService(IUserService userService, IUserServer userServer, UserRepository userRepository, NotificationService notificationService)
        {
            this.userService = userService;
            this.userRepository = userRepository;
            this.notificationService = notificationService;
        }

        public Transaction CreateTransaction(TransactionDTO transaction)
        {
            User sender = this.userServer.FindUserById(transaction.SenderId);
            User receiver = this.userService.FindUserById(transaction.ReceiverId);

            this.userService.ValidateTransaction(sender, transaction.Value);

            bool isAuthorized = this.AuthorizeTransaction(sender, transaction.Value);
            if (!isAuthorized)
            {
                throw new ArgumentException("Transação não Autorizada");
            }

            Transaction newTransaction = new Transaction();
            newTransaction.Amount = transaction.Amount;
            newTransaction.Sender = sender;
            newTransaction.Receiver = receiver;
            newTransaction.Timestamp = DateTime.Now;

            sender.Balance -= transaction.Value;
            receiver.Balance += transaction.Value;

            this.userRepository.SaveTransaction(newTransaction);
            this.userRepository.SaveUser(sender);
            this.userRepository.SaveUser(receiver);

            this.notificationService.SendNotification(sender, "Transação realizada com sucesso");
            this.notificationService.SendNotification(receiver, "Transação recebida com sucesso");

            return newTransaction;
        }

        public bool AuthorizeTransaction(User sender, decimal value)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync("https://run.mocky.io/v3/54dc2cf1-3add-45b5-b5a9-6bf7e7f1f4a6").Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = response.Content.ReadAsStringAsync().Result;
                    var message = JObject.Parse(responseBody)["message"].ToString();
                    return message.Equals("Autorizado", StringComparison.OrdinalIgnoreCase);
                }
                else
                {
                    return false;
                }
            }
        }
    }
}