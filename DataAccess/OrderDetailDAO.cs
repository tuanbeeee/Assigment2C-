using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class OrderDetailDAO
    {

        public static List<OrderDetail> GetListOrderDetails()
        {
            List<OrderDetail> list = new List<OrderDetail>();
            try
            {

                using var context = new FStoreDBContext();
                list = context.OrderDetails.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
        public static void SaveOrderDetail(OrderDetail o)
        {
            try
            {
                using (var context = new FStoreDBContext())
                {
                    context.OrderDetails.Add(o);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateOrderDetail(OrderDetail o)
        {
            try
            {
                using (var context = new FStoreDBContext())
                {
                    context.Entry<OrderDetail>(o).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteOrderDetail(OrderDetail o)
        {
            try
            {
                using (var context = new FStoreDBContext())
                {
                    var o1 = context.OrderDetails.SingleOrDefault(c => c.OrderId == o.OrderId && c.ProductId == o.ProductId);
                    context.OrderDetails.Remove(o1);

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
