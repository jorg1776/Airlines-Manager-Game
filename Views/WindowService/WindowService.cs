using System.Windows;

namespace AirlinesManagerGame.Views.WindowService
{
    public class WindowService
    {
        private Window win;

        public void ShowPurchaseVerificationWindow(ViewModels.PurchaseVerificationViewModel viewModel)
        {
            win = new PurchaseVerificationWindow(viewModel);
            win.Show();
        }

        public void CloseWindow() { win.Close(); }
    }
}
