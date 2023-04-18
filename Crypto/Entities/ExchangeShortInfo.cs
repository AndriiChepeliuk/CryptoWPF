using Newtonsoft.Json;

namespace Crypto.Entities;

public class ExchangeShortInfo
{
    [JsonProperty("identifier")]
    public string Identifier { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("has_trading_incentive")]
    public bool? Has_Trading_Incentive { get; set; }
}
