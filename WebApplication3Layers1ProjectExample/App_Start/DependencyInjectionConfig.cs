using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using WebApplication3Layers1ProjectExample.Application.BusinessLogicLayer.Interfaces;
using WebApplication3Layers1ProjectExample.Application.BusinessLogicLayer.Services;
using WebApplication3Layers1ProjectExample.Application.DataAccessLayer.Interfaces;
using WebApplication3Layers1ProjectExample.Application.DataAccessLayer.Services;

namespace WebApplication3Layers1ProjectExample
{
    public class DependencyInjectionConfig
    {
        public static void RegisterDependencies()
        {
            // Register MVC-related dependencies
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            builder.RegisterModule<AutofacWebTypesModule>();

            // Register business service
            builder.RegisterType<EmployeeService>().As<IEmployeeService>().InstancePerHttpRequest();
            builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerHttpRequest();

            // Register bata access service
            builder.RegisterType<DataAccessService>().As<IDataAccessService>().InstancePerDependency();


            builder.RegisterModelBinderProvider();

            // Set the MVC dependency resolver to use Autofac
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
