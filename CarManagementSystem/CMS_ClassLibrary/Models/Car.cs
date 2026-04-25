namespace CMS_ClassLibrary.Models;
public enum BodyTypes
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

public enum Gearboxes
{
    Manual,
    Automatic
}

public enum FuelTypes
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
    public Gearboxes Gearbox { get; set; } 
    public BodyTypes BodyType { get; set; }
    public int Doors { get; set; }
    public int Seat { get; set; }
    public decimal EngineSize { get; set; }
    public int BootSpace { get; set; }
    public FuelTypes FuelType { get; set; }
    public bool IsDeleted { get; set; }


}
