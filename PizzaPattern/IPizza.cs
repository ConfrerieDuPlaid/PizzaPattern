namespace PizzaPattern;

public interface IPizza
{
    public string Name { get; }
    public List<Ingredient> Ingredients { get; }
}