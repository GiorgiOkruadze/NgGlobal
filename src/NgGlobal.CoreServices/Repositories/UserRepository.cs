using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NgGlobal.DatabaseEntity.DB;
using NgGlobal.DatabaseModels.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using NgGlobal.CoreServices.Extensions;

namespace NgGlobal.CoreServices.Repositories.Abstractions
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager = default;
        private readonly SignInManager<User> _signInManager = default;
        private DbSet<User> _userEntity = default;

        public UserRepository(UserManager<User> userManager, SignInManager<User> signInManager,ApplicationDbContext content)
        {
            _userEntity = content.Set<User>();
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<List<User>> GetAllUsersAsync(List<string> includes = null)
        {
            return await _userEntity.IncludeAll(includes).ToListAsync();
        }

        public async Task<User> GetUserAsync(int id, List<string> includes = null)
        {
            return await _userEntity.IncludeAll(includes).SingleOrDefaultAsync(o => o.Id == id);
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

        public async Task<int> RegistrationAsync(User item,string password)
        {
            var result = await _userManager.CreateAsync(item, password);
            return item.Id;
        }
    }
}
