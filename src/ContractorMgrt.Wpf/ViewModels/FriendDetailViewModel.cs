

namespace ContractorMgrt.Wpf.ViewModels
{
    using Caliburn.Micro;
    using ContractorMgrt.DataAccess;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ContractorMgrt.Wpf.Views.Services;
    using ContractorMgrt.Models;
    using System.Windows.Input;

    public class FriendDetailViewModel :
        DetailViewModelBase,
        IDetailViewModel
    {
        IFriendRepository friendRepository;

        string firstName;
        string email;
        string lastName;

        public FriendDetailViewModel(IEventAggregator eventAggregator, IMessageDialogService messageDialogService, IFriendRepository friendRepository) : base(eventAggregator, messageDialogService)
        {
            this.friendRepository = friendRepository;
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                Set(ref firstName, value);
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                Set(ref lastName, value);
            }
        }
        public string Email
        {
            get { return email; }
            set
            {
                Set(ref email, value);
            }
        }

        public override bool CanExecuteChanged { get { return true; } }

        public override Task LoadAsync(int id)
        {
            throw new NotImplementedException();
        }
        public override void Load(int id) { 
            var friend = id > 0 
                ? friendRepository.GetById(id) 
                : CreateNewFriend();

            Id = id;
            if (friend != null)
            {
                FirstName = friend.FirstName;
                LastName = friend.LastName;
                Email = friend.Email;
            }
            SetTitle();
            MessageDialogService.ShowInfoDialog($"{id}");
        }
        private void SetTitle()
        {
            Title = $"{FirstName} {LastName}";
        }
        private FriendPhoneNumber _selectedPhoneNumber;

        public FriendPhoneNumber SelectedPhoneNumber
        {
            get { return _selectedPhoneNumber; }
            set
            {
                Set(ref _selectedPhoneNumber, value);
                NotifyOfPropertyChange(() => CanExecuteChanged);
            }
        }

        public ICommand AddPhoneNumberCommand { get; }

        public ICommand RemovePhoneNumberCommand { get; }


        public BindableCollection<FriendPhoneNumber> PhoneNumbers { get; }
        private Friend CreateNewFriend()
        {
            var friend = new Friend();
            return friend;
        }
    }
}
