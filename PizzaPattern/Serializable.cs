namespace PizzaPattern;

public interface ISerializable
{
    string AcceptSerializer(ISerializer serializer);
}

public interface ISerializer : IVisitor
{
    string Serialize(Bill bill);

    string SerializePizza(Pizza pizza, int pizzaCount);

    string SerializeIngredient(Ingredient ingredient);
}