using IRIDemo.ApplicationOperations.Interface;
using IRIDemo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIDemo.ApplicationOperations.Implementation
{
    public class AddDataToSqlTables : IAddData
    {
        public void AddDataToTable<T>(IGenericRepository<T> genericRepository, IEnumerable<T> data) where T : class
        {
            genericRepository.AddRange(data);
            genericRepository.Save();
        }
    }
}
