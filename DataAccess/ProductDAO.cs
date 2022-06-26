using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class ProductDAO
    {

        public static void SaveProduct (Product p)
        {
            try
            {
                using (var context = new FStoreDBContext())
                {
                    context.Products.Add(p);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateProduct (Product p)
        {
            try
            {
                using (var context = new FStoreDBContext())
                {
                    context.Entry<Product>(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteProduct (Product p)
        {
            try
            {
                using (var context = new FStoreDBContext())
                {
                    var p1 = context.Products.SingleOrDefault(c => c.ProductId == p.ProductId);
                    context.Products.Remove(p1);

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
