using ECommerce.Database;
using ECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services
{
    public class ConfigurationService
    {
        public Config GetConfig(string Key)
        {
            using (var context=new CBContext())
            {
                return context.Configurations.Find(Key);
            }
        }
    }

}
