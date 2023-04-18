using Newtonsoft.Json;

namespace Crypto.Entities;

public class ExchangeFullInfo : ExchangeMidInfo
{
    [JsonProperty("facebook_url")]
    public string FacebookUrl { get; set; }

    [JsonProperty("reddit_url")]
    public string RedditUrl { get; set; }

    [JsonProperty("telegram_url")]
    public string TelegramUrl { get; set; }

    [JsonProperty("slack_url")]
    public string SlackUrl { get; set; }

    [JsonProperty("other_url_1")]
    public string OtherUrl1 { get; set; }

    [JsonProperty("other_url_2")]
    public string OtherUrl2 { get; set; }

    [JsonProperty("twitter_handle")]
    public string TwitterHandle { get; set; }

    [JsonProperty("centralized")]
    public bool? Centralized { get; set; }

    [JsonProperty("public_notice")]
    public string PublicNotice { get; set; }

    [JsonProperty("alert_notice")]
    public string AlertNotice { get; set; }

    [JsonProperty("tickers")]
    public Ticker[] Tickers { get; set; }
}
