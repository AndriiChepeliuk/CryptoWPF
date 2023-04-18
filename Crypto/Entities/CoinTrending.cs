using Newtonsoft.Json;

namespace Crypto.Entities;

public class CoinTrending
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("coin_id")]
    public int? CoinId { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    [JsonProperty("market_cap_rank")]
    public int? MarketCapRank { get; set; }

    [JsonProperty("thumb")]
    public string Thumb { get; set; }

    [JsonProperty("small")]
    public string Small { get; set; }

    [JsonProperty("large")]
    public string Large { get; set; }

    [JsonProperty("slug")]
    public string Slug { get; set; }

    [JsonProperty("price_btc")]
    public decimal? PriceBtc { get; set; }

    [JsonProperty("score")]
    public int Score { get; set; }
}
