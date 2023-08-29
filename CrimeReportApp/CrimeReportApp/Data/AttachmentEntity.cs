namespace CrimeReportApp.Data
{
    public class AttachmentEntity
    {
        public int AttachmentID { get; set; }
        public int ReportID { get; set; }
        public string FileType { get; set; }
        public byte[] FileContent { get; set; }
        public CrimeEntity Crime { get; set; }
    }
}
