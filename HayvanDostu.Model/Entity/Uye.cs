using HayvanDostu.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HayvanDostu.Model.Entity
{
    public abstract class Uye : BaseEntity
    {
        public Uye()
        {
            OnaylandiMi = false;
       
        }

        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string Email { get; set; }
        public bool OnaylandiMi { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }

        [DataType(DataType.Upload)]

        [DisplayName("Upload File")]
        public string FotoUrl { get; set; }

      //  public HttpPostedFileBase ImageFile { get; set; }

    }
}
