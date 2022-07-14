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
    public partial class frmUserOrder : Form
    {
        BindingSource source;
        public string Email { get; set; }
        public Member member { get; set; }
        public frmUserOrder()
        {
            InitializeComponent();
        }


        public void LoadOrder()
        {
            try
            {
                int acc = member.MemberId;             
                FStoreDBContext db = new FStoreDBContext();
                var orderList = from c in db.Orders
                                where c.MemberId == acc
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

        private void frmUserOrder_Load(object sender, EventArgs e)
        {
            LoadOrder();
        }

        private void dgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmUserOrderDetail frmOrderDetail = new frmUserOrderDetail
            {
                Text = "Order Detail",
                whereOrderDetail = int.Parse(txtOrderID.Text),

            };
            frmOrderDetail.ShowDialog();
        }
    }
}
