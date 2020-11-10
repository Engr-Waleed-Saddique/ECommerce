using ECommerce.Entities;
using ECommerce.Services;
using ECommerce.Web.Models;
using ECommerce.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Web.Controllers
{
    public class CategoryController : Controller
    {
        CategoriesService categoryService = new CategoriesService();
        ProductService productService = new ProductService();


        public ActionResult Index()
        {
            var categories=categoryService.GetCategories();
            return View(categories);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            categoryService.SaveCategory(category);
            return RedirectToAction("CategoryTable");
        }

        public ActionResult CategoryTable(string search)
        {
            var categories = categoryService.GetCategories();

            if (!string.IsNullOrEmpty(search))
            {
                categories = categories.Where(c => c.Name.ToLower().Contains(search.ToLower())).ToList();
            }
            return PartialView(categories);
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var category=categoryService.GetCategory(ID);
            return PartialView(category);
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            categoryService.UpdateCategory(category);
            return RedirectToAction("CategoryTable");
        }

        //[HttpGet]
        //public ActionResult Delete(int ID)
        //{
        //    var category = categoryService.GetCategory(ID);
        //    return View(category);
        //}
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            categoryService.DeleteCategory(ID);
            return RedirectToAction("CategoryTable");
        }
    }
}
