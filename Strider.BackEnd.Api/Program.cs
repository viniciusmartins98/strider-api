using Strider.BackEnd.Api;
using Strider.BackEnd.Api.Middlewares;
using Strider.BackEnd.Api.Security.Auth;
using Strider.BackEnd.Api.Security.Cors;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Auth
builder.Services.AddAuth(builder.Configuration);

// Add CORS
builder.Services.AddCors(builder.Configuration);

// Dependency Injection
builder.Services.AddDependencies();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.UseCustomMiddlewares();

app.MapControllers();

app.Run();
