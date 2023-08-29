using CrimeReportApp.Models;
using CrimeReportApp.Repositories;

namespace CrimeReportApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepository;

        public UserService(IUserRepo userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Register(User user)
        {
            await _userRepository.Register(user);
        }

        public async Task<bool> Login(User user)
        {
            return await _userRepository.Login(user);
        }
        public async Task<User> GetUserById(int userId)
        {
            return await _userRepository.GetUserById(userId);
        }
        public async Task<User> GetUserByEmail(string email)
        {
            return await _userRepository.GetUserByEmail(email);
        }
        public async Task<bool> RegisterByEmail(string email, string password)
        {
            return await _userRepository.RegisterByEmail(email, password);
        }

        public async Task<bool> LoginByEmail(string email, string password)
        {
            return await _userRepository.LoginByEmail(email, password);
        }
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }
        public async Task<bool> UpdateUser(User user)
        {
            return await _userRepository.UpdateUser(user);
        }

        public async Task<bool> DeleteUser(int userId)
        {
            return await _userRepository.DeleteUser(userId);
        }
    }
}
