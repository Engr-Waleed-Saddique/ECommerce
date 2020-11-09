using ECommerce.Entities;
using ECommerce.Services;
using ECommerce.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Web.Controllers
{
    public class ProductController : Controller
    {
        ProductService productService = new ProductService();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProductTable(string search)
        {
            var products = productService.GetProducts();
            if (!string.IsNullOrEmpty(search))
            {
                products = products.Where(p => p.Name.ToLower().Contains(search.ToLower())).ToList();
            }
            return PartialView(products);
        }


        public ActionResult Create()
        {
            CategoriesService categoriesService = new CategoriesService();
            var categories = categoriesService.GetCategories();
            return PartialView(categories);
        }
        [HttpPost]
        public ActionResult Create(NewCategoryViewModel model)
        {
            CategoriesService categoryService = new CategoriesService();
            var newProduct = new Product();
            newProduct.Name = model.Name;
            newProduct.Description = model.Description;
            newProduct.Price = model.Price;
            newProduct.Category = categoryService.GetCategory(model.CategoryID);
            //newProduct.CategoryID = model.CategoryID;
            //if we are doing large projects then we have to use above line that is commented.For this we have to add also one more attrbute in Product class
            // with name CategoryID and entity framework replace The existing cloumn name with this and make this as Foriegn key.We can use this to reduce the
            // number of database calls.
            productService.SaveProduct(newProduct);
            return RedirectToAction("ProductTable");
        }


        public ActionResult Edit(int ID)
        {
            var product = productService.GetProduct(ID);
            return PartialView(product);

        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            productService.UpdateProduct(product);
            return RedirectToAction("ProductTable");
        }

        [HttpPost]
        public ActionResult Delete(int ID)
        {
            productService.DeleteProduct(ID);
            return RedirectToAction("ProductTable");
        }
    }
}