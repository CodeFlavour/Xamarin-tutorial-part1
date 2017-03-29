using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.BarCodeReader.View;
using Xamarin.Forms;

namespace Xamarin.BarCodeReader.ViewModel
{
    public class StartViewModel : INotifyPropertyChanged
    {
        private string _nickName;

        public string NickName
        {
            get
            {
                return _nickName;
            }
            set
            {
                _nickName = value;
                OnPropertyChanged("NickName");
            }
        }

        public ICommand GoToNextPageCommand { get; set; }

        public StartViewModel()
        {
            GoToNextPageCommand = new Command<string>(x => GoToNextPage(x));
           // GoToNextPageCommand = new Command(GoToNextPage); -- Command bez parametru przekazywanego z widoku
                                                               // oraz metoda przypisana do niego bezparametowa 
        }

        public async void GoToNextPage(string nickName)
        {
            await Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new NavigationPage(new SecondView()));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }


    }
}
