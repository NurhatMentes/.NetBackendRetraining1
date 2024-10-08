﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductNotFound = "Ürün bulunamadı";
        public static string ProductUnitsInStockMinError = "Stok adeti en az 2 olabilir";
        public static string ProductUpdated = "Ürün Güncellendi";
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductNameInvalid = "Ürün Doğrulanamadı";
        public static string MaitenanceTime = "Sistem Bakımda";
        public static string ProductListed = "Ürünler Listelendi";
        public static string ProductCountOfCategoryError = "Bir kategoriye enfazla 10 ürün ekleyebilirsiniz";
        public static string ProductNameAlreadyExists = "Ürün ismi zaten mevcut";
        public static string CheckCategoryCountError = "En fazla 15 tane kategori olabilir";

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";

        public static string AuthorizationDenied = "Yetkiniz yok";

    }
}
