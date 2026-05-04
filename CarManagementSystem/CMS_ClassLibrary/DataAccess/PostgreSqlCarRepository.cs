using CMS_ClassLibrary.Models;
using CMS_ClassLibrary.Repository;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace CMS_ClassLibrary.DataAccess;

public class PostgreSqlCarRepository : ICarRepository
{
    private readonly string _connectionString;

    public PostgreSqlCarRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")!;
    }

    public async Task<bool> CreateAsync(Car car)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        var sql = @"INSERT INTO cars (id, make, model, colour, year, price, mileage, gearbox, body_type, doors, seats, engine_size, boot_space, fuel_type)
                VALUES (@Id, @Make, @Model, @Colour, @Year, @Price, @Mileage, @Gearbox, @BodyType, @Doors, @Seats, @EngineSize, @BootSpace, @FuelType)";

        var rowsAffected = await connection.ExecuteAsync(sql, car);
        return rowsAffected > 0;
    }

    public async Task<Car?> GetByIdAsync(Guid id)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        var car = await connection.QueryFirstOrDefaultAsync<Car>(
            "SELECT * FROM cars WHERE id = @Id",
            new { Id = id });
        return car;
    }

    public async Task<IEnumerable<Car>> GetAllAsync()
    {
        using var connection = new NpgsqlConnection(_connectionString);
        var cars = await connection.QueryAsync<Car>("SELECT * FROM cars");
        return cars;
    }

    public async Task<bool> DeleteByIdAsync(Guid id)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        var rowsAffected = await connection.ExecuteAsync(
            "DELETE FROM cars WHERE id = @Id",
            new { Id = id });
        return rowsAffected > 0;
    }



    public async Task<bool> UpdateAsync(Car car)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        var sql = @"UPDATE cars SET 
                make = @Make, 
                model = @Model, 
                colour = @Colour, 
                year = @Year, 
                price = @Price, 
                mileage = @Mileage, 
                gearbox = @Gearbox, 
                body_type = @BodyType, 
                doors = @Doors, 
                seats = @Seats, 
                engine_size = @EngineSize, 
                boot_space = @BootSpace, 
                fuel_type = @FuelType 
                WHERE id = @Id";
        var rowsAffected = await connection.ExecuteAsync(sql, car);
        return rowsAffected > 0;
    }


}

