using CMS_ClassLibrary.Models;
using CMS_ClassLibrary.Repository;

namespace CMS_Testing.Fakes;

public class FakeCarRepository : ICarRepository
{

    private readonly Guid _knownId = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234567890");

    private readonly List<Car> _cars;

    public FakeCarRepository()
    {
        _cars = new List<Car>
    {
        new Car { Id = _knownId, Make = "Honda", Model = "Civic" },
        new Car { Make = "Ford", Model = "Escort" }
    };
    }

    public Guid GetKnownId() => _knownId;


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
        return Task.FromResult(_cars.AsEnumerable());
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