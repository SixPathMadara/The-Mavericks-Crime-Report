using CrimeReportApp.Data;
using CrimeReportApp.Models;
using CrimeReportApp.Services;

namespace CrimeReportApp.Repositories
{
    public class CrimeStats : ICrimeStatsRepo
    {
        private readonly CrimeContext _db;
        private readonly ILocationService _locationService;

        public CrimeStats(CrimeContext db, ILocationService locationService)
        {
            _db = db;
            _locationService = locationService;
        }
        //Get crimereports by location
        public async Task<List<CrimeReport>> GetCrimeReportsByLocationAsync(decimal latitude, decimal longitude, double radius)
        {

            var reports = _db.CrimeReports
                            .ToList() // Fetch all data from the database
                            .Where(r => _locationService.CalculateDistance(latitude, longitude, r.Latitude, r.Longitude) <= radius)
                            .Select(c => new CrimeReport
                            {
                                ID = c.ReportID,
                                typeID = c.TypeID,
                                userID = c.UserID,
                                description = c.CrimeDescription,
                                reportDate = c.ReportDate,
                                Latitude = c.Latitude,
                                Longitude = c.Longitude,
                                CreatedAt = c.CreatedAt
                            })
                            .ToList(); // Perform calculations in memory after data is fetched

            return await Task.FromResult(reports);
        }
        //get crimereports by type and location
        public async Task<List<CrimeReport>> GetCrimesByTypeAndLocationAsync(int typeId, decimal latitude, decimal longitude, double radius)
        {

            var crimes = _db.CrimeReports
                .ToList()
                .Where(r => r.TypeID == typeId && _locationService.CalculateDistance(latitude, longitude, r.Latitude, r.Longitude) <= radius)
                .Select(c => new CrimeReport
                {
                    ID = c.ReportID,
                    typeID = c.TypeID,
                    userID = c.UserID,
                    description = c.CrimeDescription,
                    reportDate = c.ReportDate,
                    Latitude = c.Latitude,
                    Longitude = c.Longitude,
                    CreatedAt = c.CreatedAt
                })
                .ToList();

            return await Task.FromResult(crimes);
        }
        //get crime reports made by a user.
        public async Task<List<CrimeReport>> GetCrimeReportsByUserAsync(int userId)
        {
            var reports = _db.CrimeReports
                .Where(r => r.UserID == userId)
                .Select(c => new CrimeReport
                {
                    ID = c.ReportID,
                    typeID = c.TypeID,
                    userID = c.UserID,
                    description = c.CrimeDescription,
                    reportDate = c.ReportDate,
                    Latitude = c.Latitude,
                    Longitude = c.Longitude,
                    CreatedAt = c.CreatedAt
                })
                .ToList();

            return await Task.FromResult(reports);
        }
        //Get a percentage of if crimereports went up or down based on acertain interval
        public async Task<double> GetCrimeStatisticsChangeAsync(string interval)
        {
            var startDate = interval switch
            {
                "week" => DateTime.Now.AddDays(-7),
                "month" => DateTime.Now.AddMonths(-1),
                "year" => DateTime.Now.AddYears(-1),
                _ => throw new ArgumentException("Invalid interval."),
            };
            var totalCount = _db.CrimeReports.Count();
            var reportsInInterval = _db.CrimeReports
                .Count(r => r.ReportDate >= startDate);

            var percentageChange = ((totalCount - reportsInInterval) / (double)totalCount) * 100;

            return await Task.FromResult(percentageChange);
        }
        //Get a percentage of if crimereports went up or down based on  certain interval and crimetype
        public async Task<double> GetCrimeStatisticsChangeByCrimeTypeAsync(int crimeTypeId, string interval)
        {
            var startDate = interval switch
            {
                "week" => DateTime.Now.AddDays(-7),
                "month" => DateTime.Now.AddMonths(-1),
                "year" => DateTime.Now.AddYears(-1),
                _ => throw new ArgumentException("Invalid interval."),
            };

            var totalCount = _db.CrimeReports.Count(r => r.TypeID == crimeTypeId);
            var reportsInInterval = _db.CrimeReports
                .Count(r => r.TypeID == crimeTypeId && r.CreatedAt >= startDate);

            var percentageChange = ((totalCount - reportsInInterval) / (double)totalCount) * 100;

            return await Task.FromResult(percentageChange);
        }
        // get percentage of crimereports in a location in certain time interval.
        public async Task<double> GetCrimeStatisticsChangeByLocationAndIntervalAsync(decimal latitude, decimal longitude, double radius, string interval)
        {
            var startDate = interval switch
            {
                "week" => DateTime.Now.AddDays(-7),
                "month" => DateTime.Now.AddMonths(-1),
                "year" => DateTime.Now.AddYears(-1),
                _ => throw new ArgumentException("Invalid interval."),
            };

            var totalCount = _db.CrimeReports
                .ToList()
                .Count(r => _locationService.CalculateDistance(latitude, longitude, r.Latitude, r.Longitude) <= radius);

            var reportsInInterval = _db.CrimeReports
                .ToList()
                .Count(r => _locationService.CalculateDistance(latitude, longitude, r.Latitude, r.Longitude) <= radius
                         && r.CreatedAt >= startDate);

            var percentageChange = ((totalCount - reportsInInterval) / (double)totalCount) * 100;

            return await Task.FromResult(percentageChange);
        }
        //return count of whatever
        public async Task<int> GetReadNotificationCountAsync(int userId)
        {
            var readNotificationCount = _db.UserNotifications
                .ToList()
                .Count(un => un.UserID == userId && un.IsRead);

            return await Task.FromResult(readNotificationCount);
        }

        public async Task<int> GetCrimeCountAsync()
        {
            var totalCount = _db.CrimeReports.Count();
            return await Task.FromResult(totalCount);
        }

        public async Task<int> GetCrimeCountbytypeCountAsync(int typeId)
        {
            var totalCount = _db.CrimeReports.Count(r => r.TypeID == typeId);
            return await Task.FromResult(totalCount);
        }

        public async Task<int> GetCrimeCountByLocation(decimal latitude, decimal longitude, double radius)
        {
            var totalCount = _db.CrimeReports.ToList()
                .Count(r => _locationService.CalculateDistance(latitude, longitude, r.Latitude, r.Longitude) <= radius);
            return await Task.FromResult(totalCount);
        }

        public async Task<int> GetCrimeCountByTypeAndLocation(int typeId, decimal latitude, decimal longitude, double radius)
        {
            var totalCount = _db.CrimeReports.ToList()
                .Count(r => r.TypeID == typeId && _locationService.CalculateDistance(latitude, longitude, r.Latitude, r.Longitude) <= radius);
            return await Task.FromResult(totalCount);
        }
    }
}