namespace PizzaPattern;

public class Pizza : IPizza
{
    public string Name { get; private set; }
    public List<Ingredient> Ingredients { get; private set; }
    public double Price { get; private set; }
    public int Count { get; set; }

    public Pizza(string basePizzaName, int pizzasCount, string[] updateIngredients)
    {
        StandardPizza basePizza = StandardPizza.Of(basePizzaName);
        this.SetFromStandardPizza(basePizza, updateIngredients.Length > 0);
        this.UpdateIngredients(updateIngredients);
        this.Count = pizzasCount;
    }

    private bool Equals(Pizza other)
    {
        return Name == other.Name && Ingredients.Equals(other.Ingredients) && Price.Equals(other.Price);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Pizza)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Ingredients, Price);
    }

    private void SetFromStandardPizza (StandardPizza basePizza, bool isCustom)
    {
        if (isCustom) this.Name = "Custom " + basePizza.Name;
        else this.Name = basePizza.Name;
        this.Ingredients = basePizza.Ingredients;
        this.Price = basePizza.Price;
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
                case '-': this.RemoveIngredient(ingredientName);
                    break;
                case '+': this.AddIngredient(ingredientName);
                    break;
                default: throw new Exception("Invalid ingredient action");
            }
            this.Price += 0.5;
            
        }
    }

    private void AddIngredient(string ingredientName)
    {
        this.Ingredients.Add(new Ingredient("Extra " + ingredientName, 50, Unit.Grams));
    }


    private void RemoveIngredient(string ingredientName)
    {
        Ingredient comparison = new Ingredient(ingredientName, 0, Unit.Grams);
        int index = this.Ingredients.IndexOf(comparison);
        if (index != -1) this.Ingredients.RemoveAt(index);
    }
}