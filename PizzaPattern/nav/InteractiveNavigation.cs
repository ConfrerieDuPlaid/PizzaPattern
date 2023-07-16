namespace PizzaPattern.nav;

public abstract class InteractiveNavigation
{
    protected abstract List<Option> Options { get; set; }

    protected abstract string MenuHeader { get; set; }

    protected abstract void SetOptions();

    protected abstract void SetMenuHeader(string? input);
    
    public void Main()
    {
        // Set the default index of the selected item to be the first
        int index = 0;
        
        // Set the navigation options
        SetOptions();

        // Write the menu out
        WriteMenu(Options, Options[index]);

        // Store key info in here
        ConsoleKeyInfo keyinfo;
        do
        {
            keyinfo = Console.ReadKey();

            // Handle each key input (down arrow will write the menu again with a different selected item)
            if (keyinfo.Key == ConsoleKey.DownArrow)
            {
                if (index + 1 < Options.Count)
                {
                    index++;
                    WriteMenu(Options, Options[index]);
                }
            }
            if (keyinfo.Key == ConsoleKey.UpArrow)
            {
                if (index - 1 >= 0)
                {
                    index--;
                    WriteMenu(Options, Options[index]);
                }
            }
            // Handle different action for the option
            if (keyinfo.Key == ConsoleKey.Enter)
            {
                Options[index].Selected.Invoke();
                index = 0;
            }
        }
        while (keyinfo.Key != ConsoleKey.X);

        Console.ReadKey();
    }

    protected void WriteMenu(List<Option> Options, Option selectedOption)
    {
        Console.Clear();

        Console.WriteLine(MenuHeader);
        foreach (Option option in Options)
        {
            if (option == selectedOption)
            {
                Console.Write("> ");
            }
            else
            {
                Console.Write(" ");
            }

            Console.WriteLine(option.Name);
        }
    }

    protected void ExitPrint()
    {
        string? input = null;
        while (input == null) input = Console.ReadLine();
        Main();
    }
}

public class Option
{
    public string Name { get; }
    public Action Selected { get; }

    public Option(string name, Action selected)
    {
        Name = name;
        Selected = selected;
    }
}