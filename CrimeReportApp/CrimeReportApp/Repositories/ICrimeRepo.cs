using CrimeReportApp.Models;

namespace CrimeReportApp.Repositories
{
    public interface ICrimeRepo
    {
        Task<List<CrimeReport>> GetAllCrimeReports();
        List<CrimeReport> GetCrimesByTypeId(int typeId);
        Task ReportCrime(CrimeReport crime);
        Task <bool> UpdateCrime(CrimeReport crime);
        Task<bool> DeleteCrime(int reportId);
    }
}
