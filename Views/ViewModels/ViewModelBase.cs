using GalaSoft.MvvmLight.Messaging;
using System.ComponentModel;

namespace AirlinesManagerGame.Views.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SendSwitchViewMessage(string viewName)
        {
            Messenger.Default.Send(viewName);
        }
    }
}
