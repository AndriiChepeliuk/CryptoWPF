using Newtonsoft.Json.Converters;

namespace Crypto.Converters;

public class CustomDateTimeConverter : IsoDateTimeConverter
{
    public CustomDateTimeConverter(string format)
    {
        DateTimeFormat = format;
    }
}
