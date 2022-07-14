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
        BindingSource source;
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
                                      UnitslnStock = c.UnitsInStock,
                                      CategoryID = c.CategoryId
                                  };
                source = new BindingSource();
                source.DataSource = productList.ToList();

                txtProductID.DataBindings.Clear();
                txtCategory.DataBindings.Clear();
                txtProductName.DataBindings.Clear();
                txtWeight.DataBindings.Clear();
                txtUnitPrice.DataBindings.Clear();
                txtUnitslnStock.DataBindings.Clear();
                txtCateID.DataBindings.Clear();

                txtProductID.DataBindings.Add("Text", source, "ProductID");
                txtCategory.DataBindings.Add("Text", source, "Category");
                txtProductName.DataBindings.Add("Text", source, "ProductName");
                txtWeight.DataBindings.Add("Text", source, "Weight");
                txtUnitPrice.DataBindings.Add("Text", source, "UnitPrice");
                txtUnitslnStock.DataBindings.Add("Text", source, "UnitslnStock");
                txtCateID.DataBindings.Add("Text", source, "CategoryID");

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

        public Product GetProductObject()
        {
            Product pro = null;
            try
            {
                pro = new Product
                {
                    ProductId = int.Parse(txtProductID.Text),
                    CategoryId = int.Parse(txtCateID.Text),
                    ProductName = txtProductName.Text,
                    Weight = txtWeight.Text,
                    UnitPrice = Decimal.Parse(txtUnitPrice.Text),
                    UnitsInStock = int.Parse(txtUnitslnStock.Text)
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get product object");
            }
            return pro;
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            LoadProductList();
        }

        private void dgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmProductDetail frmProductDetail = new frmProductDetail
            {
                Text = "Update Product",
                Product = GetProductObject(),
                InsertOrUpdate = true
            };
            if (frmProductDetail.ShowDialog() == DialogResult.OK)
            {
                LoadProductList();
                source.Position = source.Count - 1;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            frmProductDetail frmProductDetail = new frmProductDetail
            {
                Text = "Create Product",
                InsertOrUpdate = false
            };
            if (frmProductDetail.ShowDialog() == DialogResult.OK)
            {
                LoadProductList();
                source.Position = source.Count - 1;
            }
        }

        private void SearchByName (string searchName)
        {
            try
            {
                List<Product> p = resp.GetListProduct();
            List<Product> list = new List<Product>();
            foreach (var result in p)
            {
                if (result.ProductName.Contains(searchName))
                {
                    list.Add(result);
                }
            }

                BindingSource source = new BindingSource() ;
                source.DataSource = list.ToList();

                txtProductID.DataBindings.Clear();
                txtCategory.DataBindings.Clear();
                txtProductName.DataBindings.Clear();
                txtWeight.DataBindings.Clear();
                txtUnitPrice.DataBindings.Clear();
                txtUnitslnStock.DataBindings.Clear();


                txtProductID.DataBindings.Add("Text", source, "ProductID");
                txtCategory.DataBindings.Add("Text", source, "CategoryID");
                txtProductName.DataBindings.Add("Text", source, "ProductName");
                txtWeight.DataBindings.Add("Text", source, "Weight");
                txtUnitPrice.DataBindings.Add("Text", source, "UnitPrice");
                txtUnitslnStock.DataBindings.Add("Text", source, "UnitsInStock");



                
               
                if (list.Count() == 0)
                {

                    EmptyText();
                    btnDelete.Enabled = false;
                    MessageBox.Show("Nothing to show");

                }
                else
                {
                    dgvProducts.DataSource = source;
                    btnDelete.Enabled = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SearchByID(int searchID)
        {
            try
            {
                List<Product> p = resp.GetListProduct();
                List<Product> list = new List<Product>();
                foreach (var result in p)
                {
                    if (result.ProductId == (searchID))
                    {
                        list.Add(result);
                    }
                }

                BindingSource source = new BindingSource();
                source.DataSource = list.ToList();

                txtProductID.DataBindings.Clear();
                txtCategory.DataBindings.Clear();
                txtProductName.DataBindings.Clear();
                txtWeight.DataBindings.Clear();
                txtUnitPrice.DataBindings.Clear();
                txtUnitslnStock.DataBindings.Clear();


                txtProductID.DataBindings.Add("Text", source, "ProductID");
                txtCategory.DataBindings.Add("Text", source, "CategoryID");
                txtProductName.DataBindings.Add("Text", source, "ProductName");
                txtWeight.DataBindings.Add("Text", source, "Weight");
                txtUnitPrice.DataBindings.Add("Text", source, "UnitPrice");
                txtUnitslnStock.DataBindings.Add("Text", source, "UnitsInStock");





                if (list.Count() == 0)
                {

                    EmptyText();
                    btnDelete.Enabled = false;
                    MessageBox.Show("Nothing to show");

                }
                else
                {
                    dgvProducts.DataSource = source;
                    btnDelete.Enabled = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SearchByUnitPrice(Decimal searchUnitPrice)
        {
            try
            {
                List<Product> p = resp.GetListProduct();
                List<Product> list = new List<Product>();
                foreach (var result in p)
                {
                    if (result.UnitPrice == (searchUnitPrice))
                    {
                        list.Add(result);
                    }
                }

                BindingSource source = new BindingSource();
                source.DataSource = list.ToList();

                txtProductID.DataBindings.Clear();
                txtCategory.DataBindings.Clear();
                txtProductName.DataBindings.Clear();
                txtWeight.DataBindings.Clear();
                txtUnitPrice.DataBindings.Clear();
                txtUnitslnStock.DataBindings.Clear();


                txtProductID.DataBindings.Add("Text", source, "ProductID");
                txtCategory.DataBindings.Add("Text", source, "CategoryID");
                txtProductName.DataBindings.Add("Text", source, "ProductName");
                txtWeight.DataBindings.Add("Text", source, "Weight");
                txtUnitPrice.DataBindings.Add("Text", source, "UnitPrice");
                txtUnitslnStock.DataBindings.Add("Text", source, "UnitsInStock");





                if (list.Count() == 0)
                {

                    EmptyText();
                    btnDelete.Enabled = false;
                    MessageBox.Show("Nothing to show");

                }
                else
                {
                    dgvProducts.DataSource = source;
                    btnDelete.Enabled = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SearchByUIS(int searchUIS)
        {
            try
            {
                List<Product> p = resp.GetListProduct();
                List<Product> list = new List<Product>();
                foreach (var result in p)
                {
                    if (result.UnitsInStock == (searchUIS))
                    {
                        list.Add(result);
                    }
                }

                BindingSource source = new BindingSource();
                source.DataSource = list.ToList();

                txtProductID.DataBindings.Clear();
                txtCategory.DataBindings.Clear();
                txtProductName.DataBindings.Clear();
                txtWeight.DataBindings.Clear();
                txtUnitPrice.DataBindings.Clear();
                txtUnitslnStock.DataBindings.Clear();


                txtProductID.DataBindings.Add("Text", source, "ProductID");
                txtCategory.DataBindings.Add("Text", source, "CategoryID");
                txtProductName.DataBindings.Add("Text", source, "ProductName");
                txtWeight.DataBindings.Add("Text", source, "Weight");
                txtUnitPrice.DataBindings.Add("Text", source, "UnitPrice");
                txtUnitslnStock.DataBindings.Add("Text", source, "UnitsInStock");





                if (list.Count() == 0)
                {

                    EmptyText();
                    btnDelete.Enabled = false;
                    MessageBox.Show("Nothing to show");

                }
                else
                {
                    dgvProducts.DataSource = source;
                    btnDelete.Enabled = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void EmptyText()
        {
            txtProductID.Text = string.Empty;
            txtCategory.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtWeight.Text = string.Empty;
            txtUnitPrice.Text = string.Empty;
            txtUnitslnStock.Text = string.Empty;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbSearchList.SelectedItem.ToString().Equals("Product Name"))
                {
                    SearchByName(txtInputSearch.Text);
                }
                else if (cbSearchList.SelectedItem.ToString().Equals("Product ID"))
                {
                    SearchByID(int.Parse(txtInputSearch.Text));
                }
                else if (cbSearchList.SelectedItem.ToString().Equals("Unit Price"))
                {
                    SearchByUnitPrice(Decimal.Parse(txtInputSearch.Text));
                }
                else if (cbSearchList.SelectedItem.ToString().Equals("Unit In Stock"))
                {
                    SearchByUIS(int.Parse(txtInputSearch.Text));
                }

            }
            catch
            {
                MessageBox.Show("Nothing to show");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to delete product", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    var pro = GetProductObject();
                    resp.DeleteProduct(pro);
                    LoadProductList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Delete one order !");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
            }
        }
    }
}
