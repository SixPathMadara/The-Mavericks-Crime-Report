using CrimeReportApp.Models;
using CrimeReportApp.Repositories;
using CrimeReportApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;


namespace CrimeReportApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrimeReportController : ControllerBase
    {
        private readonly ICrimeService _crimeReportService;
        private readonly ILocationService _locationService;
        private readonly double _maxRadiusKm = 12;
        public CrimeReportController(ICrimeService crimeReportService, ILocationService locationService)
        {
            _crimeReportService = crimeReportService;
            _locationService = locationService;
        }
       
        [HttpGet]
        public async Task<IActionResult> GetAllCrimeReports()
        {
            var crimeReports = await _crimeReportService.GetAllCrimeReports();
            return Ok(crimeReports);
        }
        [HttpPost("reportingUsingQuery")]
        public async Task<IActionResult> ReportCrime(int UserId,int TypeId,string Description, DateTime ReportDate, decimal latitude,decimal longitude)
        {
            CrimeReport report = new()
            {
                userID = UserId,
                typeID = TypeId,
                description = Description,
                reportDate = ReportDate,
                Latitude = latitude,
                Longitude = longitude,
            };
            await _crimeReportService.ReportCrime(report);
            //// Calculate users in the reported crime area
            //var usersInArea = _locationService.CalculateUsersInArea(report.CrimeReport.Latitude, report.CrimeReport.Longitude, _maxRadiusKm);
            //// Remove the userID of the user reporting the crime from the usersInArea list
            //usersInArea.Remove(report.CrimeReport.userID);
            //// Notify the identified users about the reported crime
            //foreach (var userId in usersInArea)
            //{
            //    // Notify users here (e.g., send push notifications, emails, etc.)
            //}
            return Ok();
        }
        //use this to report crime
        [HttpPost]
        public async Task<IActionResult> ReportCrime(CrimeReport report)
        {
            
            await _crimeReportService.ReportCrime(report);
            //// Calculate users in the reported crime area
            //var usersInArea = _locationService.CalculateUsersInArea(report.CrimeReport.Latitude, report.CrimeReport.Longitude, _maxRadiusKm);
            //// Remove the userID of the user reporting the crime from the usersInArea list
            //usersInArea.Remove(report.CrimeReport.userID);
            //// Notify the identified users about the reported crime
            //foreach (var userId in usersInArea)
            //{
            //    // Notify users here (e.g., send push notifications, emails, etc.)
            //}
            return Ok();
        }
        [HttpPost("CrimeWithUserLocayion")]
        public async Task<IActionResult> ReportCrime([FromBody] CrimeReportWithUserLocation report)
        {
            // Verify if the user is in the same area as the reported crime
            bool isUserInArea = _locationService.IsUserInCrimeReportArea(
                new User { Latitude = report.UserLatitude, Longitude = report.UserLongitude },
                report.CrimeReport,
                _maxRadiusKm);
            if (!isUserInArea)
            {
                return BadRequest("You are not in the area to report this crime.");
            }
            
            await _crimeReportService.ReportCrime(report.CrimeReport);
            // Calculate users in the reported crime area
            var usersInArea = _locationService.CalculateUsersInArea(report.CrimeReport.Latitude, report.CrimeReport.Longitude, _maxRadiusKm);
            // Remove the userID of the user reporting the crime from the usersInArea list
            usersInArea.Remove(report.CrimeReport.userID);
            // Notify the identified users about the reported crime
            foreach (var userId in usersInArea)
            {
                // Notify users here (e.g., send push notifications, emails, etc.)
            }
            return Ok();
        }


        [HttpPut("editReport")]
        public async Task<IActionResult> UpdateCrime(CrimeReport crimeReport)
        {
          var done =  await _crimeReportService.UpdateCrime(crimeReport);
            if (done == true) return Ok();
            return BadRequest();
        }
        [HttpDelete("deleteREport/{id}")]
        public async Task<IActionResult> DeleteCrime(int reportId)
        {
            var done = await _crimeReportService.DeleteCrime(reportId); 
            if (done == true) return Ok();
            return BadRequest();
        }
    }

}
