using Microsoft.Identity.Client;

namespace CrimeReportApp.Models
{

    public class CrimeReport
    {

        public int ID { get; set; }
        public int userID { get; set; }
        public int typeID { get; set; }
        public string description { get; set; }
        public DateTime? reportDate { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public DateTime CreatedAt {get; set;}
        

    }
}
