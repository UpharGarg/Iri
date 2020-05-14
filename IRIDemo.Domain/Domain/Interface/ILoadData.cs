using IRIDemo.Domain.Base;
using System.Collections.Generic;

namespace IRIDemo.Domain.Interface
{
    public interface ILoadData : Instance
    { 
        IEnumerable<T> FillDataInTable<T>() where T : class;
    }
}
