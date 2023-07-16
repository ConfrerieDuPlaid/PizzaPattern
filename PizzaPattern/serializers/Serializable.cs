namespace PizzaPattern.serializers;

public interface ISerializable
{
    string AcceptSerializer(ISerializer serializer);
}

public interface ISerializer : IVisitor
{
    string Serialize(Bill bill);

    string SerializePizza(Pizza pizza);

    string SerializeIngredient(Ingredient ingredient);
}