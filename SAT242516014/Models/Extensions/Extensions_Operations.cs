using MyEnums; // Operations Enum'ının olduğu namespace

namespace Extensions // Razor sayfasındaki @using Extensions ile aynı olmalı
{
    public static class Extensions_Operations
    {
        // Description Metodu: Enum'ın adını veya özel açıklamasını döndürür
        public static string Description(this Operations operation)
        {
            return operation switch
            {
                Operations.List => "Listeleme",
                Operations.Add => "Ekle",
                Operations.Update => "Güncelle",
                Operations.Remove => "Sil",
                Operations.Detail => "Detaylar",
                Operations.Reset => "Filtreyi Sıfırla",
                Operations.Cancel => "İptal",
                _ => operation.ToString()
            };
        }

        // Color Metodu: Bootstrap renk sınıflarını döndürür
        public static string Color(this Operations operation)
        {
            return operation switch
            {
                Operations.List => "primary",   // Mavi
                Operations.Add => "success",    // Yeşil
                Operations.Update => "warning", // Sarı
                Operations.Remove => "danger",  // Kırmızı
                Operations.Detail => "info",    // Açık Mavi
                Operations.Reset => "secondary",// Gri
                Operations.Cancel => "dark",    // Koyu Gri
                _ => "secondary"
            };
        }
    }
}