using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.BarCodeReader.Events;
using Xamarin.BarCodeReader.Model;
using Xamarin.Forms;
using ZXing;
using ZXing.Net.Mobile.Forms;

namespace Xamarin.BarCodeReader.Infrastructure
{
    public class ZXingHelper
    {
        public ZXingScannerView CreateZXingScannerView()
        {
            var zXingScannerView = new ZXingScannerView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                AutomationId = "zxingScannerView",
                IsAnalyzing = true,
                IsScanning = true
            };

            zXingScannerView.OnScanResult += (result) => {

                zXingScannerView.IsScanning = false;
                zXingScannerView.IsAnalyzing = false;


                Device.BeginInvokeOnMainThread(() => {
                    App.Current.MainPage.Navigation.PopAsync();
                    Barcode barcode = new Barcode();
                    barcode.Code = result.Text;
                    barcode.Country = result.ResultMetadata.FirstOrDefault(x => x.Key == ResultMetadataType.POSSIBLE_COUNTRY).Value as string;

                    AppService.Instance.EventAggregator.GetEvent<BarcodeAdded>().Publish(barcode);

                    App.Current.MainPage.DisplayAlert("Scanned Barcode", result.Text, "OK");
                });
            };

            return zXingScannerView;
        }

        public ZXingDefaultOverlay CreateZXingDefaultOverlay(ZXingScannerView zxing)
        {

            var overlay = new ZXingDefaultOverlay
            {
                TopText = "Hold your phone up to the barcode",
                BottomText = "Scanning will happen automatically",
                ShowFlashButton = zxing.HasTorch,
                AutomationId = "zxingDefaultOverlay",
            };
            overlay.FlashButtonClicked += (sender, e) => {
                zxing.IsTorchOn = !zxing.IsTorchOn;
            };

            return overlay;
        }

        public ContentPage CreateBarcodeScanPage(ZXingScannerView zXingScannerView, ZXingDefaultOverlay zXingDefaultOverlay)
        {
            var grid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            grid.Children.Add(zXingScannerView);
            grid.Children.Add(zXingDefaultOverlay);
            var contentPage = new ContentPage();
            contentPage.Content = grid;

            return contentPage;
        }

    }
}
