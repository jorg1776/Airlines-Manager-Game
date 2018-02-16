using GalaSoft.MvvmLight.Messaging;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AirlinesManagerGame.Views.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            System.Console.WriteLine("OnPropChange " + propertyName);
        }

        protected void SendSwitchViewMessage(string viewName)
        {
            Messenger.Default.Send(viewName);
        }
    }
}
