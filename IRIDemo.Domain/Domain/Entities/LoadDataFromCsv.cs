using CsvHelper;
using IRIDemo.Common.Constants;
using IRIDemo.Domain.Interface;
using IRIDemo.Models.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace IRIDemo.Domain.Entities
{
    public class LoadDataFromCsv : ILoadData
    {
        public IEnumerable<T> FillDataInTable<T>() where T : class
        {
            string resourceName = string.Empty;
            if (typeof(T) == typeof(Product))
                resourceName = Constants.ProductCsvResourceName;
            else
                resourceName = Constants.RetailerCsvResourceName;

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

        public bool InstanceName(string instance)
        {
            return "csv".Equals(instance.ToLower());
        }
    }
}
