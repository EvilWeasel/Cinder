using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;

namespace Cinder.Models
{
  public class User
  {
    public int Id { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    public bool IsVegan { get; set; }
    public string Occupation { get; set; }
    public List<Recipe> UserRecipes { get; set; }
    // public List<User> CachedUsers { get; set; } = new List<User>();

    // public User(string username, string password)
    // {
    //   this.Username = username;
    //   this.Password = password;
    //   this.IsVegan = false;
    //   this.Occupation = "";
    //   this.UserRecipes = new List<Recipe>();
    // }
  }
}
