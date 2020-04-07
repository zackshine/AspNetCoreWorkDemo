using Core3API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core3API.JsonConverter
{
    public class HeadingJsonConverter : JsonConverter<Heading>
    {
        public override Heading Read(ref Utf8JsonReader reader,
                                      Type typeToConvert,
                                      JsonSerializerOptions options)
        {
            var title = reader.GetString();

            return new Heading(title);
        }

        public override void Write(Utf8JsonWriter writer,
                                   Heading value,
                                   JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.Title);
        }
    }
}
