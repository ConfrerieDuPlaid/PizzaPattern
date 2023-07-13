namespace PizzaPattern;

public class DoubleUtils
{
    public static string toUniversalFormat(double value)
    {
        return value.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
    }
}