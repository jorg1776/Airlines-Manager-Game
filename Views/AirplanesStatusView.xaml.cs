using System.Windows;
using System.Windows.Controls;

namespace AirlinesManagerGame.Views
{
    public partial class AirplanesStatusView : UserControl
    {
        private readonly AirplanesStatusViewModel viewModel = new AirplanesStatusViewModel();

        public AirplanesStatusView()
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void ButtonStore_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
