

namespace ContractorMgrt.Wpf.ViewModels
{
    using Caliburn.Micro;
    using ContractorMgrt.Wpf.Events;
    using Data.Command;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;

    public class NavigationItemViewModel : 
        Screen
    {
        private string detailViewModelName;
        private readonly IEventAggregator eventAggregator;

        public NavigationItemViewModel(
            int id,
            string displayMember,
            string detailViewModelName,
            IEventAggregator eventAggregator
          )
        {
            Id = id;
            DisplayMember = displayMember;
            this.detailViewModelName = detailViewModelName;
            this.eventAggregator = eventAggregator;
            
        }

        public int Id { get; }

        private string displayMember;
        public string DisplayMember
        {
            get { return displayMember; }
            set { Set(ref displayMember, value); }
        }

        public void OpenDetailView()
        {
            eventAggregator.PublishOnUIThread(
              new OpenDetailViewEventArgs
              {
                  Id = Id,
                  ViewModelName = detailViewModelName
              });
        }
    }
}
