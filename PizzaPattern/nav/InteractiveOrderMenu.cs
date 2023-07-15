using PizzaPattern.serializers;

namespace PizzaPattern.nav;

public class InteractiveOrderMenu : InteractiveNavigation
{
    protected override List<Option> Options { get; set; }
    protected override string MenuHeader { get; set; }

    protected override void SetOptions()
    {
        Options = new List<Option>
        {
            new Option("Print bill", () => this.PrintBill(_defaultSerializer)),
            new Option("Print bill as JSON", () => this.PrintBill(_jsonSerializer)),
            new Option("Print bill as XML", () => this.PrintBill(_xmlSerializer)),
            new Option("Print preparation instructions", this.PrintInstructions),
        };
    }

    protected override void SetMenuHeader(string? input)
    {
        this.MenuHeader = "Your order : " + input + "\n(enter 'x' to exit)";
    }

    private Order Order { get; set; }
    private Bill Bill { get; set; }

    private readonly DefaultSerializer _defaultSerializer = new DefaultSerializer();
    private readonly JsonSerializer _jsonSerializer = new JsonSerializer();
    private readonly XmlSerializer _xmlSerializer = new XmlSerializer();

    public void ReadOrder()
    {
        string? input = "";

        try
        {
            Console.Write("Place your order ('exit' to cancel ordering) : ");
            input = Console.ReadLine()?.Trim();

            if (!string.IsNullOrEmpty(input) && input != "exit")
            {
                this.SetMenuHeader(input);
                this.Order = new Order(input);
                this.Bill = new Bill(this.Order);
                this.Main();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Une erreur est survenue : " + e.Message);
            Console.WriteLine("Veuillez recommencer votre commande.");
        }
    }

    private void PrintBill(ISerializer serializer)
    {
        Console.Clear();
        Console.WriteLine("Bill preview");
        string serialized = this.Bill.AcceptSerializer(serializer);
        Console.WriteLine(serialized);
        string? input = null;
        while (input == null) input = Console.ReadLine();
        this.Main();
    }

    private void PrintInstructions()
    {
        Console.Clear();
        this.Order.PrintAllInstructions();
        string? input = null;
        while (input == null) input = Console.ReadLine();
        this.Main();
    }
}