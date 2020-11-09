using ECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.Web.ViewModels
{
    public class HomeViewModels
    {
        public List<Category> Categories { get; set; }
        public List<Product> Product { get; set; }

    }
}