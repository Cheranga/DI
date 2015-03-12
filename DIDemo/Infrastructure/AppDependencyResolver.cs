using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Ninject;
using Ninject.Syntax;
using Ninject.Web.Common;
using Ninject.Web.WebApi;

namespace DIDemo.Infrastructure
{
    public class AppDependencyResolver : NinjectDependencyScope, System.Web.Mvc.IDependencyResolver, System.Web.Http.Dependencies.IDependencyResolver
    {
        private readonly IKernel kernel;

        public AppDependencyResolver(IKernel kernel):base(kernel)
        {
            this.kernel = kernel;

            RegisterDependencies();
        }

        private void RegisterDependencies()
        {
            //
            // For the whole application there will be only one logger instance
            //
            this.kernel.Bind<ILogger>().To<Logger>().InSingletonScope();
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }
    }
}