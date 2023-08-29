using CrimeReportApp.Data;
using CrimeReportApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CrimeReportApp.Repositories
{
    public class CrimeRepo : ICrimeRepo
    {
        private readonly CrimeContext _context;
        

        public CrimeRepo(CrimeContext context)
        {
            _context = context;
            
        }

        public async Task ReportCrime(CrimeReport crime)
        {
           
            // Map the CrimeModel to CrimeEntity
            CrimeEntity crimeEntity = new CrimeEntity
            {
                // Map the properties accordingly
                ReportID = 0,
                TypeID = crime.typeID,
                UserID = crime.userID,
                CrimeDescription = crime.description,
                ReportDate = crime.reportDate,
                Latitude = crime.Latitude,
                Longitude = crime.Longitude,
                CreatedAt = DateTime.Now

            };

            // Add the crimeEntity to the DbContext and save changes
            _context.CrimeReports.Add(crimeEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CrimeReport>> GetAllCrimeReports()
        {
            List<CrimeReport> crimeReports = await _context.CrimeReports
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
                .ToListAsync();

            return crimeReports;
        }
        List<CrimeReport> ICrimeRepo.GetCrimesByTypeId(int typeId)
        {

            List<CrimeReport> crimes = _context.CrimeReports
                .Where(c => c.TypeID == typeId)
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

            return crimes;
        }

        public async Task<bool> UpdateCrime(CrimeReport crime)
        {
            CrimeEntity report = await _context.CrimeReports.FindAsync(crime.ID);
            if (report == null)
                return false;
            //Update report with new values
            report.CrimeDescription = crime.description;
            report.TypeID = crime.typeID;
            report.ReportDate = crime.reportDate;
            report.Latitude = crime.Latitude;
            report.Longitude = crime.Longitude;
            await _context.SaveChangesAsync();
            return true;

        }
        public async Task<bool> DeleteCrime(int reportId)
        {
            CrimeEntity crime = await _context.CrimeReports.FindAsync(reportId);
            if (crime == null)
                return false;

            _context.CrimeReports.Remove(crime);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

