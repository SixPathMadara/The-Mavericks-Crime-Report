using CrimeReportApp.Models;
using CrimeReportApp.Repositories;

namespace CrimeReportApp.Services
{
    public class CrimeTypeService : ICrimeTypeService
    {
        private readonly ICrimeTypeRepo _crimeTypeRepository;
        private readonly ICrimeRepo _crimeRepository;

        public CrimeTypeService(ICrimeTypeRepo crimeTypeRepository, ICrimeRepo crimeRepository)
        {
            _crimeTypeRepository = crimeTypeRepository;
            _crimeRepository = crimeRepository;
        }

        public List<CrimeType> GetAllCrimeTypes()
        {
            return _crimeTypeRepository.GetAllCrimeTypes();
        }

        public CrimeType GetCrimeTypeById(int typeId)
        {
            return _crimeTypeRepository.GetCrimeTypeById(typeId);
        }

        public List<CrimeReport> GetCrimesByTypeId(int typeId)
        {
            return _crimeRepository.GetCrimesByTypeId(typeId);
        }

    }
}
