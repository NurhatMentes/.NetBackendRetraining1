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
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductNameInvalid = "Ürün Doğrulanamadı";
        public static string MaitenanceTime = "Sistem Bakımda";
        public static string ProductListed = "Ürünler Listelendi";
        public static string ProductCountOfCategoryError = "Bir kategoriye enfazla 10 ürün ekleyebilirsiniz";
        public static string ProductNameAlreadyExists = "Bu ürün daha önce eklenmiş";
        public static string CheckCategoryCountError = "En fazla 15 tane kategori olabilir";
    }
}
