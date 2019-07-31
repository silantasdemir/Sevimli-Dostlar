using HayvanDostu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HayvanDostu.BLL.Abstract
{
    public interface IBireyselUyeService : IBaseService<BireyselUye>
    {
        BireyselUye GetUserByLogin(string UserName, string password);
        ICollection<BireyselUye> GetAll(bool durum);
        BireyselUye GetMail(string mail);

        BireyselUye GetUploadPhoto(BireyselUye bireyselUye, HttpPostedFileBase file);

    }
}