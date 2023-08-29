namespace CrimeReportApp.Data
{
    
    public class CrimeEntity
    {

        public int ReportID { get; set; }
        public int UserID { get; set; } //Foreign key
        public int TypeID { get; set; } //Foreign key
        public string CrimeDescription { get; set; }
        public DateTime?  ReportDate { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public DateTime CreatedAt { get; set; }
        

        public UserEntity User { get; set; } // Navigation property
        public TypeEntity crimeType { get; set; } // Navigation property
        public List<AttachmentEntity> Attachments { get; set; }  // Navigation property

    }
}
