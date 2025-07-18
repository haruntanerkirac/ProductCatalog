using FluentValidation;
using Microsoft.EntityFrameworkCore;
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

builder.Services.AddControllers();

builder.Services.AddScoped<IProductDal, EfProductDal>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IValidator<ProductCreateDto>, ProductCreateValidator>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program));

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
