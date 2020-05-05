using IRIDemo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIDemo.ApplicationOperations.Interface
{
    public interface IClearData
    {
        void ClearDataFromTable<T>(IGenericRepository<T> genericRepository) where T : class;
    }
}
