using CrimeReportApp.Models;

namespace CrimeReportApp.Repositories
{
    public interface ICrimeTypeRepo
    {
        List<CrimeType> GetAllCrimeTypes();
        CrimeType GetCrimeTypeById(int typeId);
        List<CrimeReport> GetCrimesByTypeId(int typeId);
    }
}
