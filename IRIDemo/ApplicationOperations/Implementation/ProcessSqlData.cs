using IRIDemo.ApplicationOperations.Interface;
using IRIDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIDemo.ApplicationOperations.Implementation
{
    public class ProcessSqlData : IProcessData
    {

        public List<ResultType> GetResults<T, T1>(IEnumerable<T> data1, IEnumerable<T1> data2)
            where T : class
            where T1 : class
        {
            List<ResultType> resultTypes = new List<ResultType>();
            var productData = data1 as IEnumerable<Product>;
            var productSalesData = data2 as IEnumerable<ProductSales>;
            var combinedData = from p in productData
                               join s in productSalesData
                               on p.ProductId equals s.ProductId
                               select new
                               {
                                   ProductId = p.ProductId,
                                   ProductName = p.ProductName,
                                   CodeType = s.RetailerProductCodeType,
                                   Code = s.RetailerProductCode,
                                   DateRecieved = s.DateReceived
                               };

            var result = combinedData.GroupBy(x => new { x.ProductId, x.CodeType })
                  .Select(group =>
                        new
                        {
                            ProductKey = group.Key,
                            ProductData = group.OrderByDescending(x => x.DateRecieved).First()
                        });

            foreach (var r in result)
            {
                ResultType resultType = new ResultType();
                resultType.ProductId = r.ProductKey.ProductId;
                resultType.ProductName = r.ProductData.ProductName;
                resultType.CodeType = r.ProductData.CodeType;
                resultType.Code = r.ProductData.Code;

                resultTypes.Add(resultType);

            }

            return resultTypes;
            
        }
    }
     
}
