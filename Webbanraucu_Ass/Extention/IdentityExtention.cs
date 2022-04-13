using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Webbanraucu_Ass.Extention
{
    public static class IdentityExtention
    {
        public  static string GetspecificClaim(this ClaimsPrincipal claimsPrincipal,string claimType)
        {
            var claim = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == claimType);
            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}
