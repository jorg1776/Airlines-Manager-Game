using GalaSoft.MvvmLight;
using System.Windows;

namespace AirlinesManagerGame.Views.WindowService
{
    public class WindowService
    {
        public void ShowPurchaseVerificationWindow(ViewModels.PurchaseVerificationViewModel viewModel)
        {
            var win = new PurchaseVerificationWindow(viewModel);
            win.Show();
        }
    }
}
