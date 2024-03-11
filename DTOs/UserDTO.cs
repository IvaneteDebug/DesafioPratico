using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTOs
{
    public record UserDTO(string FirtName, string Lastname, string Document, decimal Balance, string Email, string Password) { }

}
void User(UserDTO data)
{
    FirtName = data.FirtName();
    Lastname = data.Lastname();
    Balance = data.Balance();
    UserType = data.UserType();
}