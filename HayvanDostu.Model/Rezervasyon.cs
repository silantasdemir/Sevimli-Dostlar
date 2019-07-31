using HayvanDostu.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HayvanDostu.Model
{
    public class Rezervasyon : BaseEntity
    {
        public DateTime Tarih { get; set; }
        public int KurumsalUyeID { get; set; }
        public int BireyselUyeID { get; set; }
        public int HizmetID { get; set; }


        // Mapping
        public virtual KurumsalUye KurumsalUye { get; set; }
        public virtual BireyselUye BireyselUye { get; set; }
        public virtual Hizmet Hizmet { get; set; }

    }
}
