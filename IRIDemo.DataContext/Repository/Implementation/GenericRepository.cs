using IRIDemo.DataContext;
using IRIDemo.DataContext.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIDemo.DataContext.Repository.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ProductDetailsContext _context = null;
        private DbSet<T> table = null;

        //public GenericRepository()
        //{
        //    this._context = new ProductDetailsContext();
        //    table = _context.Set<T>();
        //}

        public GenericRepository(ProductDetailsContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }
        public void AddRange(IEnumerable<T> data) 
        {
            table.AddRange(data);
        }

        public void AddRange<T1>(IEnumerable<T1> products) where T1 : class
        {
            table.AddRange(products as IEnumerable<T>);
        }

        public void ClearTable()
        {
            table.RemoveRange(table);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Task.Run<IEnumerable<T>>(() => {
                return  table.ToList();
                });
             
        }

        public void Save()
        {
             _context.SaveChanges();
        }
    }
}
