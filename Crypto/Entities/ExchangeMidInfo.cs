﻿using Newtonsoft.Json;

namespace Crypto.Entities
{
    public class ExchangeMidInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("year_established")]
        public int? YearEstablished { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("has_trading_incentive")]
        public bool? HasTradingIncentive { get; set; }

        [JsonProperty("trust_score")]
        public double? TrustScore { get; set; }

        [JsonProperty("trust_score_rank")]
        public double? TrustScoreRank { get; set; }

        [JsonProperty("trade_volume_24h_btc")]
        public double? TradeVolume24HBtc { get; set; }

        [JsonProperty("trade_volume_24h_btc_normalized")]
        public double? TradeVolume24HBtcNormalized { get; set; }
    }
}
