using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Repository
{
    public class ProductRepository : IProductRepository
    {
        public void DeleteProduct(Product p) => ProductDAO.DeleteProduct(p);

        public void SaveProduct(Product p) => ProductDAO.SaveProduct(p);

        public void UpdateProduct(Product p) => ProductDAO.UpdateProduct(p);

        public List<Product> GetListProduct() => ProductDAO.GetListProduct();
    }
}
