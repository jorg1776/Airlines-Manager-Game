using GalaSoft.MvvmLight.Messaging;
using System.ComponentModel;

namespace AirlinesManagerGame.Views
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected static void SendSwitchViewMessage(string viewName)
        {
            Messenger.Default.Send(viewName);
        }
    }
}
