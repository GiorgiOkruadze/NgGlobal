using NgGlobal.DatabaseModels.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NgGlobal.CoreServices.Repositories.Abstractions
{
    public interface IUserRepository
    {
        Task<int> RegistrationAsync(User item,string password);
        Task<bool> LogInAsync(string email, string password);
        Task<bool> DeleteUserAsync(int id);
        Task<List<User>> GetAllUsersAsync(List<string> includes);
        Task<User> GetUserAsync(int id, List<string> includes);
        Task<List<User>> GetUserByEmailAsync(string email);
    }
}
