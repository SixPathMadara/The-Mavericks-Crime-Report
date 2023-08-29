namespace CrimeReportApp.Models
{
    public class Notification
    {
        public int NotificationID { get; set; }
        public int SenderUserID { get; set; }
        public string NotificationContent { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
