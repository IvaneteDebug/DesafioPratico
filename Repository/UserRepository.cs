using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
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

        public User FindUserById(long id)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Id == id);
        }
    }
}
