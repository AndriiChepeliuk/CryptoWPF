using Crypto.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Crypto.Entities;

public class CoinByIdMarketData
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("image")]
    public CoinImageLinks Images { get; set; }

    [JsonProperty("links")]
    public CoinGeneralLinks Links { get; set; }

    [JsonProperty("description")]
    public Dictionary<string, string> Description { get; set; }

    [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
    public DateTimeOffset? Genesis_Date { get; set; }

    [JsonProperty("market_data")]
    public MarketData MarketData { get; set; }
}
