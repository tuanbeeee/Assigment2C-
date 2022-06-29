using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Repository
{
    public interface IOrderRepository
    {
        void SaveOrder(Order o);
        void DeleteOrder(Order o);
        void UpdateOrder(Order o);
        List<Order> GetOrderList();
    }
}
