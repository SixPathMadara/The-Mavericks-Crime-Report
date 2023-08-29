
namespace CrimeTests
{
    [TestClass]
    public class CrimeTypeServiceTests
    {
        private readonly Mock<ICrimeTypeRepo> _mockCrimeTypeRepo;
        private readonly Mock<ICrimeRepo> _mockCrimeRepo;
        private readonly CrimeTypeService _crimeTypeService;

        public CrimeTypeServiceTests()
        {
            _mockCrimeTypeRepo = new Mock<ICrimeTypeRepo>();
            _mockCrimeRepo = new Mock<ICrimeRepo>();
            _crimeTypeService = new CrimeTypeService(_mockCrimeTypeRepo.Object, _mockCrimeRepo.Object);
        }

        [TestMethod]
        public void Test_GetAllCrimeTypes_ShouldReturnListOfCrimeTypes()
        {
            // Arrange
            var expectedCrimeTypes = new List<CrimeType>
            {
                new CrimeType { ID = 1, crimeType = "Robbery" },
                new CrimeType { ID = 2, crimeType = "Assault" },
                // Add more crime types as needed
            };

            _mockCrimeTypeRepo.Setup(repo => repo.GetAllCrimeTypes()).Returns(expectedCrimeTypes);

            // Act
            var result = _crimeTypeService.GetAllCrimeTypes();

            // Assert
            _mockCrimeTypeRepo.Verify(repo => repo.GetAllCrimeTypes(), Times.Once);
            CollectionAssert.AreEqual(expectedCrimeTypes, result.ToList());
        }

        [TestMethod]
        public void Test_GetCrimeTypeById_ShouldReturnCrimeType()
        {
            // Arrange
            int typeId = 1;
            var expectedCrimeType = new CrimeType { ID = typeId, crimeType = "Robbery" };

            _mockCrimeTypeRepo.Setup(repo => repo.GetCrimeTypeById(typeId)).Returns(expectedCrimeType);

            // Act
            var result = _crimeTypeService.GetCrimeTypeById(typeId);

            // Assert
            _mockCrimeTypeRepo.Verify(repo => repo.GetCrimeTypeById(typeId), Times.Once);
            Assert.AreEqual(expectedCrimeType, result);
        }

        [TestMethod]
        public void Test_GetCrimesByTypeId_ShouldReturnListOfCrimeReports()
        {
            // Arrange
            int typeId = 1;
            var expectedCrimeReports = new List<CrimeReport>
            {
                new CrimeReport 
                {      
                    ID = 1,
                    userID = 123,
                    typeID = 456,
                    description = "This is a crime report.",
                    reportDate = DateTime.Now,
                   
                },
                new CrimeReport 
                {
                    ID = 1,
                    userID = 123,
                    typeID = 456,
                    description = "This is a crime report.",
                    reportDate = DateTime.Now,
                  
                },
                // Add more crime reports as needed
            };

            _mockCrimeRepo.Setup(repo => repo.GetCrimesByTypeId(typeId)).Returns(expectedCrimeReports);

            // Act
            var result = _crimeTypeService.GetCrimesByTypeId(typeId);

            // Assert
            _mockCrimeRepo.Verify(repo => repo.GetCrimesByTypeId(typeId), Times.Once);
            CollectionAssert.AreEqual(expectedCrimeReports, result.ToList());
        }
    }
}
