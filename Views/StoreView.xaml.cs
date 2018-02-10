using AirlinesManagerGame.Views.ViewModels;
using System.Windows.Controls;

namespace AirlinesManagerGame.Views
{
    /// <summary>
    /// Interaction logic for StoreWindow.xaml
    /// </summary>
    public partial class StoreView : UserControl
    {
        private readonly StoreViewModel viewModel = new StoreViewModel();

        public StoreView()
        {
            InitializeComponent();
        }
    }
}
