using Newtonsoft.Json;

namespace Crypto.Entities;

public class CoinGeneralLinks
{
    [JsonProperty("homepage")]
    public string[] Homepage { get; set; }

    [JsonProperty("blockchain_site")]
    public string[] BlockchainSite { get; set; }

    [JsonProperty("official_forum_url")]
    public string[] OfficialForumUrl { get; set; }
}
