using System.Reflection;
using Cinder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Get conneciton string for CinderDB
var connectionString = builder.Configuration.GetConnectionString("CinderDB");
// Add services to the container.
// Add service for entity framework
// Adding services like this is also called "Dependency Injection"
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
builder.Services.AddSwaggerGen(c =>
{
  // Set the comments path for the Swagger JSON and UI.
  var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
  var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
  c.IncludeXmlComments(xmlPath);
});

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

app.Services.SaveSwaggerYaml();

app.Run();
