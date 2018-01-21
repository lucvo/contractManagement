

namespace ContractorMgrt.Wpf.ViewModels
{
    using Caliburn.Micro;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Controls;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;

    [Export(typeof(IShell))]
    public class ShellViewModel : PropertyChangedBase, IShell
    {
        //public ShellViewModel() { }
        private INavigationService navigationService;
        private readonly SimpleContainer container;

        public ShellViewModel(SimpleContainer container)
        {
            this.container = container;
        }

        public void RegisterFrame(Frame frame)
        {
            navigationService = new FrameAdapter(frame);

            container.Instance(navigationService);

            navigationService.NavigateToViewModel(typeof(MenuViewModel));
        }
    }
}
