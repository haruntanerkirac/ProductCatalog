using FluentValidation;
using Microsoft.EntityFrameworkCore;
using NLog;
using ProductCatalog.API.Extensions;
using ProductCatalog.API.Utilities.AutoMapper;
using ProductCatalog.API.Validators;
using ProductCatalog.Business.Abstract;
using ProductCatalog.Business.Concrete;
using ProductCatalog.DataAccess;
using ProductCatalog.DataAccess.Abstract;
using ProductCatalog.DataAccess.Concrete.EntityFramework;
using ProductCatalog.Entities.DTOs;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ProductCatalogDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"))
);

LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

//LogManager.Setup().LoadConfigurationFromFile(Path.Combine(Directory.GetCurrentDirectory(), "nlog.config"));

//LogManager.Setup().LoadConfigurationFromFile("nlog.config");


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<IProductDal, EfProductDal>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IValidator<ProductCreateDto>, ProductCreateValidator>();

builder.Services.ConfigureLoggerService();

//builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
