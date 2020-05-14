using IRIDemo.Domain.Base;
using IRIDemo.Models.Model;
using System.Collections.Generic;

namespace IRIDemo.Domain.Interface
{
    public interface IProcessData :Instance
    {
        List<ResultType> GetResults<T, T1>(IEnumerable<T> table1, IEnumerable<T1> table2) where T : class where T1 : class;
    }
}
