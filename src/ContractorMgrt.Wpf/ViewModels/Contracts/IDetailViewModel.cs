using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractorMgrt.Wpf.ViewModels
{
    public interface IDetailViewModel
    {
        Task LoadAsync(int id);
        void Load(int id);
        bool HasChanges { get; }
        int Id { get; }
    }
}
