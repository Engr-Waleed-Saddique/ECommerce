
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
        public List<Category> GetCategory()
        {
            using (var context = new CBContext())
            {

                return context.Categories.ToList();
            }
        }
    }
}
