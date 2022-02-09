using NgGlobal.DatabaseModels.Models;
using System.Threading.Tasks;

namespace NgGlobal.CoreServices.Repositories.Abstractions
{
    public interface IUserRepository
    {
        Task<bool> RegistrationAsync(User item,string password);
        Task<bool> LogInAsync(string email, string password);
        Task<bool> DeleteUserAsync(int id);
    }
}
