using CrimeReportApp.Data;
using CrimeReportApp.Models;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace CrimeReportApp.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly CrimeContext _context;
        //Hashpassword for security reasons.
        private string myHashPassword( string password)
        {
            string HashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            return HashedPassword;
        }

        public UserRepo(CrimeContext context)
        {
            _context = context;
            
        }

        public async Task Register(User user)
        {
            // Map the UserModel to UserEntity
            UserEntity userEntity = new UserEntity
            {
                // Map the properties accordingly
                UserID = user.Id,
                UserName = user.Username,
                UserFirstName = user.FirstName,
                UserSurname = user.LastName,
                UserEmail = user.Email,
                UserPassword = myHashPassword(user.Password),
                IsOptedIn=user.IsOptedIn,
                Latitude = user.Latitude,
                Longitude = user.Longitude,
                CreatedAt = DateTime.Now
            };

            // Add the userEntity to the DbContext and save changes
            _context.Users.Add(userEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Login(User user)
        {
            // Retrieve the userEntity based on the provided username
            UserEntity userEntity = await _context.Users.FirstOrDefaultAsync(u => u.UserName == user.Username);

            // Check if the userEntity is found and the password matches
            bool isAuthenticated = userEntity != null && userEntity.UserPassword == user.Password;

            return isAuthenticated;
        }
        public async Task<User> GetUserById(int userId)
        {
            UserEntity userEntity = await _context.Users.FindAsync(userId);

            if (userEntity == null)
                return null;

            User user = new User
            {
                Id = userEntity.UserID,
                Username = userEntity.UserName,
                FirstName = userEntity.UserFirstName,
                LastName = userEntity.UserSurname,
                Email = userEntity.UserEmail,
                IsOptedIn = userEntity.IsOptedIn,
                Latitude = userEntity.Latitude + 90,
                Longitude = userEntity.Longitude - 75,
                Password = "disabled",
            };

            return user;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            UserEntity userEntity = await _context.Users.FirstOrDefaultAsync(u => u.UserEmail == email);

            if (userEntity == null)
                return null;

            User user = new User
            {
                Id = userEntity.UserID,
                Username = userEntity.UserName,
                FirstName = userEntity.UserFirstName,
                LastName = userEntity.UserSurname,
                Email = userEntity.UserEmail,
                IsOptedIn = userEntity.IsOptedIn,
                Latitude = userEntity.Latitude + 90,
                Longitude = userEntity.Longitude - 75,
                Password = "disabled",
            };

            return user;
        }

        public async Task<bool> RegisterByEmail(string email, string password)
        {
            // Check if the user with the given email already exists
            bool isEmailTaken = await _context.Users.AnyAsync(u => u.UserEmail == email);
            

            
            // If the email is available, create a new user
            UserEntity userEntity = new UserEntity
            {
                UserID = 0,
                UserEmail = email,
                UserPassword = myHashPassword(password),
                UserName = email,
                UserFirstName = "Jane",
                UserSurname = "Doe",
                CreatedAt = DateTime.Now
            };

            _context.Users.Add(userEntity);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> LoginByEmail(string email, string password)
        {
            // Retrieve the userEntity based on the provided email
            UserEntity userEntity = await _context.Users.FirstOrDefaultAsync(u => u.UserEmail == email);

            // Check if the userEntity is found and the password matches
            bool isAuthenticated = userEntity != null && BCrypt.Net.BCrypt.Verify(password,userEntity.UserPassword);

            return isAuthenticated;
        }
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            List<User> users = await _context.Users.Select(userEntity => new User
            {
                Id = userEntity.UserID,
                Username = userEntity.UserName,
                FirstName = userEntity.UserFirstName,
                LastName = userEntity.UserSurname,
                Email = userEntity.UserEmail,
                IsOptedIn = userEntity.IsOptedIn,
                Latitude = userEntity.Latitude + 90,
                Longitude = userEntity.Longitude - 75,
                Password = "disabled"
            }).ToListAsync();

            return users;
        }
        public async Task<bool> UpdateUser(User user)
        {
            UserEntity userEntity = await _context.Users.FindAsync(user.Id);
            if (userEntity == null)
                return false;

            // Update the userEntity with the new values
            userEntity.UserName = user.Username;
            //userEntity.UserFirstName = user.FirstName;
            //userEntity.UserSurname = user.LastName;
            userEntity.UserEmail = user.Email;
            userEntity.IsOptedIn = user.IsOptedIn;
            //userEntity.Latitude = user.Latitude;
            //userEntity.Longitude = user.Longitude;
            userEntity.UserPassword = myHashPassword(user.Password);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUser(int userId)
        {
            UserEntity userEntity = await _context.Users.FindAsync(userId);
            if (userEntity == null)
                return false;

            _context.Users.Remove(userEntity);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> RegisterByEmail(User user)
        {
            // Check if the user with the given email already exists
            bool isEmailTaken = await _context.Users.AnyAsync(u => u.UserEmail == user.Email);

            // If the email is available, create a new user
            UserEntity userEntity = new UserEntity
            {
                UserID = 0,
                UserEmail = user.Email,
                UserPassword = myHashPassword(user.Password),
                UserName = user.Email,
                UserFirstName = user.FirstName,
                UserSurname = user.LastName,
                CreatedAt = DateTime.Now
            };

            _context.Users.Add(userEntity);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<User> GetLoggedInUserData(int userId)
        {
            UserEntity userEntity = await _context.Users.FindAsync(userId);

            if (userEntity == null)
                return null;

            User user = new User
            {
                Id = userEntity.UserID,
                Username = userEntity.UserName,
                FirstName = userEntity.UserFirstName,
                LastName = userEntity.UserSurname,
                Email = userEntity.UserEmail,
                IsOptedIn = userEntity.IsOptedIn,
                Latitude = userEntity.Latitude + 90,
                Longitude = userEntity.Longitude - 75,
                Password = "disabled",
            };

            return user;
        }


    }
}

