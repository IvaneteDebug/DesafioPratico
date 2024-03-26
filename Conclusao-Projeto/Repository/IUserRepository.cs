using Conclusao_Projeto.Domain;

namespace Conclusao_Projeto.Repository
{
    public interface IUserRepository
    {
        User FindUserByDocument(string document);
        User FindUserById(int id);
        List<User> GetAllUsers();
        void SaveUser(User user);
    }
}
