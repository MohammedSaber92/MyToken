using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyToken.Models
{
    public class CompanyEntites:IdentityDbContext
    {
        //Dbset<identityRole> roles
        //Dbset<identityUser> users
        public CompanyEntites():base("CompanyCS")
        {

        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}