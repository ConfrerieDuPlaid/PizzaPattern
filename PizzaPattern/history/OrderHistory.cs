using System.Text;

namespace PizzaPattern.history;

public class OrderHistory
{
    private readonly List<OrderSnapshot> _orderSnapshots = new List<OrderSnapshot>();

    private OrderHistory() {}

    public void Add(OrderSnapshot order)
    {
        _orderSnapshots.Add(order);
    }

    public void Export()
    {
        Console.WriteLine("Enter the file to write into :");
        string filename = Console.ReadLine() ?? "";
        if (filename == "") throw new Exception("Invalid file name !");
        using (FileStream fs = File.Create(filename)) 
        {
            string dataString = Serialize();
            byte[] info = new UTF8Encoding(true).GetBytes(dataString);
            fs.Write(info, 0, info.Length);
        }
        _orderSnapshots.Clear();
    }

    public void Print()
    {
        Console.WriteLine("History of orders :");
        Console.WriteLine(Serialize("> "));
    }

    private string Serialize(string prefix = "")
    {
        List<string> snapshots = new List<string>();
;       foreach (var snapshot in _orderSnapshots)
        {
            snapshots.Add(prefix + snapshot.State());
        }
        return string.Join("\n", snapshots);
    }

    private static OrderHistory? _instance = null;

    public static OrderHistory GetInstance()
    {
        return _instance ??= new OrderHistory();
    }
}