using Newtonsoft.Json;

namespace Crypto.Entities;

public class CoinImageLinks
{
    [JsonProperty("thumb")]
    public string Thumb { get; set; }

    [JsonProperty("small")]
    public string Small { get; set; }

    [JsonProperty("large")]
    public string Large { get; set; }
}
