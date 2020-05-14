using IRIDemo.Common.Helper;
using IRIDemo.DataContext.Repository.Interface;
using IRIDemo.DataProcessing.Interfaces;
using IRIDemo.Models.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        private IEnumerable<Product> _products;
        private IEnumerable<ProductSales> _retailerSales;
        private IShowResult _showResult;
        private IAddDataInTable _addDataInTable;
        private IClearDataFromTable _clearDataFromTable;
        public Form1(IGenericRepository<Product> productRepo, IGenericRepository<ProductSales> productSalesRepo,
            IShowResult showResult, IAddDataInTable addDataInTable, IClearDataFromTable clearDataFromTable)
        {
            _productRepo = productRepo;
            _productSalesRepo = productSalesRepo;
            _showResult = showResult;
            _addDataInTable = addDataInTable;
            _clearDataFromTable = clearDataFromTable;
            LoadDataInRepositoriesAsync();
            InitializeComponent();

        }

        private async void LoadDataInRepositoriesAsync()
        {
            _products = await _productRepo.GetAllAsync();
            _retailerSales = await _productSalesRepo.GetAllAsync();
        }


        private void ViewResults_Click(object sender, EventArgs e)
        {
            ShowLoader(); 
            try
            {
                if (_products?.Count() > 0 && _retailerSales?.Count() > 0)
                {
                    string route = _showResult.GetResults(_products, _retailerSales, Helper.CreateDirectoryandFile());
                    ShowMessageBox("Please check result at", route);
                    HideLoader();
                }
                else
                {
                    ShowMessageBox("No data is available. Please click on load data first" , string.Empty);
                    HideLoader();
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox("Unexpected error encountered during processing", ex.Message);
                HideLoader();
            }

        }

       
        private void LoadData_Click(object sender, EventArgs e)
        {
            ShowLoader();
            if (_products?.Count() > 0 && _retailerSales?.Count() > 0)
            {
                DialogResult dialogResult = MessageBox.Show("This will delete existing data before loading new dataset . Do you want to continue ?", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    _clearDataFromTable.ClearDataFromTables(_productRepo, _productSalesRepo);
                    _addDataInTable.AddDataToTables(_productRepo, _productSalesRepo);
                    ShowMessageBox("Data reload successful. Please click view results to view the output" ,string.Empty);
                    loader.Visible = false;
                }
                else
                    HideLoader();
            }
            else
            {
                //load data if this is done very first time
                _clearDataFromTable.ClearDataFromTables(_productRepo, _productSalesRepo);
                _addDataInTable.AddDataToTables(_productRepo, _productSalesRepo);
                HideLoader();
            }

        }
        private void ShowLoader()
        {   //added loader
            loader.Visible = true;
            loader.Dock = DockStyle.Fill;
        }

        private void HideLoader() { loader.Visible = false; }

        private void ShowMessageBox( string message , string param)
        {
            MessageBox.Show($"{message} {param}");
        }
    }
}
