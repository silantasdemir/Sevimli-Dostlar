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
    public class RezervasyonService : IRezervasyonService
    {
        IRezervasyonDAL rezervasyonDAL;
        public RezervasyonService(IRezervasyonDAL iRezervasyonDAL)
        {
            this.rezervasyonDAL = iRezervasyonDAL;
        }
        public void Delete(Rezervasyon entity)
        {
            rezervasyonDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            Rezervasyon rezervasyon = rezervasyonDAL.Get(a=>a.ID==entityID);
            rezervasyonDAL.Remove(rezervasyon);
        }

        public Rezervasyon Get(int entityID)
        {
            return rezervasyonDAL.Get(a=>a.ID==entityID);
        }

        public ICollection<Rezervasyon> GetAll()
        {
            return rezervasyonDAL.GetAll();
        }

        public ICollection<Rezervasyon> GetAllByKurumId(int id)
        {
            return rezervasyonDAL.GetAll(a=>a.KurumsalUyeID==id);
        }

        public void Insert(Rezervasyon entity)
        {
            rezervasyonDAL.Add(entity);
        }

        public void Update(Rezervasyon entity)
        {
            rezervasyonDAL.Update(entity);
        }
    }
}
