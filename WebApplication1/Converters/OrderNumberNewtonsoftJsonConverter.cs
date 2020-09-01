using Newtonsoft.Json;
using System;
using WebApplication1.Models.ValueTypes;

namespace WebApplication1.Converters
{
    /// <summary>
    /// Json Converter for OrderNumber data type
    /// </summary>
    public class OrderNumberNewtonsoftJsonConverter : JsonConverter<OrderNumber>
    {
        public override OrderNumber ReadJson(JsonReader reader, Type objectType, OrderNumber existingValue,
            bool hasExistingValue, JsonSerializer serializer)
        {
            return new OrderNumber((string)reader.Value);
        }

        public override void WriteJson(JsonWriter writer, OrderNumber value, JsonSerializer serializer)
        {
            writer.WriteValue(value);
        }
    }
}