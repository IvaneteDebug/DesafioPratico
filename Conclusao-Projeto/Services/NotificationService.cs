using System.Text;

using Conclusao_Projeto.Domain;

namespace Conclusao_Projeto.Services
{
    public class NotificationService : INotificationService
    {
        public void SendNotification(User user, string message)
        {
            string email = user.Email;
            
            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(message, Encoding.UTF8, "application/json"); 
                var response = client.PostAsync("https://run.mocky.io/v3/5794d450-d2e2-4412-8131-73d0293ac1cc", content).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException("Serviço de Notificação está fora do ar");
                }
            }
        }
    }
}
