using CMS_ClassLibrary.DataAccess;
using CMS_ClassLibrary.Repository;
using CMS_ClassLibrary.Services;
using Dapper;

// Tell Dapper to map snake_case columns (machine_description) to PascalCase props
DefaultTypeMap.MatchNamesWithUnderscores = true;

SqlMapper.AddTypeHandler(new DapperTypeHandlers.CarGearboxTypeHandler());
SqlMapper.AddTypeHandler(new DapperTypeHandlers.CarBodyTypeHandler());
SqlMapper.AddTypeHandler(new DapperTypeHandlers.CarFuelTypeHandler());

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Data + service layer
builder.Services.AddScoped<ICarRepository, PostgreSqlCarRepository>();
builder.Services.AddScoped<ICarService, CarService>();



builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();
app.Run();
