namespace Cinder.Models
{
  // Records in C# -> Zusammenhängende Daten in einer Struktur kombiniert, ohne Methoden.
  public record Ingredient(string name, int amount);
  public class Recipe
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Ingredient> Ingredients { get; set; }
    public string Image {  get; set; }
  }
}
