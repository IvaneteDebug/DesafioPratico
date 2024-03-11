using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class NotificationService
    {
        public void SendNotification(User user, string message)
        {
            string email = user.GetEmail();
            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent("", Encoding.UTF8, "application/json");
                var response = client.PostAsync("https://run.mocky.io/notify", content).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new ArgumentException("Serviço de Notificação está fora do ar");
                }
            }
        }
    }
}