using HayvanDostu.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HayvanDostu.Model
{
    public class Yorum : BaseEntity
    {
        public string Yorumlama { get; set; }
        public int VeterinerID { get; set; }
        public int BireyselUyeID { get; set; }
        public int KurumsalUyeID { get; set; }


        // Mapping
        public virtual Veteriner Veteriner { get; set; }
        public virtual BireyselUye BireyselUye { get; set; }
        public virtual KurumsalUye KurumsalUye { get; set; }

    }
}
