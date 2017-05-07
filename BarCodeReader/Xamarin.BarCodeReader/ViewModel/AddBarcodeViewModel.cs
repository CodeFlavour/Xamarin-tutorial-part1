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
using ZXing;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace Xamarin.BarCodeReader.ViewModel
{
    public class AddBarcodeViewModel
    {
        private ZXingHelper _zXingHelper;
        public ICommand AddBarcodeCommand { get; set; }

        public AddBarcodeViewModel()
        {
            AddBarcodeCommand = new Command(AddBarcode);
            _zXingHelper = new ZXingHelper();
        }

        public async void AddBarcode()
        {
            ZXingScannerView zxing = _zXingHelper.CreateZXingScannerView();
            ZXingDefaultOverlay overlay = _zXingHelper.CreateZXingDefaultOverlay(zxing);

            var scanPage = _zXingHelper.CreateBarcodeScanPage(zxing, overlay);
            await App.Current.MainPage.Navigation.PushAsync(scanPage);
        }
   }
}
