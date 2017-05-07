using SQLite;

namespace Xamarin.BarCodeReader.Model
{
    public class Barcode
    {
        [PrimaryKey, AutoIncrement]
        public long ID { get; set; }
        public string Country { get; set; }
        [Indexed]
        public string Code { get; set; }
    }
}
