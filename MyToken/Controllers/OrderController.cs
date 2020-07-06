using MyToken.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyToken.Controllers
{
   // [Authorize]
  
    public class OrderController : ApiController
    {
        CompanyEntites context = new CompanyEntites();
        public IHttpActionResult GetAll()
        {
            return Ok(context.Orders.ToList());
        }
        public IHttpActionResult Post(Order order)
        {
            if (ModelState.IsValid)
            {
                context.Orders.Add(order);
                context.SaveChanges();
                return Created("Created Succeed", order);
            }
            return BadRequest("Data Incorrect");
        }
    }
}