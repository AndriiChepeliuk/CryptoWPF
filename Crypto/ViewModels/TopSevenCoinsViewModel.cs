using Crypto.Entities;
using Crypto.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;

namespace Crypto.ViewModels;

public class TopSevenCoinsViewModel : ViewModelBase
{
    private ObservableCollection<CoinTrending> _top7Conins;

    public ObservableCollection<CoinTrending> Top7Conins
    {
        get { return _top7Conins; }
        set
        {
            _top7Conins = value;
            OnPropertyChanged(nameof(Top7Conins));
        }
    }

    public TopSevenCoinsViewModel()
    {
        LoadTopSevenCoins();
    }

    public async Task LoadTopSevenCoins()
    {
        string url = $"https://api.coingecko.com/api/v3/search/trending";

        using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
        {
            if (response.IsSuccessStatusCode)
            {
                Top7Conins = new();
                TopSevenTrendingCoins coins = await response.Content.ReadAsAsync<TopSevenTrendingCoins>();

                foreach (var item in coins.Coins)
                {
                    Top7Conins.Add(item.Coin);
                }
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
