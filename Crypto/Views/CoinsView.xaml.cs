using Crypto.ViewModels;
using System.Windows.Controls;
using System.Windows.Input;

namespace Crypto.Views
{
    /// <summary>
    /// Interaction logic for CoinsView.xaml
    /// </summary>
    public partial class CoinsView : UserControl
    {
        public CoinsView()
        {
            InitializeComponent();
        }

        private void customersDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var dataContext = DataContext as CoinsViewModel;
            if (dataContext != null)
            {
                dataContext.OpenTickerUrlCommand.Execute(this);
            }
        }
    }
}
