using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace JoelsProjectRenameMe
{
    public static class SimpleInjectorInitializer
    {
        public static void SimpleInjectorInitalizer()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
               new SimpleInjectorWebApiDependencyResolver(container);
        }

        private static void InitializeContainer(Container container)
        {
            //container.Register<Repository.ICartRepo, Repository.MockCart>(Lifestyle.Singleton);
            container.Register<Repository.ICartRepo, Repository.CartRepo>(Lifestyle.Scoped);
        }
    }
}