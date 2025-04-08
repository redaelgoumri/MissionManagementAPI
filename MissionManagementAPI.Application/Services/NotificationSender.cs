using System;
using System.Threading.Tasks;
using MissionManagementAPI.Application.Interfaces;

namespace MissionManagementAPI.Infrastructure.Services
{
    public class NotificationSender : INotificationSender
    {
        public Task SendToUserAsync(string email, string message)
        {
            // Simulate in-session delivery
            Console.WriteLine($"🔔>> Notification sent to {email}: {message}");
            return Task.CompletedTask;
        }
    }
}
