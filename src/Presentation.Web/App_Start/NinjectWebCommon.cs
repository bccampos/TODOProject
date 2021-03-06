using System.Web.Http;
using Presentation.Web.Services;

[assembly: WebActivator.PreApplicationStartMethod(typeof(Presentation.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(Presentation.Web.App_Start.NinjectWebCommon), "Stop")]

namespace Presentation.Web.App_Start
{
    using System;
    using System.Web;
    using Core;
    using Core.Interface;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Repository;
    using Repository.Interfaces;

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
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            
            RegisterServices(kernel);

            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);

            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
           // kernel.Load(new NHibernateModule());
            //kernel.Load(new MigrationsModule());

            kernel.Bind<IDbContext>().ToConstant(new DbContext());

            kernel.Bind<IUserRepository>().To<UserRepository>(); 
            kernel.Bind<ITodoListRepository>().To<TodoListRepository>(); 
            kernel.Bind<ITodoRepository>().To<TodoRepository>();
            kernel.Bind<IUserTaskService>().To<UserTaskService>(); 

            kernel.Bind<IAuthenticationService>().To<AuthenticationService>();
        }        
    }
}
