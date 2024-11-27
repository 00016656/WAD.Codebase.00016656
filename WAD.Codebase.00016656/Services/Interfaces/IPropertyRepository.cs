namespace WAD.Codebase._00016656.Services.Interfaces
{
    public interface IPropertyRepository : IRepository<Property>
    {
        Task<IEnumerable<Property>> GetPropertiesByUserIdAsync(int userId);
    }
}
