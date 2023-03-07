using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Car added";
        public static string BrandAdded="Brand added";
        public static string ColorAdded = "Color added";
        public static string CustomerAdded = "Customer added";
        public static string RentalAdded = "Kiralama başarıyla eklendi.";
        public static string UserAdded = "Kullanıcı başarıyla eklendi";
        public static string CarImageAdded = "Araba resmi başarıyla eklendi.";

        public static string BrandDeleted="Brand deleted";
        public static string CarDeleted = "Car deleted";
        public static string ColorDeleted = "Color deleted";
        public static string RentalDeleted = "Kiralama başarıyla silindi.";
        public static string UserDeleted = "Kullanıcı başarıyla silindi";
        public static string CustomerDeleted = "Müşteri başarıyla silindi";
        public static string CarImageDeleted = "Araba resmi başarıyla silindi.";

        public static string BrandUpdated = "Brand updated";
        public static string CarUpdated = "Car updated";
        public static string ColorUpdated = "Color updated";
        public static string RentalUpdated = "Kiralama başarıyla güncellendi";
        public static string UserUpdated = "Kullanıcı başarıyla güncellendi";
        public static string CustomerUpdated = "Müşteri başarıyla güncellendi";
        public static string CarImageUpdated = "Araba resmi başarıyla güncellendi";

        public static string RentalCarMissing = "Kiralanacak araç şuanda başka bir kiralamada.";
        public static string CarNameLengthShort = "Araba ismi 2'den kısa olamaz";
        public static string CarDailyPriceInvalid = "Araba günlük fiyatı 0'dan büyük olmalıdır";
        public static string UserExists = "Bu e-posta ile kayıtlı kullanıcı bulunmaktadır.";
        public static string CarImageLimitExceeded = "Ara resim limiti aşıldı";
        public static string AuthorizationFailed = "Yetkiniz yok.";
        public static string UserRegistered = "Kullanıcı başarıyla kayıt edildi";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError = "Şifre yanlış";
        public static string SuccessfulLogin = "Başarıyla giriş yapıldı";
        public static string AccessTokenCreated = "Giriş tokeni üretildi.";

        public static string UserAlreadyExists = "Böyle bir kullanıcı zaten var";
        public static string BrandExists = "Bu isimle bir marka zaten var.";
        public static string CarExists = "Bu isimle bir araba zaten var.";
        public static string ColorExists = "Bu isimle bir renk zaten var.";
    }
}
