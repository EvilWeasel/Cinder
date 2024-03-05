using System.Runtime.Intrinsics.X86;

namespace Cinder.Models
{
  public class User
  {
    // Static -> Existiert in der Klasse, nicht der Instanz!
    private static int _id;
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public bool IsVegan { get; set; }
    public string Occupation { get; set; }
    public List<Recipe> UserRecipes { get; set; } = new List<Recipe>();
    public List<User> CachedUsers { get; set; } = new List<User>();

    public User(string username, string password)
    {
      this.Username = username;
      this.Password = password;
      this.IsVegan = false;
      this.Occupation = "";
      this.Id = _id++;
    }
  }
}
