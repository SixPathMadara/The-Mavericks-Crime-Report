
namespace CrimeTests
{
    [TestClass]
    public class CrimeServiceTests
    {
        private readonly Mock<ICrimeRepo> _mockCrimeRepo;
        private readonly CrimeService _crimeService;

        public CrimeServiceTests()
        {
            _mockCrimeRepo = new Mock<ICrimeRepo>();
            _crimeService = new CrimeService(_mockCrimeRepo.Object);
        }

        [TestMethod]
        public async Task Test_ReportCrime_ShouldCallRepoMethod()
        {
            // Arrange
            var crime = new CrimeReport
            {
                // Set up crime properties
                 ID = 1,
                userID = 123,
                typeID = 456,
                description = "This is a crime report.",
                reportDate = DateTime.Now,
                
                
            };
            var crime2 = new CrimeReport
            {
                ID = 2,
                userID = 101,
                typeID = 3,
                description = "Another crime description",
                reportDate = DateTime.Now.AddDays(-1)
               
            };
            // Act
            await _crimeService.ReportCrime(crime);
            await _crimeService.ReportCrime(crime2); ;

            // Assert
            _mockCrimeRepo.Verify(repo => repo.ReportCrime(It.IsAny<CrimeReport>()), Times.Once);
        }

        [TestMethod]
        public async Task Test_GetAllCrimeReports_ShouldReturnListOfCrimeReports()
        {
            // Arrange
            var expectedReports = new List<CrimeReport>
            {
               new CrimeReport
                {
                    ID = 1,
                    userID = 100,
                    typeID = 2,
                    description = "A crime description",
                    reportDate = DateTime.Now,
                  
                },
                new CrimeReport
                {
                    ID = 2,
                    userID = 101,
                    typeID = 3,
                    description = "Another crime description",
                    reportDate = DateTime.Now.AddDays(-1),
                    
                }
            };

            _mockCrimeRepo.Setup(repo => repo.GetAllCrimeReports()).ReturnsAsync(expectedReports);

            // Act
            var result = await _crimeService.GetAllCrimeReports();

            // Assert
            Assert.IsNotNull(result);
            CollectionAssert.AreEqual(expectedReports, result);
        }
    }
}