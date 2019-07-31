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
    public class KurumsalUyeService : IKurumsalUyeService
    {
        IKurumsalUyeDAL kurumsalUyeDAL;
        HayvanDostuDbContext db;

        public KurumsalUyeService(IKurumsalUyeDAL iKurumsalUyeDAL,HayvanDostuDbContext db)
        {
            this.kurumsalUyeDAL = iKurumsalUyeDAL;
            this.db = db;
        }
        public void Delete(KurumsalUye entity)
        {
            kurumsalUyeDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            KurumsalUye kurumsalUye = kurumsalUyeDAL.Get(a => a.ID == entityID);
            kurumsalUyeDAL.Remove(kurumsalUye);
        }

        public KurumsalUye Get(int entityID)
        {
            return kurumsalUyeDAL.Get(a => a.ID == entityID);
        }

        public ICollection<KurumsalUye> GetAll()
        {
            return kurumsalUyeDAL.GetAll();
        }

        public ICollection<KurumsalUye> GetAll(bool durum)
        {
            return kurumsalUyeDAL.GetAll(a => a.OnaylandiMi == durum);
        }

        public KurumsalUye GetMail(string mail)
        {
            return kurumsalUyeDAL.Get(a => a.Email == mail);
        }

        public KurumsalUye GetUploadPhoto(KurumsalUye kurumsalUye, HttpPostedFileBase file)
        {
            if (file != null)
            {
                file.SaveAs(HttpContext.Current.Server.MapPath("~/Image/") +
                                                              new Guid() + "_" + file.FileName);
                kurumsalUye.FotoUrl = new Guid() + "_" + file.FileName;
            }
            db.KurumsalUyeler.Add(kurumsalUye);
            db.SaveChanges();

            return kurumsalUye;

        }

        public KurumsalUye GetUserByLogin(string userName, string password)
        {
            return kurumsalUyeDAL.Get(a => a.KullaniciAdi == userName && a.Sifre == password);
        }

        public void Insert(KurumsalUye entity)
        {
            kurumsalUyeDAL.Add(entity);
        }

        public void Update(KurumsalUye entity)
        {
            kurumsalUyeDAL.Update(entity);
        }
    }
}
