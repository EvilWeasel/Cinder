using Cinder;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);

// Get conneciton string for CinderDB
var connectionString = builder.Configuration.GetConnectionString("CinderDB");
// Add services to the container.
// Add service for entity framework
builder.Services.AddDbContext<UserContext>(
    options => options.UseMySql(
      connectionString,
      ServerVersion.AutoDetect(connectionString)
      )
      .EnableDetailedErrors()
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
