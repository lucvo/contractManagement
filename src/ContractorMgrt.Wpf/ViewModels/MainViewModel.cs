

namespace ContractorMgrt.Wpf.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Caliburn.Micro;
    using System.ComponentModel.Composition;
    using ContractorMgrt.Wpf.Events;
    using Autofac.Features.Indexed;

    [Export(typeof(IShell))]
    public class MainViewModel :
        ViewModelBase,
        IShell,
        IHandle<OpenDetailViewEventArgs>
    {
        private IDetailViewModel selectedDetailViewModel;
        private IIndex<string, IDetailViewModel> detailViewModelCreator;

        public MainViewModel(
            INavigationViewModel navigationViewModel,
            IIndex<string, IDetailViewModel> detailViewModelCreator,
            IEventAggregator eventAggregator,
            IWindowManager windowManager)
            : base(eventAggregator, windowManager)
        {
            NavigationViewModel = navigationViewModel;
            this.detailViewModelCreator = detailViewModelCreator;
            EventAggregator.Subscribe(this);
        }
        public INavigationViewModel NavigationViewModel { get; }
        public IDetailViewModel SelectedDetailViewModel
        {
            get { return selectedDetailViewModel; }
            set
            {
                Set(ref selectedDetailViewModel, value);
            }
        }

        public void Handle(OpenDetailViewEventArgs args)
        {
            var detailViewModel = detailViewModelCreator[args.ViewModelName];
            detailViewModel.Load(args.Id);
            SelectedDetailViewModel = detailViewModel;
        }

        public void OnLoaded()
        {
            NavigationViewModel.Loaded();
        }
    }
}
