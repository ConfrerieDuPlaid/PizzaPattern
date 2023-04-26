namespace PizzaPattern;

public class Pizza
{
    private List<Ingredient> Ingredients { get; set; }
    private double Price { get; set; }
    
    
    public Pizza(List<Ingredient> ingredients, double price)
    {
        Ingredients = ingredients;
        Price = price;
    }
}