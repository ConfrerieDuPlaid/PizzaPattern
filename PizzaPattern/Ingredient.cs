namespace PizzaPattern;

public class Ingredient
{
    private string Name { get; set; }
    private int Quantity { get; set; }

    public Ingredient(string name, int quantity)
    {
        Name = name;
        Quantity = quantity;
    }
    
}