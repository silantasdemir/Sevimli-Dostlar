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
    public class CizelgeService : ICizelgeService
    {
        ICizelgeDAL cizelgeDAL;
        public CizelgeService(ICizelgeDAL iCizelgeDAL)
        {
            this.cizelgeDAL = iCizelgeDAL;
        }
        public void Delete(Cizelge entity)
        {
            cizelgeDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            Cizelge cizelge = cizelgeDAL.Get(a=>a.ID==entityID);
            cizelgeDAL.Remove(cizelge);
        }

        public Cizelge Get(int entityID)
        {
            return cizelgeDAL.Get(a=>a.ID==entityID);
        }

        public ICollection<Cizelge> GetAll()
        {
            return cizelgeDAL.GetAll();
        }

        public void Insert(Cizelge entity)
        {
            cizelgeDAL.Add(entity);
        }

        public void Update(Cizelge entity)
        {
            cizelgeDAL.Update(entity);
        }
    }
}
