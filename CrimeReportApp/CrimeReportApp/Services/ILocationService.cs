using CrimeReportApp.Models;
namespace CrimeReportApp.Services
{
    public interface ILocationService
    {
         List<int> CalculateUsersInArea(decimal targetLatitude, decimal targetLongitude, double radiusKm);
        
         bool IsUserInCrimeReportArea(User user, CrimeReport crimeReport, double maxRadiusKm);
        double CalculateDistance(decimal lat1, decimal lon1, decimal lat2, decimal lon2);
    }
}
