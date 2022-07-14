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
    public partial class frmStatistics : Form
    {
        IOrderRepository resp = new OrderRepository();
        IOrderDetailRepository repository = new OrderDetailRepository();
        public frmStatistics()
        {
            InitializeComponent();
        }

        private void Statistics(DateTime startDate, DateTime endDate)
        {
            try
            {
                List<Order> p = resp.GetOrderList();
                List<Order> list = new List<Order>();
                
                    if (startDate > endDate)
                    {
                        MessageBox.Show("Start Date can not large than End Date");
                    }
                    else
                    {
                    foreach (var result in p)
                    {
                        if (result.ShippedDate >= (startDate) && result.ShippedDate <= (endDate))
                        {
                            list.Add(result);
                        }
                    }
                    
                }

                BindingSource source = new BindingSource();
                source.DataSource = list.ToList();

                txtOrderID.DataBindings.Clear();
                txtMemberID.DataBindings.Clear();
                txtOrderDate.DataBindings.Clear();
                txtRequiredDate.DataBindings.Clear();
                txtShippedDate.DataBindings.Clear();
                txtFreight.DataBindings.Clear();


                txtOrderID.DataBindings.Add("Text", source, "OrderId");
                txtMemberID.DataBindings.Add("Text", source, "MemberID");
                txtOrderDate.DataBindings.Add("Text", source, "OrderDate");
                txtRequiredDate.DataBindings.Add("Text", source, "RequiredDate");
                txtShippedDate.DataBindings.Add("Text", source, "ShippedDate");
                txtFreight.DataBindings.Add("Text", source, "Freight");





                if (list.Count() == 0)
                {

                    //EmptyText();
                    MessageBox.Show("Nothing to show");

                }
                else
                {
                    dgvViewOrder.DataSource = source;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SortByDate(DateTime startDate, DateTime endDate)
        {
            try
            {
                List<Order> p = resp.GetOrderList();
                List<Order> list = new List<Order>();

                if (startDate > endDate)
                {
                    MessageBox.Show("Start Date can not large than End Date");
                }
                else
                {
                    foreach (var result in p)
                    {
                        if (result.ShippedDate >= (startDate) && result.ShippedDate <= (endDate))
                        {
                            list.Add(result);
                        }
                    }

                }

                BindingSource source = new BindingSource();
                source.DataSource = list.OrderByDescending(n => n.OrderId).ToList();

                txtOrderID.DataBindings.Clear();
                txtMemberID.DataBindings.Clear();
                txtOrderDate.DataBindings.Clear();
                txtRequiredDate.DataBindings.Clear();
                txtShippedDate.DataBindings.Clear();
                txtFreight.DataBindings.Clear();


                txtOrderID.DataBindings.Add("Text", source, "OrderId");
                txtMemberID.DataBindings.Add("Text", source, "MemberID");
                txtOrderDate.DataBindings.Add("Text", source, "OrderDate");
                txtRequiredDate.DataBindings.Add("Text", source, "RequiredDate");
                txtShippedDate.DataBindings.Add("Text", source, "ShippedDate");
                txtFreight.DataBindings.Add("Text", source, "Freight");





                if (list.Count() == 0)
                {

                    //EmptyText();
                    MessageBox.Show("Nothing to show");

                }
                else
                {
                    dgvViewOrder.DataSource = source;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private decimal PriceOfOrder(DateTime startDate, DateTime endDate)
        {
                List<OrderDetail> p = repository.GetListOrderDetails();
                List<OrderDetail> list = new List<OrderDetail>();
                decimal price = 0;
                decimal total = 0;
                List<Order> o = resp.GetOrderList();
                List<Order> listo = new List<Order>();

            if (startDate > endDate)
            {
                MessageBox.Show("Start Date can not large than End Date");
            }
            else
            {
                foreach (var result in o)
                {
                    if (result.ShippedDate >= (startDate) && result.ShippedDate <= (endDate))
                    {
                            foreach (var odd in p)
                            {
                                if (result.OrderId == odd.OrderId)
                                {
                                price += odd.UnitPrice * odd.Quantity - (odd.UnitPrice * odd.Quantity * Decimal.Parse(odd.Discount.ToString()) / 100);
                                }
                            }
                        
                    }
                }
            }
            
            return price;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            Statistics(dtStartDate.Value, dtEndDate.Value);
            lbPrice.Text = PriceOfOrder(dtStartDate.Value, dtEndDate.Value).ToString();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            SortByDate(dtStartDate.Value, dtEndDate.Value);
        }
    }
}
