namespace PizzaPattern;

public class Ingredient
{
    private string Name { get; set; }
    private int Quantity { get; set; }
    
    private Unit Unit { get; set; }

    public Ingredient(string name, int quantity, Unit unit)
    {
        Name = name;
        Quantity = quantity;
    }
    
}