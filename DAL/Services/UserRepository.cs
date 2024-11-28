using Microsoft.EntityFrameworkCore;
using WAD.Codebase._00016656.Data;
using WAD.Codebase._00016656.Models;
using WAD.Codebase._00016656.Services.Interfaces;

namespace WAD.Codebase._00016656.Services
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(RealEstateDbContext context) : base(context) { }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
