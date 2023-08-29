using CrimeReportApp.Models;

namespace CrimeReportApp.Repositories
{
    public interface INotificationRepo
    {
        Task<Notification> GetByIdAsync(int id);
        Task<IEnumerable<Notification>> GetAllAsync();
        Task CreateAsync(Notification notification);
        Task UpdateAsync(Notification notification);
        Task DeleteAsync(int id);
    }
}
