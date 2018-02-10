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
        }
    }
}
