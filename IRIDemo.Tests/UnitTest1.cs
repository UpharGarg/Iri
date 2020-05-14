using System;
using System.Collections.Generic;
using System.Linq;
using IRIDemo.Domain.Entities;
using IRIDemo.Domain.Interface;
using IRIDemo.Models.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IRIDemo.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private readonly IProcessData _processData;
        List<Product> _product = new List<Product>();
        List<ProductSales> _productSales = new List<ProductSales>();
        public UnitTest1()
        {
            _processData = new ProcessSqlData();
        }
        [TestInitialize]
        public void SetUp()
        {
           
            _product.Add(new Product
            {
                ProductId = 18886,
                ProductName = "FISH OIL"
            });
            
            _productSales.Add(new ProductSales
            {
                ProductId = 18886,
                RetailerName = "DDS",
                RetailerProductCode = "93482745",
                RetailerProductCodeType = "Barcode",
                DateReceived = new DateTime(2010, 05, 16)
            });
            _productSales.Add(new ProductSales
            {
                ProductId = 18886,
                RetailerName = "Woolworths",
                RetailerProductCode = "F8CE71964FAC90E59164FDB6AA19B10A",
                RetailerProductCodeType = "Woolworths Ref",
                DateReceived = new DateTime(2017, 05, 09)
            });
            _productSales.Add(new ProductSales
            {
                ProductId = 18886,
                RetailerName = "Woolworths",
                RetailerProductCode = "017E9562042C3E9F0E1D200A8C915052",
                RetailerProductCodeType = "Woolworths Ref",
                DateReceived = new DateTime(2017, 10, 03)
            });
            _productSales.Add(new ProductSales
            {
                ProductId = 18886,
                RetailerName = "Coles",
                RetailerProductCode = "93482745",
                RetailerProductCodeType = "Barcode",
                DateReceived = new DateTime(2006, 04, 23)
            });
    }
    


            [TestMethod]
            public void GetResults_Test()
            {

            List<ResultType> result = _processData.GetResults(_product, _productSales);
            //assert we get two records
            Assert.AreEqual(ExpectedResult().Count , result.Count()); 
            Assert.AreEqual(ExpectedResult()[0].Code, result[0].Code);
            Assert.AreEqual(ExpectedResult()[1].Code, result[1].Code);
            Assert.AreEqual(ExpectedResult()[0].CodeType, result[0].CodeType);
            Assert.AreEqual(ExpectedResult()[1].CodeType, result[1].CodeType);

        }

        private List<ResultType> ExpectedResult()
        {

            List<ResultType> r = new List<ResultType>();
            r.Add(new ResultType
            {
                ProductId = 1886,
                ProductName = "FISH OIL",
                CodeType = "Barcode",
                Code = "93482745"
            });
            r.Add(new ResultType
            {
                ProductId = 1886,
                ProductName = "FISH OIL",
                CodeType = "Woolworths Ref",
                Code = "017E9562042C3E9F0E1D200A8C915052"
            });

            return r;

        }
       
}
    
}
