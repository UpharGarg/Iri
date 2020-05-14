using IRIDemo.DataContext.Repository.Interface;
using IRIDemo.Domain.Interface;

namespace IRIDemo.Domain.Entities
{
    public class ClearDataFromSqlTables : IClearData
    {
        public void ClearDataFromTable<T>(IGenericRepository<T> genericRepository) where T : class
        {
            genericRepository.ClearTable();
            genericRepository.Save();
        }

        public bool InstanceName(string instance)
        {
            return "sql".Equals(instance.ToLower());
        }
    }
}
