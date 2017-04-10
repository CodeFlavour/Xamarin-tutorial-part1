using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.BarCodeReader.Model;

namespace Xamarin.BarCodeReader.Events
{
    public class BarcodeAdded : PubSubEvent<Barcode>
    {

    }
}
