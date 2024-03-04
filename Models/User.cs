namespace Cinder.Models
{
  public class User
  {
    // Static -> Existiert in der Klasse, nicht der Instanz!
    // Trackt alle existierenden User, um eine neue, eindeutige ID zu generieren.
    public static List<User> AllUsers { get; set; } = new List<User>();
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
      // Get new ID based on ID of last User already existing
      try
      {
        // If this throws, no user is present -> create first one with Id 0
        var latestId = User.AllUsers.Last().Id;
        this.Id = latestId + 1;
      } 
      catch
      {
        this.Id = 0;
      }
      User.AllUsers.Add(this);
    }
  }
}
