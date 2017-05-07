using System.IO;
using Xamarin.Forms;
using Xamarin.BarCodeReader.UWP;
using Windows.Storage;
using Xamarin.BarCodeReader.Infrastructure;

[assembly: Dependency(typeof(FileHelper))]
namespace Xamarin.BarCodeReader.UWP
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }
    }
}
