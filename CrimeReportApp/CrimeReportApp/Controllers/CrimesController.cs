using CrimeReportApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrimeReportApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CrimesController : ControllerBase
    {
        private readonly ICrimes _crimesService;

        public CrimesController(ICrimes crimesService)
        {
            _crimesService = crimesService;
        }

        [HttpGet("crimeReportsByLocation")]
        public async Task<IActionResult> GetCrimeReportsByLocation(decimal latitude, decimal longitude, double radius)
        {
            var reports = await _crimesService.GetCrimeReportsByLocationAsync(latitude, longitude, radius);
            return Ok(reports);
        }

        [HttpGet("crimesByTypeAndLocation")]
        public async Task<IActionResult> GetCrimesByTypeAndLocation(int typeId, decimal latitude, decimal longitude, double radius)
        {
            var crimes = await _crimesService.GetCrimesByTypeAndLocationAsync(typeId, latitude, longitude, radius);
            return Ok(crimes);
        }

        [HttpGet("crimeReportsByUser")]
        public async Task<IActionResult> GetCrimeReportsByUser(int userId)
        {
            var reports = await _crimesService.GetCrimeReportsByUserAsync(userId);
            return Ok(reports);
        }

        [HttpGet("crimeStatisticsChange")]
        public async Task<IActionResult> GetCrimeStatisticsChange(string interval)
        {
            var percentageChange = await _crimesService.GetCrimeStatisticsChangeAsync(interval);
            return Ok(percentageChange);
        }

        [HttpGet("crimeStatisticsChangeByCrimeType")]
        public async Task<IActionResult> GetCrimeStatisticsChangeByCrimeType(int crimeTypeId, string interval)
        {
            var percentageChange = await _crimesService.GetCrimeStatisticsChangeByCrimeTypeAsync(crimeTypeId, interval);
            return Ok(percentageChange);
        }

        [HttpGet("crimeStatisticsChangeByLocationAndInterval")]
        public async Task<IActionResult> GetCrimeStatisticsChangeByLocationAndInterval(decimal latitude, decimal longitude, double radius, string interval)
        {
            var percentageChange = await _crimesService.GetCrimeStatisticsChangeByLocationAndIntervalAsync(latitude, longitude, radius, interval);
            return Ok(percentageChange);
        }

        [HttpGet("readNotificationCount")]
        public async Task<IActionResult> GetReadNotificationCount(int userId)
        {
            var readNotificationCount = await _crimesService.GetReadNotificationCountAsync(userId);
            return Ok(readNotificationCount);
        }
        [HttpGet("CrimeReportsCount")]
        public async Task<IActionResult> GetCrimeCountAsync()
        {
            var Count = await _crimesService.GetCrimeCountAsync();
            return Ok(Count);
        }
        [HttpGet("CrimeCountbytype")]
        public async Task<IActionResult> GetCrimeCountbytypeCountAsync(int typeId)
        {
            var Count = await _crimesService.GetCrimeCountbytypeCountAsync(typeId);
            return Ok(Count);
        }
        [HttpGet("CrimeCountByLocation")]
        public async Task<IActionResult> GetCrimeCountByLocation(decimal latitude, decimal longitude, double radius)
        {
            var Count = await _crimesService.GetCrimeCountByLocation(latitude, longitude,radius);
            return Ok(Count);
        }
        [HttpGet("CrimeCountByTypeAndLocation")]
        public async Task<IActionResult> GetCrimeCountByTypeAndLocation(int typeId, decimal latitude, decimal longitude, double radius)
        {
            var totalCount = await _crimesService.GetCrimeCountByTypeAndLocation(typeId,  latitude,  longitude, radius);
            return Ok(totalCount);
        }
    }
}
