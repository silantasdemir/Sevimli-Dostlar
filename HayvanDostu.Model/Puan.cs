using HayvanDostu.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HayvanDostu.Model
{
    public class Puan : BaseEntity
    {
        public int Puanlama { get; set; }
        public int VeterinerID { get; set; }
        public int BireyselUyeID { get; set; }
        
        // Mapping
        public virtual Veteriner Veteriner { get; set; }
        public virtual BireyselUye BireyselUye { get; set; }

    }
}
