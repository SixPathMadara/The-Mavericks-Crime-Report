using CrimeReportApp.Data;
using CrimeReportApp.Models;

namespace CrimeReportApp.Repositories
{
    public class TypeRepo : ICrimeTypeRepo
    {
        private readonly CrimeContext _context;

        public TypeRepo(CrimeContext context)
        {
            _context = context;
        }

        public List<CrimeType> GetAllCrimeTypes()
        {
            List<CrimeType> crimeTypes = _context.CrimeTypes
                .Select(ct => new CrimeType
                {
                    ID = ct.TypeID,
                    crimeType = ct.Crimetype,
                    
                })
                .ToList();

            return crimeTypes;
        }

        public CrimeType GetCrimeTypeById(int typeId)
        {
            CrimeType crimeType = _context.CrimeTypes
                .Where(ct => ct.TypeID == typeId)
                .Select(ct => new CrimeType
                {
                    ID = ct.TypeID,
                    crimeType = ct.Crimetype,
                    
                })
                .FirstOrDefault();

            return crimeType;
        }

        public List<CrimeReport> GetCrimesByTypeId(int typeId)
        {
            var crimes = _context.CrimeReports
              .Where(r => r.TypeID == typeId)
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
    }
}
