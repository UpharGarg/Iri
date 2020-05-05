using IRIDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIDemo.Repository
{
    public interface IGenericRepository<T> where T: class
    {
        Task<IEnumerable<T>> GetAllAsync();

        void AddRange<T1>(IEnumerable<T1> products) where T1:class;

        void ClearTable();

        void Save();
       
    }
}
