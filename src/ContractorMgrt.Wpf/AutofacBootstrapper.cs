using Autofac;
using Caliburn.Micro;
using Caliburn.Micro.Autofac;
using ContractorMgrt.Wpf.ViewModels;
using ContractorMgrt.Wpf.Views.Services;
using System.Windows;
namespace ContractorMgrt.Wpf
{
    public class AutofacBootstrapper : AutofacBootstrapper<MainViewModel>
    {
        public AutofacBootstrapper()
        {
            Initialize();
        }

        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            SimpleContainer container = new SimpleContainer();
            builder.RegisterAssemblyModules(typeof(IShell).Assembly);

            builder.
                RegisterType<NavigationViewModel>()
                .InstancePerLifetimeScope()
                .As<INavigationViewModel>();
            builder
                .RegisterType<FriendDetailViewModel>()
                .Keyed<IDetailViewModel>(nameof(FriendDetailViewModel));
            builder
                .RegisterType<MessageDialogService>()
                .As<IMessageDialogService>();
            builder.RegisterInstance(container);
        }

        protected override void ConfigureBootstrapper()
        {
            base.ConfigureBootstrapper();
            EnforceNamespaceConvention = false;
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainViewModel>();
        }
    }
}
