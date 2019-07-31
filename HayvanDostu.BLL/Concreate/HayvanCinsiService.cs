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
    public class HayvanCinsiService : IHayvanCinsiService
    {
        IHayvanCinsiDAL hayvanCinsiDAL;
        public HayvanCinsiService(IHayvanCinsiDAL iHayvanCinsiDAL)
        {
            this.hayvanCinsiDAL = iHayvanCinsiDAL;
        }
        public void Delete(HayvanCinsi entity)
        {
            hayvanCinsiDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            HayvanCinsi hayvanCinsi = hayvanCinsiDAL.Get(a=>a.ID==entityID);
            hayvanCinsiDAL.Remove(hayvanCinsi);
        }

        public HayvanCinsi Get(int entityID)
        {
            return hayvanCinsiDAL.Get(a=>a.ID==entityID);
        }

        public ICollection<HayvanCinsi> GetAll()
        {
            return hayvanCinsiDAL.GetAll();
        }

        public void Insert(HayvanCinsi entity)
        {
            hayvanCinsiDAL.Add(entity);
        }

        public void Update(HayvanCinsi entity)
        {
            hayvanCinsiDAL.Update(entity);
        }
    }
}
