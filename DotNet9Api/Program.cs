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

//this pushes to app insights
builder.Services.AddApplicationInsightsTelemetry();

//this pushes to logs
builder.Services.AddLogging(builder =>
{
    // Add Application Insights as a logging provider
    builder.Services.AddApplicationInsightsTelemetry();
    // Set the minimum log level (this is optional, adjust as necessary)
    builder.SetMinimumLevel(LogLevel.Information);
});



builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://login.microsoftonline.com/f909ca1a-a214-4ccf-b29f-11fce091c373";
        options.Audience = "5d7d8ee1-c409-4673-ad44-2c0d376ce596";

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuers = new[]
            {
                $"https://login.microsoftonline.com/f909ca1a-a214-4ccf-b29f-11fce091c373/v2.0"
            },
            ValidateIssuerSigningKey = true

        };
        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
               // Log the failure details
                Console.WriteLine($"Authentication failed: {context.Exception.Message}");
                return Task.CompletedTask;
            },
            OnTokenValidated = context =>
            {
                //Log the token validation details
                Console.WriteLine("Token validated successfully.");
                return Task.CompletedTask;
            },
            OnChallenge = context =>
            {
                //This event is triggered when authorization fails
                Console.WriteLine($"Authorization failed: {context.Error}");
                return Task.CompletedTask;
            }
        };
    });



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
