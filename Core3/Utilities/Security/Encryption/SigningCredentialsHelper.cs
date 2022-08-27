using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core3.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        //Credentials---->kullanıcı giriş bilgileri demek(kullanıcı adı veya mail ve şifre vs)
        public static SigningCredentials CreateSigningCredentail(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
            //anahtar ve şifreleme anahtarını veririz.
        }
    }
}
