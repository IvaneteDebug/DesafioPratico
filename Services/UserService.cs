using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    private readonly UserRepository userRepository;
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly NotificationService _notificationService;

        public UserService(IUserRepository userRepository, NotificationService notificationService)
        {
            _userRepository = userRepository;
            _notificationService = notificationService;
        }

        public void ValidateTransaction(User user, decimal amount)
        {
            if (user.GetUserType() == UserType.Merchant)
            {
                throw new ArgumentException("Usuário do tipo lojista não autorizado a realizar transação");
            }

            if (user.GetBalance().CompareTo(amount) < 0)
            {
                throw new ArgumentException("Saldo insuficiente");
            }
        }

        public User FindUserById(long id)
        {
            return _userRepository.FindUserById(id) ?? throw new ArgumentException("Usuário não encontrado");
        }

        public User CreateUser(UserDto user)
        {
            User newUser = new User(user);
            _userRepository.SaveUser(newUser);
            return newUser;
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public void SaveUser(User user)
        {
            _userRepository.SaveUser(user);
        }
    }
}