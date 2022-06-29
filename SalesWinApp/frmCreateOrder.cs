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
    public partial class frmCreateOrder : Form
    {

        public IOrderRepository OrderRepository { get; set; }
        public IOrderDetailRepository OrderDetailRepository { get; set; }
        public IProductRepository productRepository = new ProductRepository();
        public bool InsertOrUpdate { get; set; }
        public Order Order { get; set; }
        public frmCreateOrder()
        {
            InitializeComponent();
        }

        private void frmCreateOrder_Load(object sender, EventArgs e)
        {
            txtOrderID.Enabled = false;
            txtUnitPrice.Enabled = false;

            string Numrd;
            Random rd = new Random();
            Numrd = rd.Next(1, 20000).ToString();
            txtOrderID.Text = Numrd;


            FStoreDBContext db = new FStoreDBContext();
            var product = from c in db.Products
                          select c.ProductName.ToString();
            foreach (var i in product) {
                cbProductID.Items.Add(i);
            }
            var member = from m in db.Members
                         select m.CompanyName.ToString();
            foreach (var x in member)
            {
                cbMemberName.Items.Add(x);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                FStoreDBContext db = new FStoreDBContext();
                var mem = db.Members.SingleOrDefault(pro => pro.CompanyName.Equals(cbMemberName.SelectedItem.ToString()));
                int id = mem.MemberId;

                var order = new Order
                {
                    

                    OrderId = int.Parse(txtOrderID.Text),
                    MemberId = id,
                    OrderDate = dtOrderDate.Value,
                    RequiredDate = dtRequiredFate.Value,
                    ShippedDate = dtShippedDate.Value,
                    Freight = int.Parse(txtFreight.Text)

                };
                OrderRepository.SaveOrder(order);

                var product = db.Products.SingleOrDefault(pro => pro.ProductName.Equals(cbProductID.SelectedItem.ToString()));
                int proID = product.ProductId;


                var orderDetail = new OrderDetail
                {
                    OrderId = int.Parse(txtOrderID.Text),
                    ProductId = proID,
                    UnitPrice = Decimal.Parse(txtUnitPrice.Text),
                    Quantity = int.Parse(txtQuantity.Text),
                    Discount = Double.Parse(txtDiscount.Text)
                };

                

                OrderDetailRepository.SaveOrderDetail(orderDetail);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Add new order");
            }
        }

        private void cbProductID_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = cbProductID.SelectedIndex;
            List<Product> p = productRepository.GetListProduct();
            txtUnitPrice.Text = p[index].UnitPrice.ToString();
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
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

        private void txtFreight_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
    }
}
