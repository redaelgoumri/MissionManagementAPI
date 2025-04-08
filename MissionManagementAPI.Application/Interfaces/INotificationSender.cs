namespace MissionManagementAPI.Application.Interfaces
{
    public interface INotificationSender
    {
        Task SendToUserAsync(string email, string message);
    }
}
