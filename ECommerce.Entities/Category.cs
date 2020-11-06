using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entities
{
    public class Category:BaseEntity
    {
        
        List<Product> Products { get; set; }

    }
}