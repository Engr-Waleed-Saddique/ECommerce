
using ECommerce.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ECommerce.Entities;
using System.Dynamic;

namespace ECommerce.Services
{
    public class CategoriesService
    {
        public void SaveCategory(Category category)
        {
            using (var context= new CBContext())
            {
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }
        public void UpdateCategory(Category category)
        {
            using (var context = new CBContext())
            {
                context.Entry(category).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void DeleteCategory(int ID)
        {
            using (var context = new CBContext())
            {
                //context.Entry(category).State = System.Data.Entity.EntityState.Deleted;
                var category = context.Categories.Find(ID);
                context.Categories.Remove(category);

                context.SaveChanges();
            }
        }
        public List<Category> GetCategories()
        {
            using (var context = new CBContext())
            {

                return context.Categories.Include("Products").ToList();
            }
        }
        public List<Category> GetFeaturedCategories()
        {
            using (var context = new CBContext())
            {

                return context.Categories.Where(x=>x.isFeatured&&x.ImageURL!=null).ToList();

            }
        }

        public Category GetCategory(int ID)
        {
            using (var context = new CBContext())
            {

                return context.Categories.Find(ID);

            }
        }
    }

}