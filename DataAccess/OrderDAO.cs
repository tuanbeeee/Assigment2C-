using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class OrderDAO
    {

        public static List<Order> GetListOrder()
        {
            List<Order> list = new List<Order>();
            try{
                
                using var context = new FStoreDBContext();
                list = context.Orders.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        } 

        public static void SaveOrder(Order o)
        {
            try
            {
                using (var context = new FStoreDBContext())
                {
                    context.Orders.Add(o);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateOrder(Order o)
        {
            try
            {
                using (var context = new FStoreDBContext())
                {
                    context.Entry<Order>(o).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteOrder(Order o)
        {
            try
            {
                using (var context = new FStoreDBContext())
                {
                    var o1 = context.Orders.SingleOrDefault(c => c.OrderId == o.OrderId);
                    context.Orders.Remove(o1);

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
