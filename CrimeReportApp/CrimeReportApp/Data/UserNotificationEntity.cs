namespace CrimeReportApp.Data
{
    public class UserNotificationEntity
    {
        public int UserNotificationID { get; set; }
        public int UserID { get; set; }
        public int NotificationID { get; set; }
        public bool IsRead { get; set; }
        public NotificationEntity Notification { get; set; }
    }
}
