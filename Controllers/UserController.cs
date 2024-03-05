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
    private List<User> users;
    public UserController()
    {
      users = UserRepository.Instance.AllUsers;
    }
    // GET all users
    // Route: localhost/user
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<List<User>> Get()
    {
      if (users.Count == 0)
      {
        return NotFound();
      }
      return Ok(users);
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
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<User> Post([FromBody] User user)
    {
      users.Add(user);
      return Ok(user);
    }

    // PUT modify one user by id
    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<User> Put(int id, [FromBody] User user)
    {
      try
      {
        // Get user by id
        var userToModify = users.Find(users => users.Id == id);
        // Modify user with user from http-request body
        userToModify.Username = user.Username;
        userToModify.Password = user.Password;
        userToModify.IsVegan = user.IsVegan;
        userToModify.Occupation = user.Occupation;
        // return modified user
        return Ok(userToModify);
      } 
      catch
      {
        return NotFound();
      }
    }

    // DELETE remove one user
    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<User> Delete(int id)
    {
      try
      {
        var user = users.Find(user => user.Id == id);
        users.Remove(user);
        return Ok(user);
      }
      catch
      {

        return NotFound();
      }
    }
  }
}
