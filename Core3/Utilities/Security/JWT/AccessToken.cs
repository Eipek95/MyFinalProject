using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core3.Utilities.Security.JWT
{
    public class AccessToken
    {
        public string Token { get; set; }//giriş anahtar değeri
        public DateTime Expiration { get; set; }//jeton bitiş zamanıdır
    }
}
