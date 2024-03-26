using Conclusao_Projeto.Domain;
using Conclusao_Projeto.DTOs;
using Conclusao_Projeto.Repository;

namespace Conclusao_Projeto.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository =
                userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public void ValidateTransaction(User user, decimal amount)
{
    if (user.Type == UserType.Merchant)
    {
        throw new ArgumentException("Usuário do tipo lojista não autorizado a realizar transação");
    }

    if (user.Balance < amount)
    {
        throw new ArgumentException("Saldo insuficiente");
    }
}

        public User FindUserById(int id)
        {
            var user = _userRepository.FindUserById(id);
            if (user == null)
            {
                throw new ArgumentException("Usuário não encontrado");
            }
            return user;
        }

        public User CreateUser(UserDTO userDto)
        {
            var existingUser = _userRepository.FindUserByDocument(userDto.Document);
            if (existingUser != null)
            {
                throw new ArgumentException("Já existe um usuário com o mesmo documento");
            }

            User newUser = new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Document = userDto.Document,
                Email = userDto.Email,
                Balance = userDto.Balance,
                Password = userDto.Password,
                Type = userDto.Type
            };

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
