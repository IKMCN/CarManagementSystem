using CMS_ClassLibrary.Models;
using CMS_ClassLibrary.Services;
using Microsoft.AspNetCore.Mvc;

namespace CMS_WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class CarsController : ControllerBase
{
    private readonly ICarService _carService;

    public CarsController(ICarService carService)
    {
        _carService = carService;
    }

    // GET: api/Cars
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Car>>> GetCars()
    {
        try { return Ok(await _carService.GetAllCars()); }
        catch (Exception ex) { return StatusCode(500, "An error occurred"); }
    }
    // GET: api/Cars/5    
    [HttpGet("{id}")]
    public async Task<ActionResult<Car>> GetCarsById(Guid id)
    {
        try { return Ok(await _carService.GetCarById(id)); }
        catch (Exception ex) { return StatusCode(500, "An error occurred"); }
    }


    // POST api/Cars
    [HttpPost]
    public async Task<ActionResult<bool>> Post([FromBody]Car car )
    {
        var output = await _carService.CreateCar(car);

        return Ok(output);
    }

    // PUT api/Car/5
    [HttpPut("{id}")]
    public async Task<ActionResult<bool>> Put(Guid id, [FromBody] Car car)
    {
        var output = await _carService.UpdateCar(car);

        return Ok(output);
    }

    // DELETE api/Cars/5
    [HttpDelete("{Id}")]
    public async Task<ActionResult<bool>> Delete(Guid Id)
    {
        var output = await _carService.DeleteCar(Id);

        return Ok(output);
    }
}
