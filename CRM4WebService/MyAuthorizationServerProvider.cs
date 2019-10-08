using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace CRM4WebService
{
    public class MyAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {

        NLog.Logger token_log = NLog.LogManager.GetCurrentClassLogger();
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated(); // 
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            if (context.UserName == "admin" && context.Password == "admin")
            {                
                identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                identity.AddClaim(new Claim("username", "admin"));
                identity.AddClaim(new Claim(ClaimTypes.Name, "Oleg"));
                context.Validated(identity);                
            }
            else if (context.UserName == "1cReader" && context.Password == "Ghjdthrf123")
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "Reader"));
                //identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                identity.AddClaim(new Claim("username", "1cReader"));
                identity.AddClaim(new Claim(ClaimTypes.Name, "Михаил"));
                context.Validated(identity);
            }
            else if (context.UserName == "Aonline" && context.Password == "Ghjdthrf123")
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "Reader"));
                //identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                identity.AddClaim(new Claim("username", "Aonline"));
                identity.AddClaim(new Claim(ClaimTypes.Name, "Зульфия"));
                context.Validated(identity);
            }
            else
            {
                token_log.Error($"invalid_grant. Provided username '{context.UserName}' and password '{context.Password}' is incorrect.");
                //context.SetError("invalid_grant", "Provided username and password is incorrect");
                return;
            }
            token_log.Info($"Valid_grant. Provided username '{context.UserName}' and password '{context.Password}' is correct. Hello " + identity.Name);
        }
    }
}