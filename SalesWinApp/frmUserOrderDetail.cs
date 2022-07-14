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
    public partial class frmUserOrderDetail : Form
    {
        public frmUserOrderDetail()
        {
            InitializeComponent();
        }
        public int whereOrderDetail { get; set; }
        BindingSource source;
        private void frmUserDetailForm_Load(object sender, EventArgs e)
        {
            LoadOrderDetail();
        }

        private void LoadOrderDetail()
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
                
                dgvOrderDetail.DataSource = null;
                dgvOrderDetail.DataSource = source;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of order detail!");
            }
        }
    }
}
