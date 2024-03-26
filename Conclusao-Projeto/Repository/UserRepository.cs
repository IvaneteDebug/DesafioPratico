using Conclusao_Projeto.Domain;
using Conclusao_Projeto.Persistence;

namespace Conclusao_Projeto.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _dbContext;

        public UserRepository(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User FindUserByDocument(string document)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Document == document);
        }

        public User FindUserById(int id)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public List<User> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public void SaveUser(User user)
        {
            var existingUser = _dbContext.Users.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser != null)
            {
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.Document = user.Document;
                existingUser.Balance = user.Balance;
                existingUser.Email = user.Email;
                existingUser.Type = user.Type;
                existingUser.Password = user.Password;
            }
            else
            {
                _dbContext.Users.Add(user);
            }

            _dbContext.SaveChanges();
        }
    }
}
