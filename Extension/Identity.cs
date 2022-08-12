using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LUANVANTOTNGHIEP_VODUCANKHANG.Extension
{
    public static class Identity
    {
        public static string getspecific(this ClaimsPrincipal claimsPrincipal,string claimtype)
        {
            var claim = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == claimtype);
            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}
