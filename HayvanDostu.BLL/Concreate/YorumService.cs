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
    public class YorumService : IYorumService
    {
        IYorumDAL yorumDAL;
        public YorumService(IYorumDAL iYorumDAL)
        {
            this.yorumDAL = iYorumDAL;
        }
        public void Delete(Yorum entity)
        {
            yorumDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            Yorum yorum = yorumDAL.Get(a=>a.ID==entityID);
            yorumDAL.Remove(yorum);
        }

        public Yorum Get(int entityID)
        {
            return yorumDAL.Get(a=>a.ID==entityID);
        }

        public ICollection<Yorum> GetAll()
        {
            return yorumDAL.GetAll();
        }

        public void Insert(Yorum entity)
        {
            yorumDAL.Add(entity);
        }

        public void Update(Yorum entity)
        {
            yorumDAL.Update(entity);
        }
    }
}
