using HayvanDostu.BLL.Abstract;
using HayvanDostu.DAL.Abstract;
using HayvanDostu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HayvanDostu.BLL.Concreate
{
    public class KonaklamaRezervasyonService : IKonaklamaRezervasyonService
    {
        IKonaklamaRezervasyonDAL konaklamaRezervasyonDAL;
        public KonaklamaRezervasyonService(IKonaklamaRezervasyonDAL iKonaklamaRezervasyonDAL)
        {
            this.konaklamaRezervasyonDAL = iKonaklamaRezervasyonDAL;
        }
        public void Delete(KonaklamaRezervasyon entity)
        {
            konaklamaRezervasyonDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            KonaklamaRezervasyon konaklamaRezervasyon = konaklamaRezervasyonDAL.Get(a=>a.ID==entityID);
            konaklamaRezervasyonDAL.Remove(konaklamaRezervasyon);
        }

        public KonaklamaRezervasyon Get(int entityID)
        {
            return konaklamaRezervasyonDAL.Get(a=>a.ID==entityID);
        }

        public ICollection<KonaklamaRezervasyon> GetAll()
        {
            return konaklamaRezervasyonDAL.GetAll();
        }

        public void Insert(KonaklamaRezervasyon entity)
        {
            konaklamaRezervasyonDAL.Add(entity);
        }

        public void Update(KonaklamaRezervasyon entity)
        {
            konaklamaRezervasyonDAL.Update(entity);
        }
    }
}
