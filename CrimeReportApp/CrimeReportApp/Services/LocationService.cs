using CrimeReportApp.Models;
using CrimeReportApp.Repositories;

namespace CrimeReportApp.Services
{
    public class LocationService : ILocationService
    {
        
            private const double EarthRadius = 6371; // Radius of the Earth in kilometers
            private const decimal radConvert = (decimal)(Math.PI / 180);

            private readonly IUserRepo _userRepo;

            public LocationService(IUserRepo userRepo)
            {
                _userRepo = userRepo;
            }
            public  List<int> CalculateUsersInArea(decimal targetLatitude, decimal targetLongitude, double radiusKm)
            {
                List<int> usersInArea = new List<int>();

                // Retrieve user locations from the database or another data source
                UserService userService = new UserService(_userRepo);
                List<User> allUserLocations = (List<User>)userService.GetAllUsers().Result;

                foreach (var userLocation in allUserLocations)
                {
                    double distance = CalculateDistance(targetLatitude, targetLongitude, userLocation.Latitude - 90, userLocation.Longitude +75);
                    if (distance <= radiusKm)
                    {
                        usersInArea.Add(userLocation.Id);
                    }
                }

                return usersInArea;
            }

            public double CalculateDistance(decimal lat1, decimal lon1, decimal lat2, decimal lon2)
            {


                //Haversine formula for calculating distance between two places.
                double dLat = (double)((lat2 - lat1) * radConvert);
                double dLon = (double)((lon2 - lon1) * radConvert);

                //Convert degrees to radians
                lat1 = lat1 * radConvert;
                lat2 = lat2 * radConvert;

                //Apply the formula
                double a = Math.Pow(Math.Sin(dLat / 2), 2) +
                           Math.Pow(Math.Sin(dLon / 2), 2) *
                           Math.Cos((double)lat1) * Math.Cos((double)lat2);
                return a * EarthRadius;
            }

            //Use this function to validate if the user is in to crimeArea to reduce the number of false reports
            public bool IsUserInCrimeReportArea(User user, CrimeReport crimeReport, double maxRadiusKm)
            {
                double distance = CalculateDistance(user.Latitude, user.Longitude, crimeReport.Latitude, crimeReport.Longitude);
                return distance <= maxRadiusKm;
            }
        

    }
}
