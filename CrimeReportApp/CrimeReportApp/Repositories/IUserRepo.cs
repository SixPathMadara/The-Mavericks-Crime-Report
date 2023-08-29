using CrimeReportApp.Models;

namespace CrimeReportApp.Repositories
{
    public interface IUserRepo
    {
        Task Register(User user);
        Task<bool> Login(User user);
        Task<User> GetUserById(int userId);
        Task<User> GetUserByEmail(string email);
        Task<bool> RegisterByEmail(string email, string password); 
        Task<bool> LoginByEmail(string email, string password);
        Task<IEnumerable<User>> GetAllUsers();
        Task<bool> UpdateUser(User user); 
        Task<bool> DeleteUser(int userId);
    }
}
