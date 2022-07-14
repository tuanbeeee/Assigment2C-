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
    public partial class frmOrders : Form
    {
        IOrderRepository resp = new OrderRepository();
        IOrderDetailRepository resp1 = new OrderDetailRepository();
        BindingSource source;
        public frmOrders()
        {
            InitializeComponent();
        }

        public void LoadOrder()
        {
            try
            {
                FStoreDBContext db = new FStoreDBContext();
                var orderList = from c in db.Orders
                                select new
                                {
                                    OrderId = c.OrderId,
                                    MemberName = c.Member.CompanyName,
                                    OrderDate = c.OrderDate,
                                    RequiredDate = c.RequiredDate,
                                    ShippedDate = c.ShippedDate,
                                    Freight = c.Freight,
                                    MemberID = c.MemberId
                                };
                source = new BindingSource();
                source.DataSource = orderList.ToList();
                txtOrderID.DataBindings.Clear();
                txtMemberName.DataBindings.Clear();
                txtOrderDate.DataBindings.Clear();
                txtRequiredDate.DataBindings.Clear();
                txtShippedDate.DataBindings.Clear();
                txtFreight.DataBindings.Clear();
                txtMemID.DataBindings.Clear();

                txtOrderID.DataBindings.Add("Text", source, "OrderID");
                txtMemberName.DataBindings.Add("Text", source, "MemberName");
                txtOrderDate.DataBindings.Add("Text", source, "OrderDate");
                txtRequiredDate.DataBindings.Add("Text", source, "RequiredDate");
                txtShippedDate.DataBindings.Add("Text", source, "ShippedDate");
                txtFreight.DataBindings.Add("Text", source, "Freight");
                txtMemID.DataBindings.Add("Text", source, "MemberID");

                dgvOrders.DataSource = null;
                dgvOrders.DataSource = source;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of order!");
            }
        }

        private void frmOrders_Load(object sender, EventArgs e)
        {
            LoadOrder();
        }


        private void dgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmOrderDetail frmOrderDetail = new frmOrderDetail
            {
                Text = "Order Detail",
                whereOrderDetail = int.Parse(txtOrderID.Text),

            };
            frmOrderDetail.ShowDialog();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            frmCreateOrder frmCreateOrder = new frmCreateOrder
            {
                Text = "Add new order",
                OrderRepository = resp,
                OrderDetailRepository = resp1
            };
            if (frmCreateOrder.ShowDialog() == DialogResult.OK)
            {
                LoadOrder();
                source.Position = source.Count - 1;
            }
        }
        public Order GetOrderObject()
        {
            Order od = null;
            try
            {
                od = new Order
                {
                    OrderId = int.Parse(txtOrderID.Text),
                    MemberId = int.Parse(txtMemID.Text),
                    OrderDate = DateTime.Parse(txtOrderDate.Text),
                    RequiredDate = DateTime.Parse(txtRequiredDate.Text),
                    ShippedDate = DateTime.Parse(txtShippedDate.Text),
                    Freight = decimal.Parse(txtFreight.Text)
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get order detail");
            }
            return od;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            frmOrderUpdate frmOrderUpdate = new frmOrderUpdate
            {
                Text = "Update Order Detail",
                Order = GetOrderObject()
            };
            if (frmOrderUpdate.ShowDialog() == DialogResult.OK)
            {
                LoadOrder();
                source.Position = source.Count - 1;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            

            DialogResult dialogResult = MessageBox.Show("Do you want to delete order", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    var or = GetOrderObject();
                    resp.DeleteOrder(or);
                    LoadOrder();
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
