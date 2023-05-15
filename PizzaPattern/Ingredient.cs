namespace PizzaPattern;

public class Ingredient
{
    public string Name { get; }
    public double Quantity { get; }
    
    public Unit Unit { get; }

    public Ingredient(string name, double quantity, Unit unit)
    {
        Name = name;
        Quantity = quantity;
        Unit = unit;
    }
    
}