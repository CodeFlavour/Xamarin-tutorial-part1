using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.BarCodeReader.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.BarCodeReader.View
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddBarcode : ContentPage
    {
        public AddBarcode()
        {
            InitializeComponent();
            BindingContext = new AddBarcodeViewModel();
        }
    }   
}
