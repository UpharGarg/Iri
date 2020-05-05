using IRIDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIDemo.ApplicationOperations.Interface
{
    public interface IProcessData
    {
        List<ResultType> GetResults<T, T1>(IEnumerable<T> table1, IEnumerable<T1> table2) where T : class where T1 : class;
    }
}
