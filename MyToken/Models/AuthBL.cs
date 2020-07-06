using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyToken.Models
{
    public class AuthBL
    {
        UserManager<IdentityUser> manager;
        public AuthBL()
        {
            UserStore<IdentityUser> store = new UserStore<IdentityUser>(
                new CompanyEntites());
            manager = new UserManager<IdentityUser>(store);
        }
        //Manager ==>identity
        //Find
        public IdentityUser Find(string name,string pass)
        {
            return manager.Find(name, pass);
        }
        //create
        public IdentityResult Create(UserDto userdto)
        {
            IdentityUser identityUser = new IdentityUser();
            identityUser.UserName = userdto.Name;
            identityUser.Email = userdto.Email;


            return manager.Create(identityUser, userdto.Password);
        }
        public IList<string> getUserRoles(IdentityUser user)
        {
            var roles = manager.GetRolesAsync(user.Id).Result;
            return roles;
                
        }
    }
}






