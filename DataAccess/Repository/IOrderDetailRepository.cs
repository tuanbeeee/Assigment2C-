using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Repository
{
    public interface IOrderDetailRepository
    {
        void SaveOrderDetail(OrderDetail od);
        void DeleteOrderDetail(OrderDetail od);
        void UpdateOrderDetail(OrderDetail od);
        
    }
}
