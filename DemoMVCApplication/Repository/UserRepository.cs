using DemoMVCApplication.Models.Contracts;
using DemoMVCApplication.Models.Entity;
using DemoMVCApplication.Repository.DBContext;
using Microsoft.EntityFrameworkCore;


namespace DemoMVCApplication.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext applicationDbContext) { 
        _context = applicationDbContext;
        }
        public async Task<int> SaveData(List<User> users)
        {
            try
            {
                await _context.AddRangeAsync(users);
                return await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<User>> GetAllData()
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
