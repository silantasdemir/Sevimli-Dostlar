using HayvanDostu.Core.Entity;
using HayvanDostu.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HayvanDostu.Model
{
    public class Odeme : BaseEntity
    {
        public string KartNo { get; set; }
        public string GuvenlikKodu { get; set; }
        public string SonKullanmaTarihi { get; set; }
        public string KartSahibi { get; set; }
        public OdemeSekli OdemeSekli { get; set; }

        // Mapping
        public virtual ICollection<KonaklamaRezervasyon> KonaklamaRezervasyonlari { get; set; }
    }
}
