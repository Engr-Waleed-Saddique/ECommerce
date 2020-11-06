
using ECommerce.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ECommerce.Entities;

namespace ECommerce.Services
{
    public class ProductService
    {
        public void SaveProduct(Product product)
        {
            using (var context= new CBContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }
        public void UpdateProduct(Product product)
        {
            using (var context = new CBContext())
            {
                context.Entry(product).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void DeleteProduct(int ID)
        {
            using (var context = new CBContext())
            {
                //context.Entry(category).State = System.Data.Entity.EntityState.Deleted;
                var product = context.Products.Find(ID);
                context.Products.Remove(product);

                context.SaveChanges();
            }
        }
        public List<Product> GetProducts()
        {
            using (var context = new CBContext())
            {

                return context.Products.ToList();
            }
        }

        public Product GetProduct(int ID)
        {
            using (var context = new CBContext())
            {

                return context.Products.Find(ID);

            }
        }
    }

}
