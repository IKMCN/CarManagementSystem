using CMS_ClassLibrary.Models;

namespace CMS_ClassLibrary.Services;
public interface ICarService
{
    Task<IEnumerable<Car>> GetAllCars();
    Task<Car?> GetCarById(Guid id);
    Task<bool> CreateCar(Car car);
    Task<bool> UpdateCar(Car car);
    Task<bool> DeleteCar(Guid id);
}