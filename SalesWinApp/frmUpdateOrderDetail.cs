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
    public partial class frmUpdateOrderDetail : Form
    {
        public frmUpdateOrderDetail()
        {
            InitializeComponent();
        }

        public IOrderDetailRepository OrderDetailRepository = new OrderDetailRepository();

        public IProductRepository ProductRepository = new ProductRepository();

        public bool InsertOrUpdate { get; set; }

        public OrderDetail OrderDetail { get; set; }

        private void frmUpdateOrderDetail_Load(object sender, EventArgs e)
        {
            

            if (InsertOrUpdate == true)
            {
                txtOrderID.Enabled = !InsertOrUpdate;
                cbProductName.Enabled = !InsertOrUpdate;
                txtUniPrice.Enabled = !InsertOrUpdate;


                txtOrderID.Text = OrderDetail.OrderId.ToString();  
                txtQuantity.Text = OrderDetail.Quantity.ToString();
                txtDiscount.Text = OrderDetail.Discount.ToString();
                txtProductID.Text = OrderDetail.ProductId.ToString();

                string unitPrice = null;
                string productName = null;
                FStoreDBContext db = new FStoreDBContext();
                Product od = db.Products.SingleOrDefault(pro => pro.ProductId == int.Parse(txtProductID.Text));
                if (od != null) {
                    unitPrice = od.UnitPrice.ToString();
                    productName = od.ProductName.ToString();
                }
                else
                {
                    unitPrice = null;
                    productName = null;
                }
                
                txtUniPrice.Text = unitPrice;
                cbProductName.Text = productName;
            }
            else
            {
                txtOrderID.Enabled = false;
                txtUniPrice.Enabled = false;
                                
                txtOrderID.Text = OrderDetail.OrderId.ToString();

                FStoreDBContext db = new FStoreDBContext();
                var product = from c in db.Products
                              select c.ProductName.ToString();
                foreach (var i in product)
                {
                    cbProductName.Items.Add(i);
                }

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            { 
                if (InsertOrUpdate == true)
                {

                    FStoreDBContext db = new FStoreDBContext();
                    Product od = db.Products.SingleOrDefault(pro => pro.ProductId == int.Parse(txtProductID.Text));
                    int newStock = od.UnitsInStock - int.Parse(txtQuantity.Text);
                   

                    var odo = new OrderDetail
                    {
                        OrderId = int.Parse(txtOrderID.Text),
                        ProductId = int.Parse(txtProductID.Text),
                        UnitPrice = Decimal.Parse(txtUniPrice.Text),
                        Quantity = int.Parse(txtQuantity.Text),
                        Discount = int.Parse(txtDiscount.Text)
                    };
                    OrderDetailRepository.UpdateOrderDetail(odo);

                    var product = new Product
                    {
                        ProductId = od.ProductId,
                        CategoryId = od.CategoryId,
                        ProductName = od.ProductName,
                        Weight = od.Weight,
                        UnitPrice = od.UnitPrice,
                        UnitsInStock = newStock
                    };
                    ProductRepository.UpdateProduct(product);

                }
                else
                {
                    var createOrder = new OrderDetail
                    {
                        OrderId = int.Parse(txtOrderID.Text),
                        ProductId = cbProductName.SelectedIndex + 1,
                        UnitPrice = Decimal.Parse(txtUniPrice.Text),
                        Quantity = int.Parse(txtQuantity.Text),
                        Discount = int.Parse(txtDiscount.Text)
                    };
                    OrderDetailRepository.SaveOrderDetail(createOrder);

                    FStoreDBContext db = new FStoreDBContext();
                    Product od = db.Products.SingleOrDefault(pro => pro.ProductId == cbProductName.SelectedIndex + 1);
                    int newStock = od.UnitsInStock - int.Parse(txtQuantity.Text);

                    var product = new Product
                    {
                        ProductId = od.ProductId,
                        CategoryId = od.CategoryId,
                        ProductName = od.ProductName,
                        Weight = od.Weight,
                        UnitPrice = od.UnitPrice,
                        UnitsInStock = newStock
                    };
                    ProductRepository.UpdateProduct(product);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("This product is already in your order", " Order detail");
            }
        }

        private void cbProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = cbProductName.SelectedIndex;
            List<Product> p = ProductRepository.GetListProduct();
            txtUniPrice.Text = p[index].UnitPrice.ToString();
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46 ){
                e.Handled = true;
            }
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
    }
}
