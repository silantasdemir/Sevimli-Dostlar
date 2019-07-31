using HayvanDostu.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HayvanDostu.Model
{
    public class Hizmet : BaseEntity
    {
        public string HizmetTipi { get; set; }
        public int KurumsalUyeID { get; set; }
        public int KonaklamaID { get; set; }

        // Mapping
        public virtual KurumsalUye KurumsalUye { get; set; }
        public virtual Konaklama Konaklama { get; set; }

    }
}
