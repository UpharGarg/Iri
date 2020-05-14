using IRIDemo.DataContext.Repository.Interface;
using IRIDemo.Domain.Base;

namespace IRIDemo.Domain.Interface
{
    public interface IClearData : Instance
    {
        void ClearDataFromTable<T>(IGenericRepository<T> genericRepository) where T : class;
    }
}
