using Cinder.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinder.Controllers
{
  // Route: localhost/user
  [Route("[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private List<User> users = new List<User>();
    public UserController()
    {
      var user1 = new User("tobi", "abc123");
      var user2 = new User("kevin", "def456");
      var user3 = new User("alex", "xyz421");

      users.Add(user1);
      users.Add(user2);
      users.Add(user3);
    }
    // GET all users
    // Route: localhost/user
    [HttpGet]
    public List<User> Get()
    {
      return users;
    }

    // GET user by id
    // Route: localhost/user/5
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<User> Get(int id)
    {
      var user = users.Find(user => user.Id == id);
      return user == null ? NotFound() : Ok(user);
    }

    // POST create new user
    // Route: localhost/user
    [HttpPost]
    public User Post(string username, string password)
    {
      var user = new User(username, password);
      return user;
    }

    // DELETE remove one user
    [HttpDelete]
    public void Delete(int id)
    {
      try
      {
        var user = users.Find(user => user.Id == id);
        users.Remove(user);
        return;
      }
      catch
      {
        return;
      }
    }
  }
}
