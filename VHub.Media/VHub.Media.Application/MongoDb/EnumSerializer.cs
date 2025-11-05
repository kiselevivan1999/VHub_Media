using System.ComponentModel;
using System.Reflection;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using VHub.Media.Common.Extensions;

namespace VHub.Media.Application.MongoDb;

/// <summary>
/// Сериализатор для enum. Записывает в БД описание enum из атрибута Description.
/// </summary>
public class EnumSerializer<T> : SerializerBase<T>
    where T : struct, Enum
{
    public override void Serialize(
        BsonSerializationContext context,
        BsonSerializationArgs args,
        T value)
    {
        var description = value.GetDescription();
        context.Writer.WriteString(description);
    }

    public override T Deserialize(
        BsonDeserializationContext context,
        BsonDeserializationArgs args)
    {
        var description = context.Reader.ReadString();
        return GetEnumFromDescription(description);
    }

    private static T GetEnumFromDescription(string description)
    {
        foreach (var field in typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static))
        {
            var attribute = field.GetCustomAttribute<DescriptionAttribute>();
            if (attribute?.Description == description)
                return (T)field.GetValue(null);
        }

        return Enum.Parse<T>(description);
    }
}