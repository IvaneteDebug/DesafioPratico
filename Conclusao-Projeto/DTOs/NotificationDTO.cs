namespace Conclusao_Projeto.DTOs
{
    public class NotificationDTO
    {
        public string Email { get; }
        public string Message { get; }

        public NotificationDTO(string email, string message)
        {
            Email = email;
            Message = message;
        }
    }
}