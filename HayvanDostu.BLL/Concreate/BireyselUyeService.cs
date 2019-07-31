using HayvanDostu.BLL.Abstract;
using HayvanDostu.DAL.Abstract;
using HayvanDostu.DAL.Concreate;
using HayvanDostu.Model;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;



namespace HayvanDostu.BLL.Concreate
{
    public class BireyselUyeService : IBireyselUyeService
    {
        IBireyselUyeDAL bireyselUyeDAL;
        HayvanDostuDbContext db;

        public BireyselUyeService(IBireyselUyeDAL iBireyselUyeDAL, HayvanDostuDbContext _db)
        {
            this.bireyselUyeDAL = iBireyselUyeDAL;
            this.db = _db;
        }
        public void Delete(BireyselUye entity)
        {
            bireyselUyeDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            BireyselUye bireyselUye = bireyselUyeDAL.Get(a => a.ID == entityID);
            bireyselUyeDAL.Remove(bireyselUye);
        }

        public BireyselUye Get(int entityID)
        {
            return bireyselUyeDAL.Get(a => a.ID == entityID);
        }

        public ICollection<BireyselUye> GetAll()
        {
            return bireyselUyeDAL.GetAll();
        }

        public ICollection<BireyselUye> GetAll(bool durum)
        {
            return bireyselUyeDAL.GetAll(a => a.OnaylandiMi == durum);
        }

        public BireyselUye GetMail(string mail)
        {
            return bireyselUyeDAL.Get(a => a.Email == mail);
        }

        public BireyselUye GetUploadPhoto(BireyselUye bireyselUye, HttpPostedFileBase file)
        {

            if (file != null)
            {
                file.SaveAs(HttpContext.Current.Server.MapPath("~/Image/") +
                                                              new Guid() + "_" + file.FileName);
                bireyselUye.FotoUrl = new Guid() + "_" + file.FileName;
            }
            db.BireyselUyeler.Add(bireyselUye);
            db.SaveChanges();

            return bireyselUye;

        }

        public BireyselUye GetUserByLogin(string userName, string password)
        {
            return bireyselUyeDAL.Get(a => a.KullaniciAdi == userName && a.Sifre == password);
        }

        public void Insert(BireyselUye entity)
        {
            bireyselUyeDAL.Add(entity);
        }

        public void Update(BireyselUye entity)
        {
            bireyselUyeDAL.Update(entity);
        }
    }
}
