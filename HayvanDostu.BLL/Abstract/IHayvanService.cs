using HayvanDostu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HayvanDostu.BLL.Abstract
{
    public interface IHayvanService : IBaseService<Hayvan>
    {
        Hayvan GetUploadPhoto(Hayvan hayvan, HttpPostedFileBase file);
    }
}
