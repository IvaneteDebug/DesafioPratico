using Conclusao_Projeto.Domain;

namespace Conclusao_Projeto.Services
{
    public interface INotificationService
    {
        void SendNotification(User user, string message);
    }
}
