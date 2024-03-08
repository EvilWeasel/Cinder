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
        new Recipe(){
          Name="Schwäbische Tomatensuppe",
          Ingredients=new List<Ingredient>()
          {
            new Ingredient() { Name="Roter Teller", Amount="1 Stk" },
            new Ingredient() { Name = "Heißes Wasser", Amount = "1 Stk" },
          }
        },
        new Recipe(){
          Name= "Takoyaki",
          Ingredients=new List<Ingredient>()
          {
            new Ingredient() { Name = "Gekochter Oktopus", Amount = "1 Stk" },
            new Ingredient() { Name = "Eingelegter Ingwer", Amount = "1 Stk" },
            new Ingredient() { Name = "Frülingszwiebeln", Amount = "1 Stk" },
            new Ingredient() { Name = "Tenkasu", Amount = "1 Stk" },
          }
        },
        new Recipe(){
          Name="Pizza Hawaii",
          Ingredients= new List<Ingredient>()
          {
            new Ingredient() { Name = "Pizza", Amount = "1 Stk" },
            new Ingredient() { Name = "Ananas", Amount = "1 Stk" },
          }
        },
      };
    }
  }
}
