namespace PizzaPattern;

public class Ingredient: ISerializable
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

    private bool Equals(Ingredient other)
    {
        return Name == other.Name;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Ingredient)obj);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }

    public string AcceptSerializer(ISerializer serializer)
    {
        return serializer.SerializeIngredient(this);
    }
}