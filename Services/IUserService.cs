using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public interface IUserService
    {
        void ValidateTransaction(User user, decimal amount);
        User FindUserById(long id);
        User CreateUser(UserDto user);
        List<User> GetAllUsers();
        void SaveUser(User user);
    }
}