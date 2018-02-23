using GalaSoft.MvvmLight.Messaging;
using System.Collections.Specialized;
using System.ComponentModel;

namespace AirlinesManagerGame.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged, INotifyCollectionChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public void OnCollectionChanged(NotifyCollectionChangedEventArgs e) => CollectionChanged?.Invoke(this, e);
        //new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, purchasedAirplane)
        protected void SendSwitchViewMessage(string viewName)
        {
            Messenger.Default.Send(viewName);
        }
    }
}
