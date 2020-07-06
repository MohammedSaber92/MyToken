using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyToken.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int TotalCost { get; set; }
        //Fro ==>user Identity
        [ForeignKey("IdentityUser")]
        public string UserId { get; set; }
        public virtual IdentityUser IdentityUser { get; set; }
                                           //  public virtual List<Product> Products { get; set; }
                                           //..
    }
}