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
    public class HizmetService : IHizmetService
    {
        IHizmetDAL hizmetDAL;
        public HizmetService(IHizmetDAL iHizmetDAL)
        {
            this.hizmetDAL = iHizmetDAL;
        }
        public void Delete(Hizmet entity)
        {
            hizmetDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            Hizmet hizmet = hizmetDAL.Get(a=>a.ID==entityID);
            hizmetDAL.Remove(hizmet);
        }

        public Hizmet Get(int entityID)
        {
            return hizmetDAL.Get(a=>a.ID==entityID);
        }

        public ICollection<Hizmet> GetAll()
        {
            return hizmetDAL.GetAll();
        }

        public void Insert(Hizmet entity)
        {
            hizmetDAL.Add(entity);
        }

        public void Update(Hizmet entity)
        {
            hizmetDAL.Update(entity);
        }
    }
}
