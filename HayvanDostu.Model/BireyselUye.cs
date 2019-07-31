using HayvanDostu.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HayvanDostu.Model
{
    public class BireyselUye : Uye
    {
        //public BireyselUye()
        //{
        //    Puanlar =new HashSet<Puan>();
        //    Hayvanlar = new HashSet<Hayvan>();
        //    Yorumlar = new HashSet<Yorum>();
        //    Konaklamalar = new HashSet<Konaklama>();

        //}
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public DateTime DogumTarihi { get; set; }
        public bool Cinsiyet { get; set; }
        public bool EvcilHayvaniVarMi { get; set; }
        public int Sayi { get; set; }

        // Mapping
        public virtual ICollection<Puan> Puanlar { get; set; }
        public virtual ICollection<Hayvan> Hayvanlar { get; set; }
        public virtual ICollection<Yorum> Yorumlar { get; set; }
        public virtual ICollection<Konaklama> Konaklamalar { get; set; }


    }
}
