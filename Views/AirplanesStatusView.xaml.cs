using System.Windows.Controls;
using AirlinesManagerGame.Views.ViewModels;

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
