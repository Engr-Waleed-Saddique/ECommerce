using ECommerce.Services;
using ECommerce.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Web.Controllers
{
    public class ShopController : Controller
    {
        public ActionResult Index(string searchTerm,int? minimumPrice,int? maximumPrice,int? categoryID,int? sortBy)
        {
            ShopViewModel model = new ShopViewModel();
            model.FeaturedCategories = CategoriesService.Instance.GetFeaturedCategories();
            model.MaximumPrice = ProductService.Instance.GetMaximumPrice();
            model.Products = ProductService.Instance.SearchProducts(searchTerm, minimumPrice, maximumPrice, categoryID, sortBy);
            model.SortBy = sortBy;
            return View(model);
        }
        //ProductService productService = new ProductService();
        public ActionResult Checkout()
        {
            CheckoutViewModel model = new CheckoutViewModel();
            var CartProductsCookie = Request.Cookies["CartProducts"];
            //Here we are checking customer buy some thing or not.If he buy something then CartProductCookie value is not null.
            if(CartProductsCookie!=null)
            {
                //var productIDs = CartProductsCookie.Value;
                //var ids = productIDs.Split('-');
                //List<int> pIDs = ids.Select(x => int.Parse(x)).ToList();
                // We can do above three line code in one line code which is below.
                model.CartProductIDs = CartProductsCookie.Value.Split('-').Select(x => int.Parse(x)).ToList();
                model.CartProducts = ProductService.Instance.GetProducts(model.CartProductIDs);


            }
            return View(model);
        }

        public ActionResult FilterProducts(string searchTerm, int? minimumPrice, int? maximumPrice, int? categoryID, int? sortBy)
        {
            FilterProductsViewModel model = new FilterProductsViewModel();
            model.Products = ProductService.Instance.SearchProducts(searchTerm, minimumPrice, maximumPrice, categoryID, sortBy);
            return PartialView(model);

        }
    }
}
