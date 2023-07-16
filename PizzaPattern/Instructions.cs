namespace PizzaPattern;

public class Instructions
{
    private List<string> PreparationInstructions { get; }
    public Instructions(IPizza pizza)
    {
        PreparationInstructions = new List<string>()
        {
            "Instructions for a " + pizza.Name,
            "- Prepare the dough"
        };
        foreach (var ingredient in pizza.Ingredients)
        {
            PreparationInstructions.Add("- Add the " + ingredient.Name);
        }
        PreparationInstructions.Add("- Bake the pizza");
    }

    public void Print ()
    {
        foreach (var instruction in PreparationInstructions)
        {
            Console.WriteLine(instruction);
        }
    }
}