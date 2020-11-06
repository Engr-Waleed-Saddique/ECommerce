using ECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Database
{
    class CBContext : DbContext
    {
        public CBContext():base("ECommerce")
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product>  Products{get;set;}

        
    }
}
