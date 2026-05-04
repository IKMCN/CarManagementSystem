using CMS_ClassLibrary.Models;

namespace CMS_ClassLibrary.Repository;

public class CarRepository : ICarRepository
{
    private readonly List<Car> _cars = new();

    public Task<bool> CreateAsync(Car car)
    {
        _cars.Add(car);
        return Task.FromResult(true);
    }

    public Task<Car?> GetByIdAsync(Guid id)
    {
        var car = _cars.SingleOrDefault(x => x.Id == id);
        return Task.FromResult(car);
    }

    public Task<IEnumerable<Car>> GetAllAsync()
    {
        return Task.FromResult(_cars.ToList().AsEnumerable());
    }

    public Task<bool> UpdateAsync(Car car)
    {
        var carIndex = _cars.FindIndex(x => x.Id == car.Id);
        if (carIndex == -1)
        {
            return Task.FromResult(false);
        }

        _cars[carIndex] = car;
        return Task.FromResult(true);
    }

    public Task<bool> DeleteByIdAsync(Guid id)
    {
        var removedCount = _cars.RemoveAll(x => x.Id == id);
        var carRemoved = removedCount > 0;
        return Task.FromResult(carRemoved);
    }

}