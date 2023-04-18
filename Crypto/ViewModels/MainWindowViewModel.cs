using Crypto.Helpers;
using FontAwesome.Sharp;
using System;
using System.Windows.Input;

namespace Crypto.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private ViewModelBase _currentChildView;

    public ViewModelBase CurrentChildView
    {
        get
        {
            return _currentChildView;
        }
        set
        {
            _currentChildView = value;
            OnPropertyChanged(nameof(CurrentChildView));
        }
    }

    public ICommand ShowTopTenCurrencies { get; }
    public ICommand ShowCoins { get; }

    public MainWindowViewModel()
    {
        ApiHelper.InitializeClient();

        ShowTopTenCurrencies = new ViewModelCommand(ExecuteShowTopTenCurrenciesViewCommand);
        ShowCoins = new ViewModelCommand(ExecuteShowCoinsViewCommand);

        ExecuteShowTopTenCurrenciesViewCommand(null);
    }

    private void ExecuteShowCoinsViewCommand(object obj)
    {
        CurrentChildView = new CoinsViewModel();
    }

    private void ExecuteShowTopTenCurrenciesViewCommand(object obj)
    {
        CurrentChildView = new TopSevenCoinsViewModel();
    }
}
