using IRIDemo.DataContext.Repository.Interface;
using IRIDemo.Domain.Interface;
using System.Collections.Generic;

namespace IRIDemo.Domain.Entities
{
    public class AddDataToSqlTables : IAddData
    {
        public void AddDataToTable<T>(IGenericRepository<T> genericRepository, IEnumerable<T> data) where T : class
        {
            genericRepository.AddRange(data);
            genericRepository.Save();
        }

        public bool InstanceName(string instance)
        {
            return "sql".Equals(instance.ToLower());
        }
    }
}
