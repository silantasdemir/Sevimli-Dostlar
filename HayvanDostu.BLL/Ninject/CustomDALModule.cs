using HayvanDostu.DAL.Abstract;
using HayvanDostu.DAL.Concreate;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HayvanDostu.BLL.Ninject
{
    public class CustomDALModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IBireyselUyeDAL>().To<BireyselUyeRepository>();
            Bind<IKurumsalUyeDAL>().To<KurumsalUyeRepository>();
            Bind<ICizelgeDAL>().To<CizelgeRepository>();
            Bind<IHayvanDAL>().To<HayvanRepository>();
            Bind<IHayvanCinsiDAL>().To<HayvanCinsiRepository>();
            Bind<IHayvanTuruDAL>().To<HayvanTuruRepository>();
            Bind<IHizmetDAL>().To<HizmetRepository>();
            Bind<IKonaklamaDAL>().To<KonaklamaRepository>();
            Bind<IKonaklamaRezervasyonDAL>().To<KonaklamaRezervasyonRepository>();
            Bind<IRezervasyonDAL>().To<RezervasyonRepository>();
            Bind<IOdemeDAL>().To<OdemeRepository>();
            Bind<IPuanDAL>().To<PuanRepository>();
            Bind<IYorumDAL>().To<YorumRepository>();
            Bind<IVeterinerDAL>().To<VeterinerRepository>();
            Bind<IAdminDAL>().To<AdminRepository>();


        }
    }
}
