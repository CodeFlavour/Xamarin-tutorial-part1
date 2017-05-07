using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.BarCodeReader.Droid;
using Xamarin.BarCodeReader.Infrastructure;

[assembly: Dependency(typeof(FileHelper))]
namespace Xamarin.BarCodeReader.Droid
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}
