using Newtonsoft.Json;
using System.Collections.Generic;

namespace Crypto.Entities;

public class MarketData
{
    [JsonProperty("current_price")]
    public Dictionary<string, decimal?> CurrentPrice { get; set; }

    [JsonProperty("market_cap")]
    public Dictionary<string, decimal?> MarketCap { get; set; }

    [JsonProperty("total_volume")]
    public Dictionary<string, decimal?> TotalVolume { get; set; }

    [JsonProperty("fully_diluted_valuation")]
    public Dictionary<string, decimal?> FullyDilutedValuation { get; set; }

    [JsonProperty("high_24h")]
    public Dictionary<string, decimal?> High24H { get; set; }

    [JsonProperty("low_24h")]
    public Dictionary<string, decimal?> Low24H { get; set; }

    [JsonProperty("market_cap_rank")]
    public long? MarketCapRank { get; set; }

    [JsonProperty("price_change_24h")]
    public decimal? PriceChange24H { get; set; }

    [JsonProperty("price_change_percentage_24h")]
    public double? PriceChangePercentage24H { get; set; }

    [JsonProperty("market_cap_change_24h")]
    public decimal? MarketCapChange24H { get; set; }

    [JsonProperty("market_cap_change_percentage_24h")]
    public decimal? MarketCapChangePercentage24H { get; set; }

    [JsonProperty("circulating_supply")]
    public decimal? CirculatingSupply { get; set; }

    [JsonProperty("total_supply")]
    public decimal? TotalSupply { get; set; }

    [JsonProperty("max_supply")]
    public decimal? MaxSupply { get; set; }

    [JsonProperty("price_change_percentage_7d")]
    public string PriceChangePercentage7D { get; set; }

    [JsonProperty("price_change_percentage_14d")]
    public string PriceChangePercentage14D { get; set; }

    [JsonProperty("price_change_percentage_30d")]
    public string PriceChangePercentage30D { get; set; }

    [JsonProperty("price_change_percentage_60d")]
    public string PriceChangePercentage60D { get; set; }

    [JsonProperty("price_change_percentage_200d")]
    public string PriceChangePercentage200D { get; set; }

    [JsonProperty("price_change_percentage_1y")]
    public string PriceChangePercentage1Y { get; set; }

    [JsonProperty("price_change_24h_in_currency")]
    public Dictionary<string, decimal> PriceChange24HInCurrency { get; set; }

    [JsonProperty("price_change_percentage_1h_in_currency")]
    public Dictionary<string, double> PriceChangePercentage1HInCurrency { get; set; }

    [JsonProperty("price_change_percentage_24h_in_currency")]
    public Dictionary<string, double> PriceChangePercentage24HInCurrency { get; set; }

    [JsonProperty("price_change_percentage_7d_in_currency")]
    public Dictionary<string, double> PriceChangePercentage7DInCurrency { get; set; }

    [JsonProperty("price_change_percentage_14d_in_currency")]
    public Dictionary<string, double> PriceChangePercentage14DInCurrency { get; set; }

    [JsonProperty("price_change_percentage_30d_in_currency")]
    public Dictionary<string, double> PriceChangePercentage30DInCurrency { get; set; }

    [JsonProperty("price_change_percentage_60d_in_currency")]
    public Dictionary<string, double> PriceChangePercentage60DInCurrency { get; set; }

    [JsonProperty("price_change_percentage_200d_in_currency")]
    public Dictionary<string, double> PriceChangePercentage200DInCurrency { get; set; }

    [JsonProperty("price_change_percentage_1y_in_currency")]
    public Dictionary<string, double> PriceChangePercentage1YInCurrency { get; set; }

    [JsonProperty("market_cap_change_24h_in_currency")]
    public Dictionary<string, decimal> MarketCapChange24HInCurrency { get; set; }

    [JsonProperty("market_cap_change_percentage_24h_in_currency")]
    public Dictionary<string, decimal> MarketCapChangePercentage24HInCurrency { get; set; }
}
