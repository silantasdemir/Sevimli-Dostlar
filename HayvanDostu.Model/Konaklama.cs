using HayvanDostu.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HayvanDostu.Model
{
    public class Konaklama : BaseEntity
    {
        //Bireysel Konaklama
        public string FotoUrl1 { get; set; }
        public string FotoUrl2 { get; set; }
        public string FotoUrl3 { get; set; }
        public string FotoUrl4 { get; set; }
        public string FotoUrl5 { get; set; }
        public string FotoUrl6 { get; set; }
        public string Meslek { get; set; }
        public string EvcilHayvanlari { get; set; }
        public string BaktigiHayvanlar { get; set; }
        public string FiyatListesi { get; set; }
        public int BireyselUyeID { get; set; }



        // Mapping
        public virtual BireyselUye BireyselUye { get; set; }

    }
}
