using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core3.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    {
        ///appsettings'teki SecurityKey stringini encyription'e parametre geçemeyiz.bytearray haline gelmesi gerekir.burası bytearray haline getirir
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            //securityKey değerinin byteni alıp onu SymmetricSecurityKey haline getirir
        }
    }
}
