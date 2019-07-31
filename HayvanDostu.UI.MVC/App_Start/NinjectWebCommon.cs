[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(HayvanDostu.UI.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(HayvanDostu.UI.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace HayvanDostu.UI.MVC.App_Start
{
    using System;
    using System.Web;
    using HayvanDostu.BLL.Abstract;
    using HayvanDostu.BLL.Concreate;
    using HayvanDostu.BLL.Ninject;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IBireyselUyeService>().To<BireyselUyeService>();
            kernel.Bind<IKurumsalUyeService>().To<KurumsalUyeService>();
            kernel.Bind<ICizelgeService>().To<CizelgeService>();
            kernel.Bind<IHayvanService>().To<HayvanService>();
            kernel.Bind<IHayvanCinsiService>().To<HayvanCinsiService>();
            kernel.Bind<IHayvanTuruService>().To<HayvanTuruService>();
            kernel.Bind<IHizmetService>().To<HizmetService>();
            kernel.Bind<IKonaklamaService>().To<KonaklamaService>();
            kernel.Bind<IKonaklamaRezervasyonService>().To<KonaklamaRezervasyonService>();
            kernel.Bind<IRezervasyonService>().To<RezervasyonService>();
            kernel.Bind<IOdemeService>().To<OdemeService>();
            kernel.Bind<IPuanService>().To<PuanService>();
            kernel.Bind<IYorumService>().To<YorumService>();
            kernel.Bind<IVeterinerService>().To<VeterinerService>();
            kernel.Bind<IAdminService>().To<AdminService>();

            kernel.Load<CustomDALModule>();

        }
    }
}
