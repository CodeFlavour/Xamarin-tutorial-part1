using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.BarCodeReader.Events;
using Xamarin.BarCodeReader.Infrastructure;
using Xamarin.BarCodeReader.Model;
using Xamarin.Forms;

namespace Xamarin.BarCodeReader.ViewModel
{
    public class AddBarcodeViewModel
    {
        public ICommand AddBarcodeCommand { get; set; }

        public AddBarcodeViewModel()
        {
            AddBarcodeCommand = new Command(AddBarcode);
        }

        public async void AddBarcode()
        {
            Barcode barcode = new Barcode()
            {
                Country = "PL",
                Code = "Code"
            };

            await App.Current.MainPage.DisplayAlert("Barcode added", "Check barcode list!", "OK");

            AppService.Instance.EventAggregator.GetEvent<BarcodeAdded>().Publish(barcode);
        }


    }
}
