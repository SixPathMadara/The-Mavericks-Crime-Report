namespace CrimeReportApp.Data
{
    public class TypeEntity
    {
        public int TypeID { get; set; }
        public string Crimetype { get; set; }
        public ICollection<CrimeEntity> Crimes { get; set; } // Navigation property
    }
}
