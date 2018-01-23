

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
    using ContractorMgrt.Wpf.Views.Services;

    [Export(typeof(IShell))]
    public class MainViewModel :
        ViewModelBase,
        IShell,
        IHandle<OpenDetailViewEventArgs>
    {
        private IDetailViewModel selectedDetailViewModel;
        private IIndex<string, IDetailViewModel> detailViewModelCreator;
        private IMessageDialogService messageDialogService;

        public MainViewModel(
            INavigationViewModel navigationViewModel,
            IIndex<string, IDetailViewModel> detailViewModelCreator,
            IMessageDialogService messageDialogService,
            IEventAggregator eventAggregator,
            IWindowManager windowManager)
            : base(eventAggregator, windowManager)
        {
            this.detailViewModelCreator = detailViewModelCreator;
            this.messageDialogService = messageDialogService;

            NavigationViewModel = navigationViewModel;

            DetailViewModels = new BindableCollection<IDetailViewModel>();
        }
        public BindableCollection<IDetailViewModel> DetailViewModels { get; }
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
            var detailViewModel = DetailViewModels.SingleOrDefault(vm => vm.Id == args.Id && vm.GetType().Name == args.ViewModelName);

            if (detailViewModel == null)
            {
                detailViewModel = detailViewModelCreator[args.ViewModelName];
                try
                {
                    detailViewModel.Load(args.Id);
                }
                catch(Exception ex)
                {
                    messageDialogService.ShowOkCancelDialog(ex.Message, "Error");
                    NavigationViewModel.Load();
                    return;
                }

                DetailViewModels.Add(detailViewModel);
            }

            SelectedDetailViewModel = detailViewModel;
        }

        public void OnLoaded()
        {
            NavigationViewModel.Load();
        }

        public void Exit()
        {
            Environment.Exit(0);
        }
    }
}
