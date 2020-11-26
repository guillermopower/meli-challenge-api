[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(meli_challenge_api.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(meli_challenge_api.App_Start.NinjectWebCommon), "Stop")]

namespace meli_challenge_api.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using meli_challenge_business;
    using meli_challenge_dal;
    using meli_challenge_entities;

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
                System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = new Ninject.WebApi.DependencyResolver.NinjectDependencyResolver(kernel);

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
            kernel.Bind<IStatsBusiness>().To<StatsBusiness>();
            kernel.Bind<IMutantBusiness>().To<MutantBusiness>();

            kernel.Bind<IStatsDAL>().To<StatsDAL>();
            kernel.Bind<IMutantDAL>().To<MutantDAL>();
            
            kernel.Bind<IStatsServiceResponse>().To<StatsServiceResponse>();
            kernel.Bind<IMutantServiceRequest>().To<MutantServiceRequest>();
            kernel.Bind<IPersonas>().To<Personas>();
        }
    }
}
