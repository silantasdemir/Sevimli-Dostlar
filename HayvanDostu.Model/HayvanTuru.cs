using HayvanDostu.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HayvanDostu.Model
{
    public class HayvanTuru : BaseEntity
    {
        public string Turu { get; set; }

        //mapping
        public virtual ICollection<HayvanCinsi> HayvanCinsleri { get; set; }
    }
}
