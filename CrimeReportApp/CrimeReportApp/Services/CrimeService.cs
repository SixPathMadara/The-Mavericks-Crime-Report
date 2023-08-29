using CrimeReportApp.Models;
using CrimeReportApp.Repositories;

namespace CrimeReportApp.Services
{
    public class CrimeService : ICrimeService
    {
        private readonly ICrimeRepo _crimeRepository;

        public CrimeService(ICrimeRepo crimeRepository)
        {
            _crimeRepository = crimeRepository;
        }

        public async Task ReportCrime(CrimeReport crime)
        {
            await _crimeRepository.ReportCrime(crime);
        }

       
        public async Task<List<CrimeReport>> GetAllCrimeReports()
        {
            return await _crimeRepository.GetAllCrimeReports();
        }
        public async Task<bool>UpdateCrime(CrimeReport crime)
        {
            return await _crimeRepository.UpdateCrime(crime);
        }

        public async Task<bool> DeleteCrime(int reportId)
        {
            return await _crimeRepository.DeleteCrime(reportId);
        }
       
    }
}
