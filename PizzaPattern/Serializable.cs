namespace PizzaPattern;

public interface ISerializable
{
    string AcceptSerializer(ISerializer serializer);
}

public interface ISerializer : IVisitor
{
    string Serialize(Bill bill);
}