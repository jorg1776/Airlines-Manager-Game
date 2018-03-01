using AirlinesManagerGame.Views;
using AirlinesManagerGame.ViewModels;
using System.Windows;

namespace AirlinesManagerGame.Services
{
    public class WindowService
    {
        private Window win;
        private static bool _canDisplayWindow = true;
        public bool CanDisplayWindow { get { return _canDisplayWindow; } }

        public void ShowPurchaseVerificationWindow(PurchaseVerificationViewModel viewModel)
        {
            win = new PurchaseVerificationWindow(viewModel);
            win.Show();
            _canDisplayWindow = false;
        }

        public void CloseWindow() { win.Close(); _canDisplayWindow = true; }
    }
}
