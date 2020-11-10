using ECommerce.Services;
using ECommerce.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Web.Controllers
{
    public class HomeController : Controller
    {
        CategoriesService categoryService = new CategoriesService();
        // GET: Home
        public ActionResult Index()
        {
            HomeViewModels model = new HomeViewModels();
            model.FeaturedCategories = categoryService.GetFeaturedCategories();
            return View(model);

        }
    }
}
