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
    public class VeterinerService : IVeterinerService
    {
        IVeterinerDAL veterinerDAL;
        public VeterinerService(IVeterinerDAL iVeterinerDAL)
        {
            this.veterinerDAL = iVeterinerDAL;
        }
        public void Delete(Veteriner entity)
        {
            veterinerDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            Veteriner veteriner = veterinerDAL.Get(a=>a.ID==entityID);
            veterinerDAL.Remove(veteriner);
        }

        public Veteriner Get(int entityID)
        {
            return veterinerDAL.Get(a=>a.ID==entityID);
        }

        public ICollection<Veteriner> GetAll()
        {
            return veterinerDAL.GetAll();
        }

        public void Insert(Veteriner entity)
        {
            veterinerDAL.Add(entity);
        }

        public void Update(Veteriner entity)
        {
            veterinerDAL.Update(entity);
        }
    }
}
