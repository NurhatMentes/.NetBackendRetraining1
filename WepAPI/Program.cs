using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using Business.DependencyResolves.Autofac;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// ASP.NET Core default DI container'ýný Autofac ile deðiþtirdik
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    // AutofacBusinessModule'i burada kaydetdik
    containerBuilder.RegisterModule(new AutofacBusinessModule());
});



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

                                               
//iac****************************
//builder.Services.AddScoped<IProductService, ProductManager>();
//builder.Services.AddScoped<IProductDal, EfProductDal>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
