using HayvanDostu.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HayvanDostu.Model
{
    public class HayvanCinsi : BaseEntity
    {
        public string Cinsi { get; set; }
        public int HayvanTuruID { get; set; }

        // Mapping
        public virtual HayvanTuru HayvanTuru { get; set; }

    }
}
