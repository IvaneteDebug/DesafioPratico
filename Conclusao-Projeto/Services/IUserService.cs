using Conclusao_Projeto.DTOs;
using Conclusao_Projeto.Domain;

namespace Conclusao_Projeto.Services
{
    public interface IUserService
    {
        void ValidateTransaction(User user, decimal amount);
        User FindUserById(int id);
        User CreateUser(UserDTO user);
        List<User> GetAllUsers();
        void SaveUser(User user);
    }
}
