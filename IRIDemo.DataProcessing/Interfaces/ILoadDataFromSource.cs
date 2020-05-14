using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIDemo.DataProcessing.Interfaces
{
    public interface ILoadDataFromSource
    {
        IEnumerable<T> LoadProductRelatedDataFromCsv<T>() where T : class;
    }
}
