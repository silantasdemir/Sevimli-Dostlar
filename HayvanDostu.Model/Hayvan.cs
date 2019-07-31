using HayvanDostu.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HayvanDostu.Model
{
    public class Hayvan : BaseEntity
    {
        public string Ad { get; set; }
        public DateTime DogumTarihi { get; set; }
        public bool Cinsiyet { get; set; }
        public string Hikayesi { get; set; }
        [DataType(DataType.Upload)]
        [DisplayName("Upload File")]
        public string FotoUrl1 { get; set; }
        public string FotoUrl2 { get; set; }
        public string FotoUrl3 { get; set; }
        public string FotoUrl4 { get; set; }
        public int BireyselUyeID { get; set; }
        public int HayvanCinsiID { get; set; }

        // Mapping
        public virtual HayvanCinsi HayvanCinsi { get; set; }
        public virtual BireyselUye BireyselUye { get; set; }

    }
}
