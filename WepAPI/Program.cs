using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using Business.DependencyResolves.Autofac;
using Autofac.Core;
using System.Configuration;
using static Core.Utilities.Security.JWT.JwtHelper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Core.Utilities.Security.Encryption;
using Microsoft.IdentityModel.Tokens;
using Core.DependencyResolvers;
using Core.Utilities.IaC;
using Core.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Autofac Service Provider Factory
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// Registering AutofacBusinessModule
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new AutofacBusinessModule());
});

// Add Controllers
builder.Services.AddControllers();
builder.Services.AddCors(); 

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    // JWT Bearer i�in SecurityDefinition ekleme
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\""
    });

    // Authorization i�in SecurityRequirement ekleme
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});




// TokenOptions configuration
var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

// JWT Authentication configuration
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });

// Register Core dependencies
builder.Services.AddDependencyResolvers(new ICoreModule[]
{
    new CoreModule(),
});




var app = builder.Build();






// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.ConfigureCustomExceptionMiddleware();

app.UseCors(builder=>builder.WithOrigins("http://localhost:4200/").AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseHttpsRedirection();

// Ensure Authentication comes before Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
