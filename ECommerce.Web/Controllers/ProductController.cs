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
        //ProductService productService = new ProductService();
        //CategoriesService categoriesService = new CategoriesService();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProductTable(string search)
        {
            var products = ProductService.Instance.GetProducts();
            if (!string.IsNullOrEmpty(search))
            {
                products = products.Where(p => p.Name.ToLower().Contains(search.ToLower())).ToList();
            }
            return PartialView(products);
        }


        public ActionResult Create()
        {
            var categories = CategoriesService.Instance.GetCategories();
            return PartialView(categories);
        }
        [HttpPost]
        public ActionResult Create(NewCategoryViewModel model)
        {
            var newProduct = new Product();
            newProduct.Name = model.Name;
            newProduct.Description = model.Description;
            newProduct.Price = model.Price;
            newProduct.Category = CategoriesService.Instance.GetCategory(model.CategoryID);
            //newProduct.CategoryID = model.CategoryID;
            //if we are doing large projects then we have to use above line that is commented.For this we have to add also one more attrbute in Product class
            // with name CategoryID and entity framework replace The existing cloumn name with this and make this as Foriegn key.We can use this to reduce the
            // number of database calls.
            ProductService.Instance.SaveProduct(newProduct);
            return RedirectToAction("ProductTable");
        }


        public ActionResult Edit(int ID)
        {
            var product = ProductService.Instance.GetProduct(ID);
            return PartialView(product);

        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            ProductService.Instance.UpdateProduct(product);
            return RedirectToAction("ProductTable");
        }

        [HttpPost]
        public ActionResult Delete(int ID)
        {
            ProductService.Instance.DeleteProduct(ID);
            return RedirectToAction("ProductTable");
        }
    }
}