using Cinder.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cinder.Controllers
{
  // Route: localhost/user
  [Route("[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly UserContext _context;
    public UserController(UserContext context)
    {
      _context = context;
    }
    // GET all users
    // Route: localhost/user
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<User>>> Get()
    {
      var usersList = await _context.Users.ToListAsync();
      if (usersList.Count() == 0)
      {
        return NotFound();
      }
      return Ok(usersList);
    }

    // GET user by id
    // Route: localhost/user/5
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<User> Get(int id)
    {
      var user = _context.Users.Find(id);
      return user == null ? NotFound() : Ok(user);
    }

    // POST create new user
    // Route: localhost/user
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<User> Post([FromBody] User user)
    {
      _context.Users.Add(user);
      _context.SaveChanges();
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
        var userToModify = _context.Users.Find(id);
        // Modify user with user from http-request body
        userToModify.Username = user.Username;
        userToModify.Password = user.Password;
        userToModify.IsVegan = user.IsVegan;
        userToModify.Occupation = user.Occupation;
        // save changes to database
        _context.SaveChanges();
        // return modified user
        return Ok(userToModify);
      }
      catch
      {
        return NotFound();
      }
    }

    // DELETE remove one user
    // Route: localhost/user/5
    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<User>> Delete(int id)
    {
      // Get user by id
      var userToDelete =
        _context.Users.Include(u => u.UserRecipes)
        .ThenInclude(ur => ur.Ingredients)
        .FirstOrDefault(u => u.Id == id);
      // If user not found return 404
      if (userToDelete == null) return NotFound();
      // remove all ingredients for all recipes of user
      foreach (var recipe in userToDelete.UserRecipes)
      {
        foreach (var ingredient in recipe.Ingredients)
        {
          _context.Ingredients.Remove(ingredient);
        }
        _context.Recipes.Remove(recipe);
      }


      // Remove user from ef-context
      _context.Users.Remove(userToDelete);
      // Save changes to database
      await _context.SaveChangesAsync();
      return Ok(userToDelete);
    }
  }
}
