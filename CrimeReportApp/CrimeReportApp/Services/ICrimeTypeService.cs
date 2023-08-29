using CrimeReportApp.Models;

namespace CrimeReportApp.Services
{
    public interface ICrimeTypeService
    {
        List<CrimeType> GetAllCrimeTypes();
        CrimeType GetCrimeTypeById(int typeId);
        List<CrimeReport> GetCrimesByTypeId(int typeId);
    }
}
