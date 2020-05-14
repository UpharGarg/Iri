using IRIDemo.DataContext.Repository.Interface;
using IRIDemo.Domain.Base;
using System.Collections.Generic;

namespace IRIDemo.Domain.Interface
{
    public interface IAddData : Instance
    {
        void AddDataToTable<T>(IGenericRepository<T> genericRepository, IEnumerable<T> data) where T : class;
    }
}
