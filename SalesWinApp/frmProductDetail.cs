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
    public partial class frmProductDetail : Form
    {
        public bool InsertOrUpdate { get; set; }
        public Product Product { get; set; }
        public IProductRepository ProductRepository = new ProductRepository();
        public frmProductDetail()
        {
            InitializeComponent();
        }

        private void frmProductDetail_Load(object sender, EventArgs e)
        {
            txtProductID.Enabled = false;

            if (InsertOrUpdate == true)
            {
                txtProductID.Text = Product.ProductId.ToString();
                txtWeight.Text = Product.Weight.ToString();
                txtUnitPrice.Text = Product.UnitPrice.ToString();
                txtUnitslnStock.Text = Product.UnitsInStock.ToString();
                txtProductName.Text = Product.ProductName.ToString();

                FStoreDBContext db = new FStoreDBContext();
                var categoryName = from c in db.Categories
                                   select c.CategoryName.ToString();
                foreach (var i in categoryName)
                {
                    cbCategoryName.Items.Add(i);
                }
                var catename = db.Categories.SingleOrDefault(pro => pro.CategoryId == Product.CategoryId);
                cbCategoryName.Text = catename.CategoryName;

            }
            else
            {
                string Numrd;
                Random rd = new Random();
                Numrd = rd.Next(1, 20000).ToString();
                txtProductID.Text = Numrd;
                
                FStoreDBContext db = new FStoreDBContext();
                var categoryName = from c in db.Categories
                                   select c.CategoryName.ToString();
                foreach (var i in categoryName)
                {
                    cbCategoryName.Items.Add(i);
                }

            }
        }

        private void cbCategoryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCategoryName.SelectedItem.ToString().Equals("Drink"))
            {
                lbWeight.Text = "ml";
            }
            else if (cbCategoryName.SelectedItem.ToString().Equals("Food"))
            {
                lbWeight.Text = "g";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                FStoreDBContext db = new FStoreDBContext();
                var cateID = db.Categories.SingleOrDefault(pro => pro.CategoryName.Equals(cbCategoryName.SelectedItem.ToString()));
                int id = cateID.CategoryId;

                var product = new Product
                {
                    ProductId = int.Parse(txtProductID.Text),
                    CategoryId = id,
                    ProductName = txtProductName.Text,
                    Weight = txtWeight.Text + lbWeight.Text,
                    UnitPrice = Decimal.Parse(txtUnitPrice.Text),
                    UnitsInStock =int.Parse(txtUnitslnStock.Text)

                };
                if (InsertOrUpdate == true)
                {
                    ProductRepository.UpdateProduct(product);
                }
                else
                {
                    ProductRepository.SaveProduct(product);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Product detail");
            }
        }

        private void txtUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void txtUnitslnStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
    }
}
