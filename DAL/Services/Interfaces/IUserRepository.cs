using WAD.Codebase._00016656.Models;

namespace WAD.Codebase._00016656.Services.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByEmailAsync(string email);
    }
}
