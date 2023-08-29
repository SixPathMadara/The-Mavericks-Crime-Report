namespace CrimeReportApp.Data
{
    public class NotificationEntity
    {
        public int NotificationID { get; set; }
        public int SenderUserID { get; set; }
        public string NotificationContent { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<UserNotificationEntity> UserNotifications { get; set; }
    }
}
