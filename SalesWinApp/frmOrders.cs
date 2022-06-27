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
                                    Freight = c.Freight
                                };
                BindingSource source = new BindingSource();
                source.DataSource = orderList.ToList();

                txtOrderID.DataBindings.Clear();
                txtMemberID.DataBindings.Clear();
                txtOrderDate.DataBindings.Clear();
                txtRequiredDate.DataBindings.Clear();
                txtShippedDate.DataBindings.Clear();
                txtFreight.DataBindings.Clear();

                txtOrderID.DataBindings.Add("Text", source, "OrderID");
                txtMemberID.DataBindings.Add("Text", source, "MemberName");
                txtOrderDate.DataBindings.Add("Text", source, "OrderDate");
                txtRequiredDate.DataBindings.Add("Text", source, "RequiredDate");
                txtShippedDate.DataBindings.Add("Text", source, "ShippedDate");
                txtFreight.DataBindings.Add("Text", source, "Freight");

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

        private void dgvOrders_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmOrderDetail frmOrderDetail = new frmOrderDetail
            {
                Text = "Order Detail",
                whereOrderDetail = int.Parse(txtOrderID.Text),

            };
            frmOrderDetail.ShowDialog();
        }
    }
}
