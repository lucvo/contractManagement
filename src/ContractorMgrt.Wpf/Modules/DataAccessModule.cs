

namespace ContractorMgrt.DataAccess
{
    using Autofac;
    using Data;
    using Infrastructure.Contracts;
    using System.Configuration;
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var connectionString = ConfigurationManager
                .ConnectionStrings["ContractorDb"]
                .ConnectionString;
            
            builder
               .RegisterInstance(connectionString)
               .SingleInstance();
            builder
                .RegisterType<DbContext>()
                .InstancePerLifetimeScope()
                .As<IDbContext>();
            builder
               .RegisterType<ContractorDbFactory>()
               .As<IDatabase>()
               .InstancePerLifetimeScope();
            builder.RegisterType<FriendRepository>()
                .As<IFriendRepository>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
