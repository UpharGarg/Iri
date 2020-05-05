using CsvHelper;
using IRIDemo.ApplicationOperations.Interface;
using IRIDemo.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IRIDemo.ApplicationOperations.Implementation
{
    public class LoadDataFromCsv : ILoadData
    {
        public IEnumerable<T> LoadTableFromCsv<T>() where T : class
        {
            string resourceName = string.Empty;
            if (typeof(T) == typeof(Product))
                resourceName = "IRIDemo.DataContext.SeedData.IRIProducts.csv";
            else
                resourceName = "IRIDemo.DataContext.SeedData.RetailerProducts.csv";

            Assembly assembly = Assembly.GetExecutingAssembly();

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    CsvReader csvReader = new CsvReader(reader, System.Globalization.CultureInfo.CurrentCulture);

                    csvReader.Configuration.HeaderValidated = null;
                    csvReader.Configuration.MissingFieldFound = null;
                    var result = csvReader.GetRecords<T>().ToList();
                    return result;
                }
            }
        }
    }
}
