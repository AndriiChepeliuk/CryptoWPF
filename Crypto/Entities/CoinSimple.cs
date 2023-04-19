using Newtonsoft.Json;

namespace Crypto.Entities;

public class CoinSimple
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }
}
