using PizzaPattern.nav;

while (true)
{
    try
    {
        new MainNavigation().Main();
    }
    catch (Exception e)
    {
        Console.WriteLine("An error occured : " + e.Message);
        Console.ReadLine();
    }
}
