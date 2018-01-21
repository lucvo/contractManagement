

namespace ContractorMgrt.Wpf.ViewModels
{
    using Caliburn.Micro;
    using ContractorMgrt.DataAccess;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class FriendDetailViewModel : 
        Screen, 
        IDetailViewModel
    {
        IFriendRepository friendRepository;

        string firstName;
        string email;
        string lastName;

        public FriendDetailViewModel(IFriendRepository friendRepository)
        {
            this.friendRepository = friendRepository;
        }
        public int Id { get; private set; }

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
        public void Load(int id)
        {
            Id = id;
            var friend = friendRepository.GetById(id);
            if(friend != null)
            {
                FirstName = friend.FirstName;
                LastName = friend.LastName;
                Email = friend.Email;
            }
        }
    }
}
