using Crypto.Entities;
using Crypto.Helpers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Crypto.ViewModels;

public class CoinsViewModel : ViewModelBase
{
    private string _coinId = $"bitcoin";
    private string _searchText = $"bitcoin";
    private string _errorMessage;
    private CoinByIdMarketData _coinByIdMarketData;
    private List<CoinSimple> _coinsSearchList;

    public string CoinId
    {
        get { return _coinId; }
        set
        {
            _coinId = value;
            OnPropertyChanged(nameof(CoinId));
        }
    }
    public string SearchText
    {
        get { return _searchText; }
        set
        {
            _searchText = value;
            OnPropertyChanged(nameof(SearchText));
        }
    }
    public string ErrorMessage
    {
        get { return _errorMessage; }
        set
        {
            _errorMessage = value;
            OnPropertyChanged(nameof(ErrorMessage));
        }
    }

    public CoinByIdMarketData CoinByIdMarketData
    {
        get { return _coinByIdMarketData; }
        set
        {
            _coinByIdMarketData = value;
            OnPropertyChanged(nameof(CoinByIdMarketData));
        }
    }

    public ICommand FindCoinCommand { get; }

    public CoinsViewModel()
    {
        LoadCoinsList();
        LoadCoinData();
        FindCoinCommand = new ViewModelCommand(ExecuteFindCoinCommand);
    }

    private async void ExecuteFindCoinCommand(object obj)
    {
        var searchCoin = _coinsSearchList.Find(x => x.Id == SearchText.ToUpper() 
                                            || x.Symbol == SearchText.ToUpper()
                                            || x.Name == SearchText.ToUpper());

        if (searchCoin != null)
        {
            ErrorMessage = "";
            CoinId = searchCoin.Id.ToLower();
            await LoadCoinData();
        }
        else
        {
            ErrorMessage = "Coin not found!";
        }
    }

    private async Task LoadCoinData()
    {
        string url = $"https://api.coingecko.com/api/v3/coins/{CoinId}";

        using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
        {
            if (response.IsSuccessStatusCode)
            {
                var coinById = await response.Content.ReadAsAsync<CoinByIdMarketData>();

                coinById.Symbol = coinById.Symbol.ToUpper();

                CoinByIdMarketData = coinById;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }

    private async Task LoadCoinsList()
    {
        string url = $"https://api.coingecko.com/api/v3/coins/list";

        using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
        {
            if (response.IsSuccessStatusCode)
            {
                var coins = await response.Content.ReadAsAsync<List<CoinSimple>>();

                foreach (var coin in coins)
                {
                    coin.Id = coin.Id.ToUpper();
                    coin.Name = coin.Name.ToUpper();
                    coin.Symbol = coin.Symbol.ToUpper();
                }

                _coinsSearchList = coins;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }

}
