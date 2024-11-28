using Microsoft.EntityFrameworkCore;
using WAD.Codebase._00016656.Data;
using WAD.Codebase._00016656.Models;
using WAD.Codebase._00016656.Services.Interfaces;

namespace WAD.Codebase._00016656.Services
{
    public class PropertyRepository : Repository<Property>, IPropertyRepository
    {
        public PropertyRepository(RealEstateDbContext context) : base(context) { }

        public async Task<IEnumerable<Property>> GetPropertiesByUserIdAsync(int userId)
        {
            return await _context.Properties
                                 .Where(p => p.UserId == userId)
                                 .ToListAsync();
        }
    }
}
