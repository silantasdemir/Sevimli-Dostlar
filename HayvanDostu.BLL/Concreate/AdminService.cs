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
    public class AdminService : IAdminService
    {
        IAdminDAL adminDAL;

        public AdminService(IAdminDAL adminDAL)
        {
            this.adminDAL = adminDAL;
        }
        public void Delete(Admin entity)
        {
            adminDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            Admin admin = adminDAL.Get(a => a.ID == entityID);
            adminDAL.Remove(admin);
        }

        public Admin Get(int entityID)
        {
            return adminDAL.Get(a => a.ID == entityID);
        }

        public ICollection<Admin> GetAll()
        {
            return adminDAL.GetAll();
        }

        public Admin GetUserByLogin(string userName, string password)
        {
            return adminDAL.Get(a => a.KullaniciAdi == userName && a.Sifre == password);
        }

        public void Insert(Admin entity)
        {
            adminDAL.Add(entity);
        }

        public void Update(Admin entity)
        {
            adminDAL.Update(entity);
        }
    }
}
