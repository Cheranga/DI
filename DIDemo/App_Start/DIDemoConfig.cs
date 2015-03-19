using System.Web.Http;
using DIDemo.Infrastructure;
using Ninject;

namespace DIDemo
{
    public static class DIDemoConfig
    {
        public static void Register(IKernel kernel)
        {
            var appDependencyResolver = new AppDependencyResolver(kernel);
            GlobalConfiguration.Configuration.DependencyResolver = appDependencyResolver;
        }
    }
}