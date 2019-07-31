using HayvanDostu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HayvanDostu.BLL.Abstract
{
    public interface IKurumsalUyeService : IBaseService<KurumsalUye>
    {
        KurumsalUye GetUserByLogin(string UserName, string password);
        ICollection<KurumsalUye> GetAll(bool durum);
        KurumsalUye GetMail(string mail);
        KurumsalUye GetUploadPhoto(KurumsalUye kurumsalUye, HttpPostedFileBase file);

    }
}
