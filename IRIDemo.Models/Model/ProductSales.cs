using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIDemo.Models.Model
{
    public class ProductSales
    { 
        public int Id { get; set; }
        public int ProductId { get; set; }

        public string RetailerName { get; set; }

        public string RetailerProductCode { get; set; }

        public string RetailerProductCodeType { get; set; }

        public DateTime DateReceived { get; set; }
    }
}
