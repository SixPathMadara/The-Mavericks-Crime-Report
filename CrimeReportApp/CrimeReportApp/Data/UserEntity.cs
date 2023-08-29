namespace CrimeReportApp.Data
{
    public class UserEntity
    {
       
        public int UserID { get; set; }
        public string UserName { get; set; } 
        public string UserFirstName { get; set; }
        public string UserSurname { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public bool IsOptedIn { get; set; } //Is opted in for notifications default value is true.
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; } 
        public DateTime CreatedAt { get; set; }
        public ICollection<CrimeEntity> Crimes { get; set; } // Navigation property


    }
}
