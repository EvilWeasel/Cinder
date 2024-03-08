using Cinder.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinder;

public class UserContext : DbContext
{
  public UserContext(DbContextOptions<UserContext> options) : base(options)
  {

  }
  public DbSet<User> Users { get; set; }
  public DbSet<Recipe> Recipes { get; set; }
  public DbSet<Ingredient> Ingredients { get; set; }
}
