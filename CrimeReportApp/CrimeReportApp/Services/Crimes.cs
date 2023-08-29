using CrimeReportApp.Data;
using CrimeReportApp.Models;
using CrimeReportApp.Repositories;

namespace CrimeReportApp.Services
{
    /// <summary>
    /// For statistics but can be used for other things, things that should have been in their own respective things
    /// </summary>
    public class Crimes : ICrimes
    {
        private readonly ICrimeStatsRepo _crimeStats;
        public Crimes(ICrimeStatsRepo crimeStats) 
        {
            _crimeStats = crimeStats;
        }

        public async Task<int>GetCrimeCountAsync()
        {
           return await _crimeStats.GetCrimeCountAsync();
        }

        public async Task<int> GetCrimeCountByLocation(decimal latitude, decimal longitude, double radius)
        {
            return await _crimeStats.GetCrimeCountByLocation(latitude,longitude,radius); 
        }

        public async Task<int> GetCrimeCountByTypeAndLocation(int typeId, decimal latitude, decimal longitude, double radius)
        {
            return await _crimeStats.GetCrimeCountByTypeAndLocation(typeId,latitude,longitude,radius);
        }

        public async Task<int> GetCrimeCountbytypeCountAsync(int typeId)
        {
            return await _crimeStats.GetCrimeCountbytypeCountAsync(typeId);
        }

        public async Task<List<CrimeReport>> GetCrimeReportsByLocationAsync(decimal latitude, decimal longitude, double radius)
        {
            return await _crimeStats.GetCrimeReportsByLocationAsync(latitude,longitude,radius);
        }

        public async Task<List<CrimeReport>> GetCrimeReportsByUserAsync(int userId)
        {
            return await _crimeStats.GetCrimeReportsByUserAsync(userId);
        }

        public async Task<List<CrimeReport>>GetCrimesByTypeAndLocationAsync(int typeId, decimal latitude, decimal longitude, double radius)
        {
            return await _crimeStats.GetCrimesByTypeAndLocationAsync(typeId,latitude,longitude,radius);
        }

        public async Task<double> GetCrimeStatisticsChangeAsync(string interval)
        {
            return await _crimeStats.GetCrimeStatisticsChangeAsync(interval);
        }

        public async Task<double> GetCrimeStatisticsChangeByCrimeTypeAsync(int crimeTypeId, string interval)
        {
            return await _crimeStats.GetCrimeStatisticsChangeByCrimeTypeAsync(crimeTypeId,interval);
        }

        public async Task<double> GetCrimeStatisticsChangeByLocationAndIntervalAsync(decimal latitude, decimal longitude, double radius, string interval)
        {
            return await _crimeStats.GetCrimeStatisticsChangeByLocationAndIntervalAsync(latitude,longitude,radius,interval);
        }

        public async Task<int> GetReadNotificationCountAsync(int userId)
        {
            return await _crimeStats.GetReadNotificationCountAsync(userId);
        }
    }
}
