using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        public Long Id { get; private set; }
        public string FistName { get; private set; }
        public string Lastname { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public decimal Balance { get; private set; }
        public UserType userType { get; set; }

        public class User { }

        public User(Long id, string firtname, string lastname, string email, decimal balance, UserType userType)
        {
            Id = id;
            FistName = firtname;
            Lastname = lastname;
            Email = email;
            Balance = balance;
            UserType = userType;
        }
    }
}