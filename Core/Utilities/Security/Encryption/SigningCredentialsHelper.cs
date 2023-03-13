using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilites.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredential(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
