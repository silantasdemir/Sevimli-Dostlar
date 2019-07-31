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
    public class PuanService : IPuanService
    {
        IPuanDAL puanDAL;
        public PuanService(IPuanDAL iPuanDAL)
        {
            this.puanDAL = iPuanDAL;
        }
        public void Delete(Puan entity)
        {
            puanDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            Puan puan = puanDAL.Get(a=>a.ID==entityID);
            puanDAL.Remove(puan);
        }

        public Puan Get(int entityID)
        {
            return puanDAL.Get(a=>a.ID==entityID);
        }

        public ICollection<Puan> GetAll()
        {
            return puanDAL.GetAll();
        }

        public void Insert(Puan entity)
        {
            puanDAL.Add(entity);
        }

        public void Update(Puan entity)
        {
            puanDAL.Update(entity);
        }
    }
}
