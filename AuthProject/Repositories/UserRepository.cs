using AuthProject.EF;
using Microsoft.EntityFrameworkCore;

namespace AuthProject.Repositories
{
    public interface IUserRepository
    {
        Task<bool> CheckUserAsync(string userName, string password);
    }
    public class UserRepository:IUserRepository
    {
        private readonly AuthDbContext _dbContext;

        public UserRepository(AuthDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<bool> CheckUserAsync(string userName, string password)
        {
            return _dbContext.Users.AnyAsync(setting => setting.UserName == userName
                                                        && setting.Password == password);
        }
    }
}
