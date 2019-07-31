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
    public class KonaklamaService : IKonaklamaService
    {
        IKonaklamaDAL konaklamaDAL;
        public KonaklamaService(IKonaklamaDAL iKonaklamaDAL)
        {
            this.konaklamaDAL = iKonaklamaDAL;
        }
        public void Delete(Konaklama entity)
        {
            konaklamaDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            Konaklama konaklama = konaklamaDAL.Get(a=>a.ID==entityID);
            konaklamaDAL.Remove(konaklama);
        }

        public Konaklama Get(int entityID)
        {
            return konaklamaDAL.Get(a=>a.ID==entityID);
        }

        public ICollection<Konaklama> GetAll()
        {
            return konaklamaDAL.GetAll();
        }

        public void Insert(Konaklama entity)
        {
            konaklamaDAL.Add(entity);
        }

        public void Update(Konaklama entity)
        {
            konaklamaDAL.Update(entity);
        }
    }
}
