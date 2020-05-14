using IRIDemo.DataContext;
using IRIDemo.DataContext.Repository.Implementation;
using IRIDemo.DataContext.Repository.Interface;
using IRIDemo.DataProcessing.Interfaces;
using IRIDemo.DataProcessing.Implementation;
using IRIDemo.Models.Model;
using SimpleInjector;
using System;
using System.Windows.Forms;

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
            container.Register<IShowResult, ShowResults>(Lifestyle.Singleton);
            container.Register<IAddDataInTable, IAddDataInTable>(Lifestyle.Singleton);
            container.Register<ILoadDataFromSource, LoadDataFromSource>(Lifestyle.Singleton);
            container.Register<IClearDataFromTable, ClearDataFromTable>(Lifestyle.Singleton);
            container.Register<Form1>(Lifestyle.Singleton); ;
            container.Register<ProductDetailsContext>(Lifestyle.Singleton);
            // Optionally verify the container.
            container.Verify();
        }
    }
}
