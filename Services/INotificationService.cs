using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public interface INotificationService
    {
        void SendNotification(User user, string message);
    }
}