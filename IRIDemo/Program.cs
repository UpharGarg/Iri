using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using IRIDemo.ApplicationOperations.Implementation;
using IRIDemo.ApplicationOperations.Interface;
using IRIDemo.DataContext;
using IRIDemo.Model;
using IRIDemo.Repository;
using IRIDemo.Repository.Implementation;
using SimpleInjector;
using SimpleInjector.Diagnostics;
using SimpleInjector.Lifestyles;

namespace IRIDemo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static Container container;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Bootstrap();
            Application.Run(container.GetInstance<Form1>());
        }
        private static void Bootstrap()
        {
            // Create the container as usual.
            container = new Container(); 
            // Register your types, for instance:
            //Assembly[] assemblies = new[] { typeof(PortalRepository).Assembly };

            //container.Register(typeof(IRepository<>), assemblies);
            container.Register<IGenericRepository<Product>, GenericRepository<Product>>(Lifestyle.Singleton);
            container.Register<IGenericRepository<ProductSales>, GenericRepository<ProductSales>>(Lifestyle.Singleton);
            container.Register<IAddData, AddDataToSqlTables>(Lifestyle.Singleton);
            container.Register<ILoadData, LoadDataFromCsv>(Lifestyle.Singleton);
            container.Register<IClearData, ClearDataFromSqlTables>(Lifestyle.Singleton);
            container.Register<IProcessData, ProcessSqlData>(Lifestyle.Singleton);
            container.Register<Form1>(Lifestyle.Singleton); ;
            container.Register<ProductDetailsContext>(Lifestyle.Singleton);
            // Optionally verify the container.
            container.Verify();
        }
    }
}
