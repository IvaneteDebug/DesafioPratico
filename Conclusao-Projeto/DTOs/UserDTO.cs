using Conclusao_Projeto.Domain;

namespace Conclusao_Projeto.DTOs
{
    public class UserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public decimal Balance { get; set; }
        public string Password{ get; set; }
        public UserType Type { get; set; }

        public UserDTO() { }

        public UserDTO(string firstName, string document, string email, decimal balance,   UserType type)
        {
            FirstName = firstName;
            Document = document;
            Email = email;
            Balance = balance;
            this.Type = type;
        }
    }
}
