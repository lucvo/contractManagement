

namespace ContractorMgrt.Wpf.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Caliburn.Micro;
    using ContractorMgrt.Business;
    using System.Collections.ObjectModel;
    public class NavigationViewModel : Screen, INavigationViewModel
    {
        private readonly IFriendLookupService friendLookupService;
        private NavigationItemViewModel selectedFriend;
        IEventAggregator eventAggregator;
        public NavigationViewModel(
            IFriendLookupService friendLookupService,
            IEventAggregator eventAggregator)
        {
            this.friendLookupService = friendLookupService;
            this.eventAggregator = eventAggregator;
            Friends = new BindableCollection<NavigationItemViewModel>();
        }
        public void Loaded()
        {
            var lookup = friendLookupService.GetFriendLookupAsync();
            Friends.Clear();
            foreach (var item in lookup)
            {
                Friends.Add(
                    new NavigationItemViewModel(
                        item.Id, 
                        item.DisplayMember,
                        nameof(FriendDetailViewModel),
                        eventAggregator));
            }
        }

        public BindableCollection<NavigationItemViewModel> Friends { get; }
        public NavigationItemViewModel SelectedFriend
        {
            get { return selectedFriend; }
            set { Set(ref selectedFriend, value); }
        }
    }
}
