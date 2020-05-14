using System.Collections.Generic;
using System.Threading.Tasks;

namespace IRIDemo.DataContext.Repository.Interface
{
    public interface IGenericRepository<T> where T: class
    {
        Task<IEnumerable<T>> GetAllAsync();

        void AddRange<T1>(IEnumerable<T1> products) where T1:class;

        void ClearTable();

        void Save();
       
    }
}
