using CMS_ClassLibrary.Models;
using CMS_ClassLibrary.Repository;

namespace CMS_ClassLibrary.Services;

public class CarService : ICarService
{
    private readonly ICarRepository _carRepository;

    // Inject the Car Respository
    public CarService(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }


    public async Task<IEnumerable<Car>> GetAllCars()
    {
        // Access the repository 

        var cars = await _carRepository.GetAllAsync();
        return cars;
    }

    public async Task<Car?> GetCarById(Guid id)
    {
        var car = await _carRepository.GetByIdAsync(id);
        return car;
    }

    public async Task<bool> CreateCar(Car car)
    {
        var result = await _carRepository.CreateAsync(car);
        return result;
    }
    public async Task<bool> DeleteCar(Guid id)
    {
        var result = await _carRepository.DeleteByIdAsync(id);
        return result;
    }


    public async Task<bool> UpdateCar(Car car)
    {
        var result = await _carRepository.UpdateAsync(car);
        return result;
    }





}
