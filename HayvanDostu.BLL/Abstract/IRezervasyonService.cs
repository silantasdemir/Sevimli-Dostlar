using HayvanDostu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HayvanDostu.BLL.Abstract
{
    public interface IRezervasyonService : IBaseService<Rezervasyon>
    {
        ICollection<Rezervasyon> GetAllByKurumId(int id);
    }
}
