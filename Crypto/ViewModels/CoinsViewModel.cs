using Crypto.Entities;
using Crypto.Helpers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Diagnostics;
using FontAwesome.Sharp;

namespace Crypto.ViewModels;

public class CoinsViewModel : ViewModelBase
{
    private string _coinId = $"bitcoin";
    private string _searchText = $"bitcoin";
    private string _errorMessage;
    private CoinByIdMarketData _coinByIdMarketData;
    private List<CoinSimple> _coinsSearchList;
    private string _coinColor;
    private IconChar _chartIcon;
    private Ticker _seletedTicker;
    private decimal _usd;
    private decimal _coin;

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
    public string CoinColor
    {
        get { return _coinColor; }
        set
        {
            _coinColor = value;
            OnPropertyChanged(nameof(CoinColor));
        }
    }
    public IconChar ChartIcon
    {
        get
        {
            return _chartIcon;
        }
        set
        {
            _chartIcon = value;
            OnPropertyChanged(nameof(ChartIcon));
        }
    }
    public Ticker SeletedTicker
    {
        get { return _seletedTicker; }
        set
        {
            _seletedTicker = value;
            OnPropertyChanged(nameof(SeletedTicker));
        }
    }
    public decimal USD
    {
        get { return _usd; }
        set
        {
            _usd = value;
            OnPropertyChanged(nameof(USD));
        }
    }
    public decimal Coin
    {
        get { return _coin; }
        set
        {
            _coin = value;
            decimal? val;
            if (_coinByIdMarketData.MarketData.CurrentPrice.TryGetValue("usd", out val))
            {
                _usd = val.Value * _coin;
            }
            OnPropertyChanged(nameof(Coin));
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
    public ICommand OpenUrlCommand { get; }
    public ICommand OpenTickerUrlCommand { get; }

    public CoinsViewModel()
    {
        LoadCoinsList();
        LoadCoinData();
        FindCoinCommand = new ViewModelCommand(ExecuteFindCoinCommand);
        OpenUrlCommand = new ViewModelCommand(ExecuteOpenUrlCommand);
        OpenTickerUrlCommand = new ViewModelCommand(ExecuteOpenTickerUrlCommand);
    }

    private void ExecuteOpenTickerUrlCommand(object obj)
    {
        if (SeletedTicker.TradeUrl != null)
        {
            Process.Start(new ProcessStartInfo { FileName = SeletedTicker.TradeUrl, UseShellExecute = true });
        }

    }

    private void ExecuteOpenUrlCommand(object obj)
    {
        Process.Start(new ProcessStartInfo { FileName = (string)obj, UseShellExecute = true });
    }

    private async void ExecuteFindCoinCommand(object obj)
    {
        var searchCoin = _coinsSearchList.Find(x => x.Id == SearchText.ToUpper());

        if (searchCoin == null)
        {
            searchCoin = _coinsSearchList.Find(x => x.Symbol == SearchText.ToUpper()
                                                || x.Name == SearchText.ToUpper());
        }

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

                if (coinById.MarketData.PriceChangePercentage24H < 0)
                {
                    CoinColor = "Red";
                    ChartIcon = IconChar.SortDown;
                }
                else
                {
                    CoinColor = "Green";
                    ChartIcon = IconChar.SortUp;
                }

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
