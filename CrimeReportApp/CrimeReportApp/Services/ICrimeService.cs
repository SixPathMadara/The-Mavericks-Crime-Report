using CrimeReportApp.Models;

namespace CrimeReportApp.Services
{
    public interface ICrimeService
    {
        Task<List<CrimeReport>> GetAllCrimeReports();
        Task ReportCrime(CrimeReport crime);
        Task<bool> UpdateCrime(CrimeReport crime);
        Task<bool> DeleteCrime(int reportId);
    }
}
