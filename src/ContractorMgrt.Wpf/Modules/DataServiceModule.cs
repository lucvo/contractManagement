using Autofac;
using ContractorMgrt.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractorMgrt.Wpf.Modules
{
    public class DataServiceModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
              .RegisterType<LookupDataService>()
              .As<IFriendLookupService>()
              .InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
