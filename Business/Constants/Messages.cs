using Core3.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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
        public static string ProductCountOfCategoryError="Bir kategoride en fazla 10 ürün olabilir";
        public static string ProductNameAlreadyExists="Aynı isimli ürün zaten mevcut";
        public static string CategoryLimitExceded="Kategori limiti aşıldığı için yeni ürün eklenemiyor";
        public static string AuthorizationDenied="Yetkiniz yok";
        public static string UserRegistered="Kayıt Oldu";
        public static string UserNotFound="Kullanıcı Bulunamadı";
        public static string PasswordError="Parola Hatası";
        public static string SuccessfulLogin="Giriş Başarılı";
        public static string UserAlreadyExists="Kullanıcı Zaten Kayıtlu";
        public static string AccessTokenCreated="Token oluşturuldu";
    }
}
