using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.BarCodeReader.Model
{
    public class Barcode
    {
        private string _country;

        public string Country
        {
            get
            {
                return _country;
            }
            set
            {
                _country = value;
            }
        }

        private string _code;

        public string Code
        {
            get
            {
                return _code;
            }
            set
            {
                _code = value;
            }
        }
    }
}
