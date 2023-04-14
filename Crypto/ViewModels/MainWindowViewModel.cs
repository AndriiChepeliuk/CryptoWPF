using FontAwesome.Sharp;
using System;
using System.Windows.Input;

namespace Crypto.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private ViewModelBase _currentChildView;
    private string _caption;
    private IconChar _icon;

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
    public string Caption
    {
        get
        {
            return _caption;
        }
        set
        {
            _caption = value;
            OnPropertyChanged(nameof(Caption));
        }
    }
    public IconChar Icon
    {
        get
        {
            return _icon;
        }
        set
        {
            _icon = value;
            OnPropertyChanged(nameof(Icon));
        }
    }

    public ICommand ShowTopTenCurrencies { get; }
    public ICommand ShowCoins { get; }

    public MainWindowViewModel()
    {
        ShowTopTenCurrencies = new ViewModelCommand(ExecuteShowTopTenCurrenciesViewCommand);
        ShowCoins = new ViewModelCommand(ExecuteShowCoinsViewCommand);

        ExecuteShowTopTenCurrenciesViewCommand(null);
    }

    private void ExecuteShowCoinsViewCommand(object obj)
    {
        CurrentChildView = new CoinsViewModel();
        Caption = "Coins";
        Icon = IconChar.Coins;
    }

    private void ExecuteShowTopTenCurrenciesViewCommand(object obj)
    {
        CurrentChildView = new TopTenCurrenciesViewModel();
        Caption = "Top 10 currencies";
        Icon = IconChar.ArrowUpRightDots;
    }
}
