using Newtonsoft.Json;
using System.Collections.Generic;

namespace Crypto.Entities;

public class Ticker
{
    [JsonProperty("base")]
    public string Base { get; set; }

    [JsonProperty("target")]
    public string Target { get; set; }

    [JsonProperty("market")]
    public ExchangeShortInfo Market { get; set; }

    [JsonProperty("last")]
    public decimal Last { get; set; }

    [JsonProperty("volume")]
    public decimal Volume { get; set; }

    [JsonProperty("converted_last")]
    public Dictionary<string, decimal> ConvertedLast { get; set; }

    [JsonProperty("converted_volume")]
    public Dictionary<string, decimal> ConvertedVolume { get; set; }

    [JsonProperty("trade_url")]
    public string TradeUrl { get; set; }
}
