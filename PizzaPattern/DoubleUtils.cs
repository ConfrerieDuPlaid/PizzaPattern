using System.Globalization;

namespace PizzaPattern;

public abstract class DoubleUtils
{
    public static string ToUniversalFormat(double value)
    {
        return value.ToString("0.00", CultureInfo.InvariantCulture);
    }
}