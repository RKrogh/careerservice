using System.Text.Json;
using System.Text.Json.Serialization;

namespace Logic.JsonConverters
{
    public class DateConverter : JsonConverter<DateOnly>
    {
        //TODO: Probably want this to be handling nullables.
        public override DateOnly Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var dateString = reader.GetString();
            if (dateString == null)
            {
                throw new JsonException("Date string is null");
            }
            return DateOnly.Parse(dateString);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DateOnly value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.ToString("yyyy-MM-dd"));
        }
    }
}
