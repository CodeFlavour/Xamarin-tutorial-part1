using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.BarCodeReader.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.BarCodeReader.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BarcodeList : ContentPage
    {
        public BarcodeList()
        {
            InitializeComponent();
            BindingContext = new BarcodeListViewModel();
        }
    }
}
