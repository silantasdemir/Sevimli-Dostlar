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
    public class OdemeService : IOdemeService
    {
        IOdemeDAL odemeDAL;
        public OdemeService(IOdemeDAL iOdemeDAL)
        {
            this.odemeDAL = iOdemeDAL;
        }
        public void Delete(Odeme entity)
        {
            odemeDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            Odeme odeme = odemeDAL.Get(a=>a.ID==entityID);
        }

        public Odeme Get(int entityID)
        {
            return odemeDAL.Get(a=>a.ID==entityID);
        }

        public ICollection<Odeme> GetAll()
        {
            return odemeDAL.GetAll();
        }

        public void Insert(Odeme entity)
        {
            odemeDAL.Add(entity);
        }

        public void Update(Odeme entity)
        {
            odemeDAL.Update(entity);
        }
    }
}
