
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
                //if we not use the below line of code EntityState.Unchanged then the category is inserted again and in dropdown list the categories appear twice or more
                // time that we add product and Select category.To Overcome this issue we used EntityState.Unchanged to not add a new category in category table 
                // just add the category in product table.

                context.Entry(product.Category).State = System.Data.Entity.EntityState.Unchanged;
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
            //When we intialize the Category as virtual in entities. Entity Framework will genrate the query but didn,t execute it.It is executed when we access
            // the value of Category. Example in Product Table we are using @product.Category.Name now the query is called and if we use the below code
            // then the object is disposed it give an error thats we are writing it outside the using statement and comment the section of using code.

            //using (var context = new CBContext())
            //{
            //    return context.Products.ToList();
            //}

            // (Note if we use the below code the connection is not disposed, which create performance issues.If we do this it is correct but we comment it now and use
            // proper approach for it which is used in industry now.)

            //var context = new CBContext();
            //return context.Products.ToList();

            using(var context = new CBContext())
            {
                return context.Products.Include(x=>x.Category).ToList();
            }

            //We inherit our CBContext from Idisposeable class because it we have to dispose the database object because of performance issues it is necassary,
            // when  there are many user connected with your application.


        }

        public Product GetProduct(int ID)
        {
            using (var context = new CBContext())
            {

                //return context.Products.Find(ID);
                //If we want the record of category of related product then we write the below linq.
                return context.Products.Where(product => product.ID == ID).Include(product => product.Category).FirstOrDefault();

            }
        }

        public List<Product> GetProducts(List<int> IDs)
        {
            using (var context = new CBContext())
            {

                return context.Products.Where(product => IDs.Contains(product.ID)).ToList();

            }
        }
    }

}