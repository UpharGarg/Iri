using IRIDemo.ApplicationOperations.Interface;
using IRIDemo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIDemo.ApplicationOperations.Implementation
{
    public class ClearDataFromSqlTables : IClearData
    {
        public void ClearDataFromTable<T>(IGenericRepository<T> genericRepository) where T : class
        {
            genericRepository.ClearTable();
            genericRepository.Save();
        }
    }
}
