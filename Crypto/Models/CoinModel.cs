using Crypto.Entities;
using System.Collections.Generic;

namespace Crypto.Models;

public class CoinModel : ModelBase
{
    public string Id { get; set; }
    public string Symbol { get; set; }
    public string Name { get; set; }
    public string Genesis_Date { get; set; }
    public string Last_Updated { get; set; }
    public Dictionary<string, string> Description { get; set; }
    public CoinImageLinks Image { get; set; }
    public CoinGeneralLinks Links { get; set; }
    public Ticker[] Tickers { get; set; }
}
