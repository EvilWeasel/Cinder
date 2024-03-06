namespace Cinder.Models
{
  public class RecipeRepository
  {
    private static RecipeRepository _instance;
    public static RecipeRepository Instance
    {
      get
      {
        if (_instance == null)
          _instance = new RecipeRepository();
        return _instance;
      }
    }
    public List<Recipe> Recipes { get; set; }
    private RecipeRepository()
    {
      Recipes = new List<Recipe>()
      {
        new Recipe(
          "Schwäbische Tomatensuppe",
          new List<Ingredient>()
          {
            new Ingredient("Roter Teller", 1),
            new Ingredient("Heißes Wasser", 250),
          }
        ),
        new Recipe(
          "Takoyaki",
          new List<Ingredient>()
          {
            new Ingredient("Gekochter Oktopus", 120),
            new Ingredient("Eingelegter Ingwer", 1),
            new Ingredient("Frülingszwiebeln", 2),
            new Ingredient("Tenkasu", 20),
          }
        ),
        new Recipe(
          "Pizza Hawaii",
          new List<Ingredient>()
          {
            new Ingredient("Pizza", 1),
            new Ingredient("Ananas", 30),
          }
        ),
      };
    }
  }
}
