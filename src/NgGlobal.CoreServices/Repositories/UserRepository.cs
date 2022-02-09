using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NgGlobal.DatabaseModels.Models;
using System.Threading.Tasks;

namespace NgGlobal.CoreServices.Repositories.Abstractions
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager = default;
        private readonly SignInManager<User> _signInManager = default;

        public UserRepository(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }

        public async Task<bool> LogInAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var result = await _signInManager.PasswordSignInAsync(user, password, true, false);
            return result.Succeeded;
        }

        public async Task<bool> RegistrationAsync(User item,string password)
        {
            var result = await _userManager.CreateAsync(item, password);
            return result.Succeeded;
        }
    }
}
