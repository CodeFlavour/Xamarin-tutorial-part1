using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.BarCodeReader.Events;
using Xamarin.BarCodeReader.Infrastructure;
using Xamarin.BarCodeReader.Model;
using Xamarin.Forms;

namespace Xamarin.BarCodeReader.ViewModel
{
    public class BarcodeListViewModel 
    {
        public ICommand DeleteBarcodeCommand { get; set; }
        private ObservableCollection<Barcode> _barcodeList;
        public ObservableCollection<Barcode> BarcodeList
        {
            get
            {
                return _barcodeList;
            }
            set
            {
                _barcodeList = value;
            }
        }

        private async void DeleteBarcode(Barcode barcode)
        {
            if(barcode != null)
            {
                var answer = await App.Current.MainPage.DisplayAlert(barcode.Code, "Delete this barcode?", "Yes", "No");
                if (answer)
                {
                    BarcodeList.Remove(barcode);
                    await AppService.Instance.Database.DeleteBarcodesync(barcode);
                }
            }            
        }

        public BarcodeListViewModel()
        {
            AppService.Instance.EventAggregator.GetEvent<BarcodeAdded>()
           .Subscribe((barcode) => { AddBarcodeToList(barcode); });

            DeleteBarcodeCommand = new Command<Barcode>(x => DeleteBarcode(x));
            BarcodeList = GetBarcodeList();
        }

        public async void AddBarcodeToList(Barcode barcode)
        {
            if (barcode != null)
            {
                BarcodeList.Add(barcode);
                await AppService.Instance.Database.SaveItemAsync(barcode);
            }
        }

        public ObservableCollection<Barcode> GetBarcodeList()
        {
            return new ObservableCollection<Barcode>(AppService.Instance.Database.GetBarcodeAsync().Result);
        }
    }
}
