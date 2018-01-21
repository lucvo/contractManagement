using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ContractorMgrt.Wpf.ViewModels
{
    public class ViewModelBase : PropertyChangedBase
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IWindowManager _windowManager;

        protected IWindowManager WindowManager
        {
            get { return _windowManager; }
        }

        protected IEventAggregator EventAggregator
        {
            get { return _eventAggregator; }
        }

        protected ViewModelBase()
            : this(null, null)
        {

        }

        public ViewModelBase(IEventAggregator eventAggregator)
            : this(eventAggregator, null)
        {

        }

        public ViewModelBase(IEventAggregator eventAggregator, IWindowManager windowManager)
        {
            _eventAggregator = eventAggregator;
            _windowManager = windowManager;
            if (_eventAggregator != null)
                _eventAggregator.Subscribe(this);
        }

        public string Version
        {
            get
            {
                return Properties.Resources.Version;
            }
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }

            field = value;
            NotifyOfPropertyChange(propertyName);
            return true;
        }

        public void ShowErrorMessage(string errorMessage)
        {
            MessageBox.Show("An unexpected error has occurred. Please contact your system Administrator", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
