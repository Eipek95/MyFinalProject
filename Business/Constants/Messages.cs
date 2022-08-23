using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        //bir değişken normalde ilk harfi küçük olur ama public olduğu için ilk harfi büyük olur.private bir field olsa ilk harfi küçük olur(pascal case)
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime="Sistem bakımda";
        public static string ProductListed="Ürün Listelendi";
    }
}
