namespace Conclusao_Projeto.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal Balance { get; set; }
        public UserType Type { get; set; }

        public User(){}
        public User(int id, string lastName, string firstName,string email, decimal balance, string password, UserType type)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            Email = email;
            Balance = balance;
            Password = password;
            Type = type;
        }
        

        
    }
}
