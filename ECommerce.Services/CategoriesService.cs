
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
        #region Singleton
        public static CategoriesService Instance
        {
            get
            {
                if (instance == null) instance = new CategoriesService();
                return instance;
            }
        }
        private static CategoriesService instance { get; set; }
        private CategoriesService()
        {

        }
        #endregion

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
        public List<Category> GetCategories(string search,int pageNo)
        {
            int pageSize = 3;
            using (var context = new CBContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return context.Categories.Where(c => c.Name.ToLower().Contains(search.ToLower()))
                    .OrderBy(x => x.ID)
                    .Skip((pageNo - 1) * pageSize)
                    .Take(pageSize)
                    .Include(x => x.Products)
                    .ToList();
                }
                else
                {
                    return context.Categories
                        .OrderBy(x => x.ID)
                        .Skip((pageNo - 1) * pageSize)
                        .Take(pageSize)
                        .Include(x => x.Products)
                        .ToList();
                }
            }
        }
        public List<Category> GetAllCategories()
        {
            using (var context = new CBContext())
            {
                return context.Categories.ToList();
            }
        }
        public int GetCategoriesCount(string search)
        {
            using (var context = new CBContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return context.Categories.Where(c => c.Name.ToLower().Contains(search.ToLower())).Count();
                }
                else
                {
                    return context.Categories.Count();
                }

                
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