using DotNet9.API.ServiceRegistration;
using DotNet9.Application.UseCases.User.Commands;
using DotNet9.Insfrastructure;
using DotNet9API.ServiceRegistration;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));


builder.Services.RegisterRequestHandlers();
builder.Services.AddRepositoryServices();
builder.Services.AddApplicationServices();
string? connectionString = builder.Configuration.GetConnectionString("DotNet9ConnectionString");
builder.Services.AddDbContext<DotNet9DbContext>(options => { 
    options.UseSqlServer(connectionString);
});



builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(builder.Configuration,"AzureAd");




builder.Services.AddHybridCache(options => {
    options.DefaultEntryOptions = new HybridCacheEntryOptions
    {
        Expiration = TimeSpan.FromSeconds(10),
        LocalCacheExpiration = TimeSpan.FromSeconds(5)
    };
});

var app = builder.Build();

app.MapGet("/users/{userId}",
    (int userId) => $"The user id is {userId} ");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
