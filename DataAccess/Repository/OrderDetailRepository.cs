using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public void DeleteOrderDetail(OrderDetail od) => OrderDetailDAO.DeleteOrderDetail(od);

        public List<OrderDetail> GetListOrderDetails() => OrderDetailDAO.GetListOrderDetails();

        public void SaveOrderDetail(OrderDetail od) => OrderDetailDAO.SaveOrderDetail(od);

        public void UpdateOrderDetail(OrderDetail od) => OrderDetailDAO.UpdateOrderDetail(od);

    }
}
