using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIDemo.ApplicationOperations.Interface
{
    public interface ILoadData
    {
        IEnumerable<T> LoadTableFromCsv<T>() where T : class;
    }
}
