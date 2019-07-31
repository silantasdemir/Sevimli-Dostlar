using HayvanDostu.Core.DAL.EntityFramework;
using HayvanDostu.DAL.Abstract;
using HayvanDostu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HayvanDostu.DAL.Concreate
{
    public class HizmetRepository:EFRepositoryBase<Hizmet,HayvanDostuDbContext>,IHizmetDAL
    {

    }
}
