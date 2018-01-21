using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractorMgrt.Wpf.ViewModels
{
    public interface IDetailViewModel
    {
        void Load(int id);
        int Id { get; }
    }
}
