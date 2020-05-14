using IRIDemo.DataProcessing.Interfaces;
using IRIDemo.Domain.Entities;
using IRIDemo.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIDemo.DataProcessing.Implementation
{
    public class LoadDataFromSource : ILoadDataFromSource
    {
        private readonly List<ILoadData> _loadData;
        public LoadDataFromSource()
        {
            _loadData = new List<ILoadData> { new LoadDataFromCsv() };
        }
        public IEnumerable<T> LoadProductRelatedDataFromCsv<T>() where T : class
        {
            var productCsvData = _loadData.Find(x => x.InstanceName("csv")).FillDataInTable<T>();
            return productCsvData;
        }
    }
}
