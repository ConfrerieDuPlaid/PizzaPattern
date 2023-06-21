namespace PizzaPattern;

public interface ISerializable
{
    string AcceptSerializer(ISerializer serializer);
}

public interface ISerializer
{
    string Serialize(Bill bill);
}