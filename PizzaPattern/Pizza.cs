using PizzaPattern.serializers;

namespace PizzaPattern;

public class Pizza : IPizza, ISerializable
{
    public string Name { get; private set; }
    public List<Ingredient> Ingredients { get; private set; }
    public double Price { get; private set; }
    public int Count { get; set; }
    private bool IsCustom { get; } 

    public Pizza(string basePizzaName, int pizzasCount, string[] updateIngredients)
    {
        StandardPizza basePizza = StandardPizza.Of(basePizzaName);
        IsCustom = updateIngredients.Length > 0;
        SetFromStandardPizza(basePizza);
        UpdateIngredients(updateIngredients);
        Count = pizzasCount;
    }

    private bool Equals(Pizza other)
    {
        return Name == other.Name && Ingredients.Equals(other.Ingredients) && Price.Equals(other.Price);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Pizza)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Ingredients, Price);
    }

    private void SetFromStandardPizza (StandardPizza basePizza)
    {
        if (IsCustom) Name = "Custom " + basePizza.Name;
        else Name = basePizza.Name;
        Ingredients = basePizza.Ingredients;
        Price = basePizza.Price;
    }

    private void UpdateIngredients(string[] updateIngredients)
    {
        string ingredientName = "";
        foreach (var updateIngredient in updateIngredients)
        {
            char action = updateIngredient[0];
            ingredientName = updateIngredient.Substring(1);
            switch (action)
            {
                case '-': RemoveIngredient(ingredientName);
                    break;
                case '+': AddIngredient(ingredientName);
                    break;
                default: throw new Exception("Invalid ingredient action");
            }
            Price += 0.5;
        }
    }

    private void AddIngredient(string ingredientName)
    {
        Ingredients.Add(new Ingredient("Extra " + ingredientName, 50, Unit.Grams));
    }


    private void RemoveIngredient(string ingredientName)
    {
        Ingredient comparison = new Ingredient(ingredientName, 0, Unit.Grams);
        int index = Ingredients.IndexOf(comparison);
        if (index != -1) Ingredients.RemoveAt(index);
    }

    public string AcceptSerializer(ISerializer serializer)
    {
        return serializer.SerializePizza(this);
    }
}