using AirlinesManagerGame.Views;
using AirlinesManagerGame.ViewModels;
using System.Windows;

namespace AirlinesManagerGame.Services
{
    public class WindowService
    {
        private Window win;

        public void ShowPurchaseVerificationWindow(PurchaseVerificationViewModel viewModel)
        {
            win = new PurchaseVerificationWindow(viewModel);
            win.Show();
        }

        public void CloseWindow() { win.Close(); }
    }
}
