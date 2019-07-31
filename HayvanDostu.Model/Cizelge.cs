using HayvanDostu.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HayvanDostu.Model
{
    public class Cizelge : BaseEntity
    {
        public DateTime Tarih { get; set; }
        public string Saat { get; set; }
        public bool DoluMu { get; set; }
        public int KurumsalUyeID { get; set; }
        

        // Mapping
        public virtual KurumsalUye KurumsalUye { get; set; }

    }
}
