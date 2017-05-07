using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.BarCodeReader.DAL;
using Xamarin.Forms;

namespace Xamarin.BarCodeReader.Infrastructure
{
    public class AppService
    {
        private AppService() { }

        private static readonly AppService _instance = new AppService();

        internal static AppService Instance { get { return _instance; } }

        private IEventAggregator _eventAggregator;
        internal IEventAggregator EventAggregator
        {
            get
            {
                if (_eventAggregator == null)
                    _eventAggregator = new EventAggregator();

                return _eventAggregator;
            }
        }
        private static BarcodeReaderLocalDB database;

        public BarcodeReaderLocalDB Database
        {
            get
            {
                if (database == null)
                {
                    database = new BarcodeReaderLocalDB(DependencyService.Get<IFileHelper>().GetLocalFilePath("BarcodeSQLite.db3"));
                }
                return database;
            }
        }

    }
}
