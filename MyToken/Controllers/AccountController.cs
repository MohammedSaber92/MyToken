using Microsoft.AspNet.Identity;
using MyToken.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyToken.Controllers
{
    public class AccountController : ApiController
    {
        public IHttpActionResult post(UserDto User)
        {
            AuthBL repos = new AuthBL();
            IdentityResult MyUser = repos.Create(User);
            if (MyUser.Succeeded)

                return Created("", "Created");
            else
                return BadRequest(MyUser.Errors.FirstOrDefault());
        }
    }
}
