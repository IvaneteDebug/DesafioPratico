using Conclusao_Projeto.Domain;
using Conclusao_Projeto.DTOs;
using Conclusao_Projeto.Repository;
using Newtonsoft.Json.Linq;

namespace Conclusao_Projeto.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly INotificationService _notificationService;

        public TransactionService(
            IUserService userService,
            IUserRepository userRepository,
            ITransactionRepository transactionRepository,
            INotificationService notificationService
        )
        {
            _userService = userService;
            _userRepository = userRepository;
            _transactionRepository = transactionRepository;
            _notificationService = notificationService;
        }

        public Transaction CreateTransaction(TransactionDTO transaction)
        {
            if (transaction.SenderId <= 0 || transaction.ReceiverId <= 0)
            {
                throw new ArgumentException("IDs de remetente ou destinatário inválidos");
            }

            User sender = _userService.FindUserById(transaction.SenderId);
            User receiver = _userService.FindUserById(transaction.ReceiverId);

            if (sender == null || receiver == null)
            {
                throw new ArgumentException("Usuário remetente ou destinatário não encontrado");
            }

            _userService.ValidateTransaction(sender, transaction.Value);

            Transaction newTransaction = new Transaction
            {
                Amount = transaction.Value,
                Sender = sender,
                Receiver = receiver,
                Timestamp = DateTime.Now
            };

            sender.Balance -= transaction.Value;
            receiver.Balance += transaction.Value;

            _userRepository.SaveUser(sender);
            _userRepository.SaveUser(receiver);
            _transactionRepository.SaveTransaction(newTransaction);

            _notificationService.SendNotification(sender, "Transferência realizada com sucesso");
            _notificationService.SendNotification(receiver, "Você recebeu uma transferência");

            return newTransaction;
        }

        public List<Transaction> GetAllTransactions()
        {
            return _transactionRepository.GetAllTransactions();
        }

        public bool AuthorizeTransaction(User sender, decimal amount)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client
                    .GetAsync("https://run.mocky.io/v3/5794d450-d2e2-4412-8131-73d0293ac1cc")
                    .Result;

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
