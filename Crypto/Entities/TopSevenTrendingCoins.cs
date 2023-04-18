using Newtonsoft.Json;
using System.Collections.Generic;

namespace Crypto.Entities;

public class TopSevenTrendingCoins
{
    public List<Item> Coins { get; set; }


}

public class Item
{
    [JsonProperty("item")]
    public CoinTrending Coin { get; set; }
}
