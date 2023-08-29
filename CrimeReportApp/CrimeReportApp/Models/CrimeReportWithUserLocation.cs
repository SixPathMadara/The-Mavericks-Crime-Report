namespace CrimeReportApp.Models
{
    public class CrimeReportWithUserLocation
    {
        public CrimeReport CrimeReport { get; set; }
        public decimal UserLatitude { get; set; }
        public decimal UserLongitude { get; set; }
    }
}
