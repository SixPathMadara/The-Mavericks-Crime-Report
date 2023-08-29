
namespace CrimeTests
{
    [TestClass]
    public class UserServiceTests
    {
        private readonly Mock<IUserRepo> _mockUserRepo;
        private readonly UserService _userService;

        public UserServiceTests()
        {
            _mockUserRepo = new Mock<IUserRepo>();
            _userService = new UserService(_mockUserRepo.Object);
        }

        [TestMethod]
        public async Task Test_Register_ShouldCallRepoMethod()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                Username = "john_doe",
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Password = "password123"
            };

            // Act
            await _userService.Register(user);

            // Assert
            _mockUserRepo.Verify(repo => repo.Register(It.IsAny<User>()), Times.Once);
        }

        [TestMethod]
        public async Task Test_Login_ShouldCallRepoMethodAndReturnResult()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                Username = "john_doe",
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Password = "password123"
            };

            // Set up the UserRepository to return a result when the Login method is called
            _mockUserRepo.Setup(repo => repo.Login(It.IsAny<User>())).ReturnsAsync(true);

            // Act
            var result = await _userService.Login(user);

            // Assert
            _mockUserRepo.Verify(repo => repo.Login(It.IsAny<User>()), Times.Once);
            Assert.IsTrue(result); // Make sure the result returned by the service is as expected
        }

        [TestMethod]
        public async Task Test_GetUserById_ShouldCallRepoMethodAndReturnUser()
        {
            // Arrange
            int userId = 1;
            var expectedUser = new User
            {
                Id = 1,
                Username = "john_doe",
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Password = "password123"
            };

            // Set up the UserRepository to return the expectedUser when the GetUserById method is called
            _mockUserRepo.Setup(repo => repo.GetUserById(userId)).ReturnsAsync(expectedUser);

            // Act
            var result = await _userService.GetUserById(userId);

            // Assert
            _mockUserRepo.Verify(repo => repo.GetUserById(userId), Times.Once);
            Assert.IsNotNull(result); // Make sure a user is returned
            Assert.AreEqual(expectedUser.Id, result.Id); // Check if the returned user is the expectedUser
            //Can add more assertions for other properties of the user if needed
        }
    }
}
