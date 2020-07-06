using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using MyToken.Models;
using Owin;

[assembly: OwinStartup(typeof(MyToken.Startup1))]

namespace MyToken
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions()
            {
                TokenEndpointPath = new PathString("/token"),
                AllowInsecureHttp = true,
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(5),
                Provider = new MyProvider(),
             
                //exp
                //token path
                //http
                //Provide
            });
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }

    public class MyProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
           // context.ClientId;
            context.Validated();
        }
        //public override async Task GrantResourceOwnerCredentials(
        //  OAuthGrantResourceOwnerCredentialsContext context)
        //{
        //    context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
        //    AuthBL repo = new AuthBL();
        //    IdentityUser user = repo.Find(context.UserName, context.Password);
        //    if (user == null)
        //    {
        //        context.SetError("Error User Pass Not valid");
        //    }
        //    ClaimsIdentity claims = new ClaimsIdentity(context.Options.AuthenticationType);
        //    claims.AddClaim(new Claim("Name", user.UserName));
        //     claims.AddClaim(new Claim("Role", "Admin"));
        //    context.Validated(claims);

        //}
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            AuthBL repo = new AuthBL();
            IdentityUser user = repo.Find(context.UserName, context.Password);
         
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
             identity.AddClaim(new Claim("Name", context.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Role, "User"));
            //  identity.AddClaim(new Claim("Name", user.UserName));
        
            identity.AddClaim(new Claim("Role", "Admin"));
            context.Validated(identity);

        }
    }
}
