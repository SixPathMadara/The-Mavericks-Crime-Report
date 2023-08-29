using CrimeReportApp.Data;
using CrimeReportApp.Models;
namespace CrimeReportApp.Repositories
{
    public interface ICrimeStatsRepo
    {
        Task<List<CrimeReport>> GetCrimeReportsByLocationAsync(decimal latitude, decimal longitude, double radius);
        Task<List<CrimeReport>> GetCrimesByTypeAndLocationAsync(int typeId, decimal latitude, decimal longitude, double radius);
        Task<List<CrimeReport>> GetCrimeReportsByUserAsync(int userId);
        Task<double> GetCrimeStatisticsChangeAsync(string interval);
        Task<double> GetCrimeStatisticsChangeByCrimeTypeAsync(int crimeTypeId, string interval);

        Task<double> GetCrimeStatisticsChangeByLocationAndIntervalAsync(decimal latitude, decimal longitude, double radius, string interval);

        Task<int> GetReadNotificationCountAsync(int userId);
        Task<int> GetCrimeCountAsync();
        Task<int> GetCrimeCountbytypeCountAsync(int typeId);
        Task<int> GetCrimeCountByLocation(decimal latitude, decimal longitude, double radius);
        Task<int> GetCrimeCountByTypeAndLocation(int typeId, decimal latitude, decimal longitude, double radius);

    }
}
