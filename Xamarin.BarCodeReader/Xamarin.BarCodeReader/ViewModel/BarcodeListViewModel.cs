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

        private Barcode _selectedBarcode;

        public Barcode SelectedBarcode
        {
            get
            {
                return _selectedBarcode;
            }
            set
            {
                _selectedBarcode = value;

                if(value != null)
                     DeleteBarcode(_selectedBarcode);                
            }
        }

        private async void DeleteBarcode(Barcode _selectedBarcode)
        {
            var answer = await App.Current.MainPage.DisplayAlert(_selectedBarcode.Code, "Delete this barcode?", "Yes", "No");
            if (answer)
            {
                BarcodeList.Remove(_selectedBarcode);
            }
        }

        public BarcodeListViewModel()
        {
            AppService.Instance.EventAggregator.GetEvent<BarcodeAdded>()
           .Subscribe((barcode) => { AddBarcodeToList(barcode); });

            BarcodeList = new ObservableCollection<Barcode>();
        }

        public void AddBarcodeToList(Barcode barcode)
        {
            if (barcode != null)
            {
                BarcodeList.Add(barcode);
            }
        }
    }
}
