// See https://aka.ms/new-console-template for more information

using PizzaPattern;

Console.WriteLine("Bienvenue chez Pizza Pattern !");
string? input = "";
while (input != "exit")
{
    Console.WriteLine("Placez votre commande ('exit' pour sortir) :");
    input = Console.ReadLine();
    if (input == "exit")
    {
        break;
    }

    if (input != null && input.Trim() != "")
    {
        Order order = new Order(input);
        Bill.PrintBill(order);
    }
}