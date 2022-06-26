using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public void DeleteOrder(Order o) => OrderDAO.DeleteOrder(o);

        public void SaveOrder(Order o) => OrderDAO.SaveOrder(o);

        public void UpdateOrder(Order o) => OrderDAO.UpdateOrder(o);

    }
}
