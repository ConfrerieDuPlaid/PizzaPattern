namespace PizzaPattern;

public abstract class DoubleUtils
{
    public static string ToUniversalFormat(double value)
    {
        return value.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
    }
}