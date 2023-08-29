using CrimeReportApp.Models;
using CrimeReportApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CrimeReportApp.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CrimeTypeController : ControllerBase
    {
        private readonly ICrimeTypeService _crimeTypeService;

        public CrimeTypeController(ICrimeTypeService crimeTypeService)
        {
            _crimeTypeService = crimeTypeService;
        }

        [HttpGet]
        public IActionResult GetAllCrimeTypes()
        {
            List<CrimeType> crimeTypes = _crimeTypeService.GetAllCrimeTypes();
            return Ok(crimeTypes);
        }

        [HttpGet("{typeId}/crimes")]
        public IActionResult GetCrimesByTypeId(int typeId)
        {
            List<CrimeReport> crimes = _crimeTypeService.GetCrimesByTypeId(typeId);
            return Ok(crimes);
        }
    }
}
