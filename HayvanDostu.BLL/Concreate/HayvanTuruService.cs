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
    public class HayvanTuruService : IHayvanTuruService
    {
        IHayvanTuruDAL hayvanTuruDAL;
        public HayvanTuruService(IHayvanTuruDAL iHayvanTuruDAL)
        {
            this.hayvanTuruDAL = iHayvanTuruDAL;
        }
        public void Delete(HayvanTuru entity)
        {
            hayvanTuruDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            HayvanTuru hayvanTuru = hayvanTuruDAL.Get(a=>a.ID==entityID);
            hayvanTuruDAL.Remove(hayvanTuru);
        }

        public HayvanTuru Get(int entityID)
        {
            return hayvanTuruDAL.Get(a=>a.ID==entityID);
        }

        public ICollection<HayvanTuru> GetAll()
        {
            return hayvanTuruDAL.GetAll();
        }

        public void Insert(HayvanTuru entity)
        {
            hayvanTuruDAL.Add(entity);
        }

        public void Update(HayvanTuru entity)
        {
            hayvanTuruDAL.Update(entity);
        }
    }
}
