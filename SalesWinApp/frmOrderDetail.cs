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
                                    Discount = c.Discount
                                };
                BindingSource source = new BindingSource();
                source.DataSource = orderList.ToList();
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
    }
    }

