// See https://aka.ms/new-console-template for more information

using PizzaPattern;
using PizzaPattern.nav;

Console.WriteLine("Bienvenue chez Pizza Pattern !");
Menu menu = new Menu();
string? input = "";

new InteractiveMainMenu().Main();
// while (input != "exit")
// {
//     try
//     {
//         menu.PrintPizzaMenu();
//         Console.WriteLine("Placez votre commande ('exit' pour sortir) :");
//         input = Console.ReadLine();
//         if (input == "exit")
//         {
//             break;
//         }
//
//         if (input != null && input.Trim() != "")
//         {
//             Order order = new Order(input);
//             Bill bill = new Bill(order);
//             menu.PrintActionsMenu();
//             ISerializer serializer = new JsonSerializer();
//             var serialized = bill.AcceptSerializer(serializer);
//             Console.WriteLine(serialized);
//             order.PrintAllInstructions();
//         }
//     }
//     catch (Exception e)
//     {
//         Console.WriteLine("Une erreur est survenue : " + e.Message);
//         Console.WriteLine("Veuillez recommencer votre commande.");
//     }
// }