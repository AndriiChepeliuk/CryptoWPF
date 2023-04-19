using Crypto.Entities;
using Crypto.Helpers;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Crypto.ViewModels;

public class CoinsViewModel : ViewModelBase
{
    private string _coinId = $"bitcoin";
    private CoinByIdMarketData _coinByIdMarketData;

    public string CoinId
    {
        get { return _coinId; }
        set
        {
            _coinId = value;
            OnPropertyChanged(nameof(CoinId));
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
        LoadCoinData();
        FindCoinCommand = new ViewModelCommand(ExecuteFindCoinCommand);
    }

    private async void ExecuteFindCoinCommand(object obj)
    {
        await LoadCoinData();
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
}
