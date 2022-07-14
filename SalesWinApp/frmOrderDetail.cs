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
    public partial class frmOrderDetail : Form
    {
        public frmOrderDetail()
        {
            InitializeComponent();
        }
        IOrderDetailRepository resp = new OrderDetailRepository();
        BindingSource source;
        public IOrderRepository OrderRepository { get; set; }
        public int whereOrderDetail { get; set; }
        public Order Order { get; set; }
        public void LoadOrderDetail()
        {
            try
            {
                FStoreDBContext db = new FStoreDBContext();
                var orderList = from c in db.OrderDetails
                                where c.OrderId == whereOrderDetail
                                select new
                                {
                                    OrderId = c.OrderId,
                                    ProductName = c.Product.ProductName,
                                    UnitPrice = c.UnitPrice,
                                    Quantity = c.Quantity,
                                    Discount = c.Discount,
                                    ProductID = c.ProductId
                                };
                source = new BindingSource();
                source.DataSource = orderList.ToList();
                txtOrderID.DataBindings.Clear();
                txtProductName.DataBindings.Clear();
                txtUnitPrice.DataBindings.Clear();
                txtQuantity.DataBindings.Clear();
                txtDiscount.DataBindings.Clear();
                txtProductID.DataBindings.Clear();

                txtProductID.Visible = false;
                txtOrderID.DataBindings.Add("Text", source, "OrderID");
                txtProductName.DataBindings.Add("Text", source, "ProductName");
                txtUnitPrice.DataBindings.Add("Text", source, "UnitPrice");
                txtQuantity.DataBindings.Add("Text", source, "Quantity");
                txtDiscount.DataBindings.Add("Text", source, "Discount");
                txtProductID.DataBindings.Add("Text",source, "ProductID");

                dgvOrderDetail.DataSource = null;        
                dgvOrderDetail.DataSource = source;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of order detail!");
            }
        }

        private void frmOrderDetail_Load(object sender, EventArgs e)
        {
            LoadOrderDetail();
        }

        public OrderDetail GetOrderDetailObject()
        {
            OrderDetail odo = null;
            try
            {
                odo = new OrderDetail
                {
                    OrderId = int.Parse(txtOrderID.Text),
                    ProductId = int.Parse(txtProductID.Text),
                    UnitPrice = Decimal.Parse(txtUnitPrice.Text),
                    Quantity = int.Parse(txtQuantity.Text),
                    Discount = Double.Parse(txtDiscount.Text),
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get order detail");
            }
            return odo;
        }

        private void dgvOrderDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmUpdateOrderDetail frmUpdateOrderDetail = new frmUpdateOrderDetail
            {
                Text = "Update Order Detail",
                InsertOrUpdate = true,
                OrderDetail = GetOrderDetailObject(),
                OrderDetailRepository = resp
            };
            if (frmUpdateOrderDetail.ShowDialog() == DialogResult.OK)
            {
                LoadOrderDetail();
                source.Position = source.Count - 1;

            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            frmUpdateOrderDetail frmUpdateOrderDetail = new frmUpdateOrderDetail
            {
                Text = "Create Order Detail",
                InsertOrUpdate = false,
                OrderDetail = GetOrderDetailObject(),
                OrderDetailRepository = resp
            };
            if (frmUpdateOrderDetail.ShowDialog() == DialogResult.OK)
            {
                LoadOrderDetail();
                source.Position = source.Count - 1;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
            DialogResult dialogResult = MessageBox.Show("Do you want to delete order detail", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    var ordd = GetOrderDetailObject();
                    resp.DeleteOrderDetail(ordd);
                    LoadOrderDetail();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Delete one order detail");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
            }
        }
    }
    }

