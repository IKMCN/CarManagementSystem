namespace CMS_ClassLibrary.Models;
public enum CarBodyType
{
    Pickup,
    Saloon,
    SUV,
    Hatchback,
    MPV,
    Estate,
    Coupe,
    Convertible
}

public enum CarGearboxType
{
    Manual,
    Automatic
}

public enum CarFuelType
{
    Petrol,
    Diesel,
    Electric,
    Hydrogen,
    Hybrid
}
public class Car
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Make { get; set; } = null!;
    public string Model { get; set; } = null!;
    public string Colour { get; set; } = null!;
    public int Year { get; set; }
    public decimal Price { get; set; }
    public int Mileage { get; set; }
    public CarGearboxType Gearbox { get; set; } 
    public CarBodyType BodyType { get; set; }
    public int Doors { get; set; }
    public int Seats { get; set; }
    public decimal EngineSize { get; set; }
    public int BootSpace { get; set; }
    public CarFuelType FuelType { get; set; }

}
