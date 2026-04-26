using CMS_ClassLibrary.Models;

namespace CMS_ClassLibrary.Repository
{
    public interface ICarRepository
    {
        Task<bool> CreateAsync(Car car);
        Task<bool> DeleteByIdAsync(Guid id);
        Task<IEnumerable<Car>> GetAllAsync();
        Task<Car?> GetByIdAsync(Guid id);
        Task<bool> UpdateAsync(Car car);
    }
}