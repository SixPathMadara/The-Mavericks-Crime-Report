using CrimeReportApp.Data;
using CrimeReportApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CrimeReportApp.Repositories
{
    public class NotificationRepo : INotificationRepo
    {
        private readonly CrimeContext _context;

        public NotificationRepo(CrimeContext context)
        {
            _context = context;
        }

        public async Task<Notification> GetByIdAsync(int id)
        {
            var notificationEntity = await _context.Notifications.FindAsync(id);
            if (notificationEntity == null)
            {
                return null;
            }

            return new Notification
            {
                NotificationID = notificationEntity.NotificationID,
                SenderUserID = notificationEntity.SenderUserID,
                NotificationContent = notificationEntity.NotificationContent,
                CreatedAt = notificationEntity.CreatedAt
            };
        }

        public async Task<IEnumerable<Notification>> GetAllAsync()
        {
            var notificationEntities = await _context.Notifications.ToListAsync();

            return notificationEntities.Select(notificationEntity => new Notification
            {
                NotificationID = notificationEntity.NotificationID,
                SenderUserID = notificationEntity.SenderUserID,
                NotificationContent = notificationEntity.NotificationContent,
                CreatedAt = notificationEntity.CreatedAt
            }).ToList();
        }

        public async Task CreateAsync(Notification notification)
        {
            
            _context.Notifications.Add(new NotificationEntity
            {
                NotificationID = notification.NotificationID,
                SenderUserID = notification.SenderUserID,
                NotificationContent = notification.NotificationContent,
                CreatedAt = DateTime.Now    
            });
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Notification notification)
        {
            var notificationEntity = ConvertToEntity(notification);
            _context.Entry(notificationEntity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var notification = await _context.Notifications.FindAsync(id);
            if (notification != null)
            {
                _context.Notifications.Remove(notification);
                await _context.SaveChangesAsync();
            }
        }
        private Notification ConvertToModel(NotificationEntity entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new Notification
            {
                NotificationID = entity.NotificationID,
                SenderUserID = entity.SenderUserID,
                NotificationContent = entity.NotificationContent,
                CreatedAt = entity.CreatedAt
            };
        }

        private NotificationEntity ConvertToEntity(Notification model)
        {
            return new NotificationEntity
            {
                NotificationID = model.NotificationID,
                SenderUserID = model.SenderUserID,
                NotificationContent = model.NotificationContent,
                CreatedAt = model.CreatedAt
            };
        }
    }
}