using CMS_ClassLibrary.Models;
using CMS_ClassLibrary.Services;
using CMS_Testing.Fakes;
namespace CMS_Testing.Services;

public class CarServiceTests
{
    [Fact]
    public async Task GetAllCars_ReturnsAllCars()
    {
        // Arrange
        var fakeRepository = new FakeCarRepository();
        var carService = new CarService(fakeRepository);

        // Act
        var result = await carService.GetAllCars();

        // Assert
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task GetCarById_ReturnsCorrectCar()
    {
        // Arrange
        var fakeRepository = new FakeCarRepository();
        var carService = new CarService(fakeRepository);
        var knownId = fakeRepository.GetKnownId();

        // Act
        var result = await carService.GetCarById(knownId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Honda", result.Make);
    }


    [Fact]
    public async Task DeleteCarById_ReturnsCarIsDeleted()
    {
        // Arrange
        var fakeRepository = new FakeCarRepository();
        var carService = new CarService(fakeRepository);
        var knownId = fakeRepository.GetKnownId();

        // Act
        var result = await carService.DeleteCar(knownId);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task CreateCar_ReturnsCreatedCar()
    {
        // Arrange
        var fakeRepository = new FakeCarRepository();
        var carService = new CarService(fakeRepository);
        var newCar = new Car { Make = "Toyota", Model = "Corolla" };


        // Act
        var result = await carService.CreateCar(newCar);
        var carTotal = await carService.GetAllCars();

        // Assert
        Assert.True(result);
        Assert.Equal(3, carTotal.Count());
    }

    [Fact]
    public async Task UpdateCar_ReturnsUpdatedCar()
    {
        // Arrange
        var fakeRepository = new FakeCarRepository();
        var carService = new CarService(fakeRepository);
        var newCar = new Car { Make = "Toyota", Model = "Corolla" };


        // Act
        var result = await carService.CreateCar(newCar);
        var carTotal = await carService.GetAllCars();
        newCar.Make = "Ford";
        var updatedCar = await carService.UpdateCar(newCar);
        var carUpdatedTotal = await carService.GetAllCars();

        // Assert
        Assert.True(result);
        Assert.Equal(3, carTotal.Count());
        Assert.True(updatedCar);
        Assert.Equal("Ford", carUpdatedTotal.ElementAt(2).Make);
    }

}