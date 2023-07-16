using PizzaPattern.history;
using PizzaPattern.serializers;

namespace PizzaPattern.nav;

public class OrderNavigation : InteractiveNavigation, ICaretaker
{
    protected override List<Option> Options { get; set; } = new();
    protected override string MenuHeader { get; set; } = "";
    private Order Order { get; set; }
    private Bill Bill { get; set; }

    private readonly DefaultSerializer _defaultSerializer = new ();
    private readonly JsonSerializer _jsonSerializer = new ();
    private readonly XmlSerializer _xmlSerializer = new ();

    protected override void SetOptions()
    {
        Options = new List<Option>
        {
            new ("Print bill", () => PrintBill(_defaultSerializer)),
            new ("Print bill as JSON", () => PrintBill(_jsonSerializer)),
            new ("Print bill as XML", () => PrintBill(_xmlSerializer)),
            new ("Print preparation instructions", PrintInstructions),
        };
    }

    protected override void SetMenuHeader(string? input)
    {
        MenuHeader = "Your order : " + input + "\n(enter 'x' to exit)";
    }

    public void ReadOrder()
    {
        string? input;
        try
        {
            new Menu().Print();
            Console.Write("Place your order ('exit' to cancel ordering) : ");
            input = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(input) || input == "exit") return;
            SetMenuHeader(input);
            Order = new Order(input);
            Bill = new Bill(Order);
            OrderHistory.GetInstance().Add(Order.CreateSnapshot());
            Main();
        }
        catch (Exception e)
        {
            Console.WriteLine("Une erreur est survenue : " + e.Message);
            Console.WriteLine("Veuillez recommencer votre commande.");
            ReadOrder();
        }
    }

    private void PrintBill(ISerializer serializer)
    {
        Console.Clear();
        Console.WriteLine("Bill preview");
        string serialized = Bill.AcceptSerializer(serializer);
        Console.WriteLine(serialized);
        ExitPrint();
    }

    private void PrintInstructions()
    {
        Console.Clear();
        Order.PrintAllInstructions();
        ExitPrint();
    }

    public void Save()
    {
        OrderHistory.GetInstance().Add(Order.CreateSnapshot());
    }
}