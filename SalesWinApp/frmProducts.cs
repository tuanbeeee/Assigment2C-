using BusinessObject.Repository;
using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesWinApp
{
    public partial class frmProducts : Form
    {
        IProductRepository resp = new ProductRepository();
        public frmProducts()
        {
            InitializeComponent();
        }

        public void LoadProductList()
        {
            try
            {
                FStoreDBContext db = new FStoreDBContext();
                var productList = from c in db.Products
                                  select new
                                  {
                                      ProductId = c.ProductId,
                                      Category = c.Category.CategoryName,
                                      ProductName = c.ProductName,
                                      Weight = c.Weight,
                                      UnitPrice = c.UnitPrice,
                                      UnitslnStock = c.UnitsInStock
                                  };
                BindingSource source = new BindingSource();
                source.DataSource = productList.ToList();

                dgvProducts.DataSource = null;
                dgvProducts.DataSource = source;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of product!");
            }
        }
        private void ClearText()
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            LoadProductList();
        }
    }
}
