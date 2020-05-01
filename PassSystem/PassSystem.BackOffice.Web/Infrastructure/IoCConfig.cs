using System.Configuration;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using PassSystem.Domain.Services;
using PassSystem.Services.EmployeePass;
using PassSystem.Services.Infrastructure;

namespace PassSystem.BackOffice.Web.Infrastructure
{
    public static class IoCConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly).InstancePerRequest();
            builder.RegisterAssemblyModules(typeof(MvcApplication).Assembly);
            builder.RegisterModule<AutofacWebTypesModule>();
            builder.RegisterFilterProvider();
            
            builder.RegisterModule(new ServiceModule(ConfigurationManager.ConnectionStrings["PassSystemStorage"].ToString()));
            
            RegisterServices(builder);
            
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
        
        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<EmployeePassService>().As<IEmployeePassService>();
        }
    }
}