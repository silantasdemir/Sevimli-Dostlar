using HayvanDostu.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HayvanDostu.Model
{
    public class Veteriner : BaseEntity
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public DateTime DogumTarihi { get; set; }
        public bool Cinsiyet { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public string FotoUrl { get; set; }
        public string MezunOlduguOkul { get; set; }
        public DateTime MezuniyetTarihi { get; set; }
        public string Deneyimler { get; set; }
        public int KurumID { get; set; }

        // Mapping
        public virtual KurumsalUye Kurum { get; set; }
        public virtual ICollection<Puan> Puanlar { get; set; }
        public virtual ICollection<Yorum> Yorumlar { get; set; }


    }
}
