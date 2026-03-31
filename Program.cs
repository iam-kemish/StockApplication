using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using StockApplicationApi.Database;
using StockApplicationApi.Exceptions;
using StockApplicationApi.Mapper;
using StockApplicationApi.Repositary.StockRepositary;
using StockApplicationApi.Services.StockServices;
using StockApplicationApi.Validators;

var builder = WebApplication.CreateBuilder(args);


// Controllers + API behavior
builder.Services.AddControllers();

// FluentValidation - assembly scan (this is perfect)
builder.Services.AddValidatorsFromAssemblyContaining<StockCreateDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<StockUpdateDtoValidator>();

// OpenAPI / Scalar (good, but consider builder.Services.AddEndpointsApiExplorer() if using minimal APIs later)
builder.Services.AddOpenApi();

// Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// AutoMapper
builder.Services.AddAutoMapper(typeof(MapConfig));

// Your services
builder.Services.AddScoped<IStock, StockRepo>();
builder.Services.AddScoped<IStockService, StockClass>();

var app = builder.Build();

// Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseMiddleware<GlobalException>();
    app.MapOpenApi();           // usually before Scalar
    app.MapScalarApiReference(); // nice for dev docs
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();