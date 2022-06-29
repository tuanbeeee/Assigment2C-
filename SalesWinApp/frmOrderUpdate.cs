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
    public partial class frmOrderUpdate : Form
    {
        public Order Order { get; set; }
        public IOrderRepository resp = new OrderRepository(); 
        public frmOrderUpdate()
        {
            InitializeComponent();
        }

        private void frmOrderUpdate_Load(object sender, EventArgs e)
        {
            txtOrderID.Enabled = false;
            txtOrderDate.Enabled = false;
            txtRequiredDate.Enabled = false;
            txtShippedDate.Enabled = false;


            txtOrderID.Text = Order.OrderId.ToString();
            txtMemID.Text = Order.MemberId.ToString();
            txtOrderDate.Text = Order.OrderDate.ToString();
            txtRequiredDate.Text = Order.RequiredDate.ToString();
            txtShippedDate.Text = Order.ShippedDate.ToString();
            txtFreight.Text = Order.Freight.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var order = new Order
                {
                    OrderId = int.Parse(txtOrderID.Text),
                    MemberId = int.Parse(txtMemID.Text),
                    OrderDate = DateTime.Parse(txtOrderDate.Text),
                    RequiredDate = DateTime.Parse(txtRequiredDate.Text),
                    ShippedDate = DateTime.Parse(txtShippedDate.Text),
                    Freight = decimal.Parse(txtFreight.Text)
                   
                };
                resp.UpdateOrder(order);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Update order");
            }
        }

        private void txtMemID_KeyPress(object sender, KeyPressEventArgs e)
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
