// See https://aka.ms/new-console-template for more information

using PizzaPattern;
using PizzaPattern.serializers;

Console.WriteLine("Bienvenue chez Pizza Pattern !");
Menu menu = new Menu();
string? input = "";
while (input != "exit")
{
    try
    {
        menu.PrintMenu();
        Console.WriteLine("Placez votre commande ('exit' pour sortir) :");
        input = Console.ReadLine();
        if (input == "exit")
        {
            break;
        }

        if (input != null && input.Trim() != "")
        {
            Order order = new Order(input);
            Bill bill = new Bill(order);
            ISerializer serializer = new DefaultSerializer();
            var serialized = bill.AcceptSerializer(serializer);
            Console.WriteLine(serialized);
            order.PrintAllInstructions();
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("Une erreur est survenue : " + e.Message);
        Console.WriteLine("Veuillez recommencer votre commande.");
    }
}