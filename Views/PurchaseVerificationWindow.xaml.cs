using System.Windows;

namespace AirlinesManagerGame.Views
{
    public partial class PurchaseVerificationWindow : Window
    {
        public PurchaseVerificationWindow(ViewModels.PurchaseVerificationViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
