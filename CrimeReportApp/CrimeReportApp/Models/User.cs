using CrimeReportApp.Data;

namespace CrimeReportApp.Models
{
    public class User
    {

        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsOptedIn { get; set; } //Is opted in for notifications default value is true.
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public DateTime CreatedAt { get; set; }


    }
}
