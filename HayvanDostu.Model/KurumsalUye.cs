using HayvanDostu.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HayvanDostu.Model
{
    public class KurumsalUye : Uye
    {
        public string KurumAdi { get; set; }
        public int HizmetBaslangicYili { get; set; }
        public string Telefon2 { get; set; }
        public string FotoUrl2 { get; set; }
        public string FotoUrl3 { get; set; }
        public string FotoUrl4 { get; set; }
        public string FotoUrl5 { get; set; }
        public string FotoUrl6 { get; set; }
        public string FotoUrl7 { get; set; }
        public KurumTuru KurumTuru { get; set; }

        // Mapping
        public virtual ICollection<Veteriner> Veterinerler { get; set; }
        public virtual ICollection<Puan> Puanlar { get; set; }
        public virtual ICollection<Yorum> Yorumlar { get; set; }
        public virtual ICollection<Rezervasyon> Rezervasyonlar { get; set; }
        public virtual ICollection<KonaklamaRezervasyon> KonaklamaRezervasyonlari { get; set; }
        public virtual ICollection<Cizelge> Cizelgeler { get; set; }
        public virtual ICollection<Hizmet> Hizmetler { get; set; }

    }
}
