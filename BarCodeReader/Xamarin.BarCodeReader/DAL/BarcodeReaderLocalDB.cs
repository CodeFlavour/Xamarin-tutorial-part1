using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.BarCodeReader.Model;

namespace Xamarin.BarCodeReader.DAL
{
    public class BarcodeReaderLocalDB
    {
        readonly SQLiteAsyncConnection database;

        public BarcodeReaderLocalDB(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Barcode>().Wait();
        }

        public Task<List<Barcode>> GetBarcodeAsync()
        {
            return database.Table<Barcode>().ToListAsync();
        }

        public Task<List<Barcode>> GetBarcodeAsyncSQLQuery()
        {
            return database.QueryAsync<Barcode>("SELECT * FROM [Barcode]");
        }

        public Task<Barcode> GetBarcodeAsync(int id)
        {
            return database.Table<Barcode>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task SaveItemAsync(Barcode item)
        {
            try
            {
                var dbObject = database.Table<Barcode>().Where(i => i.Code == item.Code).FirstOrDefaultAsync();
                if (dbObject.Result != null)
                {
                    dbObject.Result.Country = item.Country;
                    return database.UpdateAsync(dbObject.Result);
                }
                else
                {
                    return database.InsertAsync(item);
                }            
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task DeleteBarcodesync(Barcode item)
        {
            try
            {
                var dbObject = database.Table<Barcode>().Where(i => i.Code == item.Code).FirstOrDefaultAsync();
                return database.DeleteAsync(dbObject);
            }
             catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
