using HayvanDostu.BLL.Abstract;
using HayvanDostu.DAL.Abstract;
using HayvanDostu.DAL.Concreate;
using HayvanDostu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HayvanDostu.BLL.Concreate
{
    public class HayvanService : IHayvanService
    {
        IHayvanDAL hayvanDAL;
        HayvanDostuDbContext db;

        public HayvanService(IHayvanDAL iHayvanDAL, HayvanDostuDbContext db)
        {
            this.hayvanDAL = iHayvanDAL;
            this.db = db;
        }
        public void Delete(Hayvan entity)
        {
            hayvanDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            Hayvan hayvan = hayvanDAL.Get(a => a.ID == entityID);
            hayvanDAL.Remove(hayvan);
        }

        public Hayvan Get(int entityID)
        {
            return hayvanDAL.Get(a => a.ID == entityID);
        }

        public ICollection<Hayvan> GetAll()
        {
            return hayvanDAL.GetAll();
        }

        public Hayvan GetUploadPhoto(Hayvan hayvan, HttpPostedFileBase file)
        {
            if (file != null)
            {
                file.SaveAs(HttpContext.Current.Server.MapPath("~/Image/") +
                                                              new Guid() + "_" + file.FileName);
                hayvan.FotoUrl1 = new Guid() + "_" + file.FileName;
            }

            db.Hayvanlar.Add(hayvan);
            db.SaveChanges();

            return hayvan;
        }

        public void Insert(Hayvan entity)
        {
            hayvanDAL.Add(entity);
        }

        public void Update(Hayvan entity)
        {
            hayvanDAL.Update(entity);
        }
    }
}
