using CsvHelper;
using IRIDemo.ApplicationOperations.Interface;
using IRIDemo.DataContext;
using IRIDemo.Model;
using IRIDemo.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IRIDemo
{
    public partial class Form1 : Form
    {
        /*
         * Injecting dependencies to perform seperate tasks required via constructor
         */
        //Repositories for product and product sales data
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductSales> _productSalesRepo;
        //for inserting data into database
        private readonly IAddData _addData;
        // for loading data from csv file
        private readonly ILoadData _loadData;
        // clears exsiting data from database
        private readonly IClearData _clearData;
        // process data to generate required output/report
        private readonly IProcessData _processData;
        public Form1(IGenericRepository<Product> productRepo, IGenericRepository<ProductSales> productSalesRepo,
            IAddData addData, ILoadData loadData, IClearData clearData, IProcessData processData)
        {
            _productRepo = productRepo;
            _productSalesRepo = productSalesRepo;
            _addData = addData;
            _loadData = loadData;
            _clearData = clearData;
            _processData = processData;

            InitializeComponent();

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            loader.Visible = true; 
            loader.Dock = DockStyle.Fill;
            try
            {                
                var productData = await _productRepo.GetAllAsync();
                var productSalesData = await _productSalesRepo.GetAllAsync();
                if (productData != null && productData.Count() > 0 && productSalesData != null && productSalesData.Count() > 0)
                {
                    //ToDo : this should be ideally taken as an input from user
                    // Done this way to save some time, creating a folder on C Drive to save output 
                    string folderName = @"C:\IRIDemo";
                    Directory.CreateDirectory(folderName);
                    string fileName = Path.Combine(folderName, "Output.txt");
                    // generate the output
                    GetResults(productData, productSalesData, fileName);

                }
                else
                {
                    MessageBox.Show("No data is available. Please click on load data first");
                    loader.Visible = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Unexpected error encountered during processing {ex.Message}");
                loader.Visible = false;
            }
            


            


        }

        private void GetResults(IEnumerable<Product> productData, IEnumerable<ProductSales> productSalesData, string path)
        {
            string route = @path;
            FileStream fs = new FileStream(route, FileMode.Create, FileAccess.ReadWrite);
            using (var sw = new StreamWriter(fs))
            {
                foreach (ResultType r in _processData.GetResults(productData, productSalesData))
                {
                    sw.WriteLine(string.Format("Prodcut Id : {0}  Product Name : {1}   CodeType : {2}  Code : {3} ",
                        r.ProductId, r.ProductName, r.CodeType, r.Code));
                }

                MessageBox.Show(string.Format("Please check result at {0}", route));
                loader.Visible = false;
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            //added loader
            loader.Visible = true;
            loader.Dock = DockStyle.Fill;
            var productData = await _productRepo.GetAllAsync();
            var productSalesData = await _productSalesRepo.GetAllAsync();
            if (productData.Count() > 0 && productSalesData.Count() > 0)
            {
                DialogResult dialogResult = MessageBox.Show("This will delete existing data before loading new dataset . Do you want to continue ?", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ClearDataFromTables();
                    AddDataToTables();
                    MessageBox.Show(string.Format("Data reload successful. Please click view results to view the output"));
                    loader.Visible = false;
                }
                else
                {
                    //ToDo : Handle scenario where user declines to load data, probably give a warning about 
                    // using stale data
                    // this.Close();
                    loader.Visible = false;
                }
            }
            else
            {
                //load data if this is done very first time
                ClearDataFromTables();
                AddDataToTables();
                loader.Visible = false;
            }

        }
        private void ClearDataFromTables()
        {
            _clearData.ClearDataFromTable(_productSalesRepo);
            _clearData.ClearDataFromTable(_productRepo);
        }

        private IEnumerable<T> LoadProductRelatedDataFromCsv<T>() where T : class
        {

            var productCsvData = _loadData.LoadTableFromCsv<T>();
            return productCsvData;
        }
        private void AddDataToTables()
        {
            _addData.AddDataToTable(_productRepo, LoadProductRelatedDataFromCsv<Product>());

            _addData.AddDataToTable(_productSalesRepo, LoadProductRelatedDataFromCsv<ProductSales>());
        }


    }
}
