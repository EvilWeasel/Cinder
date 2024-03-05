namespace Cinder.Models
{
  public class UserRepository
  {
    private static UserRepository _instance;
    public static UserRepository Instance
    {
      get
      {
        if (_instance == null)
          _instance = new UserRepository();
        return _instance;
      }
    }
    public List<User> AllUsers { get; set; }
    private UserRepository()
    {
      AllUsers = new List<User>()
      {
        new User("tobi", "abc123"),
        new User("kevin", "def456"),
        new User("alex", "xyz421")
      };

    }
  }
}
