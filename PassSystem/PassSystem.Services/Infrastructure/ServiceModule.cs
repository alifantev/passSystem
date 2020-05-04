using Autofac;
using PassSystem.Repositories.EmployeePasses;

namespace PassSystem.Services.Infrastructure
{
    public class ServiceModule : Module
    {
        private readonly string _connectionString;

        public ServiceModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EmployeePassRepository>().As<IEmployeePassRepository>()
                .WithParameter("connectionString", _connectionString).InstancePerDependency();
        }
    }
}
