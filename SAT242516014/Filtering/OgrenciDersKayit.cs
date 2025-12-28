using System;
using SAT242516014.Models.MyResources;
using Attributes; // Eğer proje yapınızda Attribute'lar bu namespace altındaysa ekleyin.

namespace SAT242516014.Filtering
{
    public class OgrenciDersKayit
    {
        // --- GİZLİ ID ALANLARI (İşlem yapmak için gerekli) ---
        // Bu alanlar veritabanındaki Foreign Key'lerdir.

        [Sortable(false)] // ID'ye göre sıralama genelde kullanıcıya açılmaz
        [Editable(true)]  // Ekleme/Güncelleme yaparken bu ID'leri set ediyoruz
        [Viewable(false)] // Listede direkt ID göstermiyoruz
        public int OgrenciId { get; set; }

        [Sortable(false)]
        [Editable(true)]
        [Viewable(false)]
        public int DersId { get; set; }

        [Sortable(false)]
        [Editable(true)]
        [Viewable(false)]
        public int OgretmenId { get; set; }


        // --- GÖRÜNÜR KOLONLAR (Listeleme için gerekli) ---
        // Bu alanlar SQL'deki JOIN sorgularından gelen metinlerdir.

        [Sortable(true)]
        [Editable(false)] // Ad soyad text olarak düzenlenmez, ID seçilerek değişir
        [Viewable(true)]
        [LocalizedDescription("OgrenciAdSoyad", typeof(MyResource))]
        public string OgrenciAdSoyad { get; set; }

        [Sortable(true)]
        [Editable(false)]
        [Viewable(true)]
        [LocalizedDescription("SinifAdi", typeof(MyResource))]
        public string SinifAdi { get; set; }

        [Sortable(true)]
        [Editable(false)]
        [Viewable(true)]
        [LocalizedDescription("DersAd", typeof(MyResource))]
        public string DersAd { get; set; }

        [Sortable(true)]
        [Editable(false)]
        [Viewable(true)]
        [LocalizedDescription("OgretmenAdSoyad", typeof(MyResource))]
        public string OgretmenAdSoyad { get; set; }

        // --- HEM GÖRÜNÜR HEM DÜZENLENEBİLİR ALANLAR ---

        [Sortable(true)]
        [Editable(true)]
        [Viewable(true)]
        [LocalizedDescription("Donem", typeof(MyResource))]
        public string Donem { get; set; }

        [Sortable(true)]
        [Editable(true)]
        [Viewable(true)]
        [LocalizedDescription("KayitTarihi", typeof(MyResource))]
        public DateTime? KayitTarihi { get; set; }
    }
}