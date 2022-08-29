using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core3.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        //hash oluşturma kısmı
        //sistene girerken verdiğimiz passwordun hashini oluşturur
        public static void CreatePasswordHash
            (string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())//hangi algoritmayı kullanacağımızı söyleriz
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }


        //kullanıcının sisteme girdiği parolanın doğruluğunu salt ve hashe göre db teki değerle karşılaştırıp kontrol eder
        ///hash doğrulama kısmı hash oluşturma kısmında kullandığımız aloritmayı ve saltla doğrulama yaparız
        public static bool VerifyPasswordHash
            (string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])//hesaplanan hash ile db gelen hash
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
