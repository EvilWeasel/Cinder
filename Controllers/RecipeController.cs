using Cinder.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinder.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class RecipeController : ControllerBase
  {
    private List<Recipe> recipes;

    public RecipeController()
    {
      recipes = RecipeRepository.Instance.Recipes;
    }
    // GET all recipes
    // Route: localhost/recipe
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<List<Recipe>> Get()
    {
      if (recipes.Count < 1)
      {
        return NotFound();
      }
      else
      {
        return Ok(recipes);
      }
    }

    // GET one recipe by id
    // Route: localhost/recipe/5
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<Recipe> Get(int id)
    {
      var recipe = recipes.Find(recipe => recipe.Id == id);
      return recipe == null ? NotFound() : Ok(recipe);
    }

    // POST create one new recipe
    // Route: localhost/recipe
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Recipe> Post([FromBody] Recipe recipe)
    {
      recipes.Add(recipe);
      return Ok(recipe);
    }

    // PUT change a recipe by id
    // Route: localhost/recipe/5
    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Recipe> Put(int id, [FromBody] Recipe recipe)
    {
      // get recipe by id
      var recipeToModify = recipes.Find(r => r.Id == id);
      if (recipeToModify == null)
        return NotFound();
      // modify recipe
      recipeToModify.Name = recipe.Name;
      recipeToModify.Image = recipe.Image;
      recipeToModify.Ingredients = recipe.Ingredients;
      // return recipe
      return Ok(recipeToModify);
    }

    // DELETE one recipe by id
    // Route: localhost/recipe/5
    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Recipe> Delete(int id)
    {
      // get recipe by id
      var recipeToDelete = recipes.Find(recipe => recipe.Id == id);
      if (recipeToDelete == null) return NotFound();
      // remove recipe from list
      recipes.Remove(recipeToDelete);
      // return deleted recipe
      return Ok(recipeToDelete);
    }
  }
}
