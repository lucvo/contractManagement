using Caliburn.Micro;
using ContractorMgrt.Wpf.Events;
using ContractorMgrt.Wpf.Views.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ContractorMgrt.Wpf.ViewModels
{
    public abstract class DetailViewModelBase : Screen, IDetailViewModel
    {
        private bool _hasChanges;
        protected readonly IMessageDialogService MessageDialogService;
        protected readonly IEventAggregator EventAggregator;
        private int _id;
        private string _title;

        public DetailViewModelBase(IEventAggregator eventAggregator,
          IMessageDialogService messageDialogService)
        {
            MessageDialogService = messageDialogService;
            EventAggregator = eventAggregator;
            EventAggregator.Subscribe(this);
        }

        public abstract Task LoadAsync(int id);
        public abstract void Load(int id);

        public ICommand SaveCommand { get; private set; }

        public ICommand DeleteCommand { get; private set; }

        public ICommand CloseDetailViewCommand { get; }

        public int Id
        {
            get { return _id; }
            protected set { _id = value; }
        }

        public string Title
        {
            get { return _title; }
            protected set
            {
                Set(ref _title, value);
            }
        }

        public bool HasChanges
        {
            get { return _hasChanges; }
            set
            {
                if (_hasChanges != value)
                {
                    Set(ref _hasChanges, value);
                    NotifyOfPropertyChange(() => CanExecuteChanged);
                }
            }
        }
        public abstract bool CanExecuteChanged { get; }

        //protected abstract void OnDeleteExecute();

        //protected abstract bool OnSaveCanExecute();

        //protected abstract void OnSaveExecute();

        protected virtual void RaiseDetailDeletedEvent(int modelId)
        {
            EventAggregator.PublishOnUIThread(new AfterDetailDeletedEventArgs
            {
                Id = modelId,
                ViewModelName = this.GetType().Name
            });
        }

        protected virtual void RaiseDetailSavedEvent(int modelId, string displayMember)
        {
            EventAggregator.PublishOnUIThread(new AfterDetailSavedEventArgs
            {
                Id = modelId,
                DisplayMember = displayMember,
                ViewModelName = this.GetType().Name
            });
        }

        protected virtual void RaiseCollectionSavedEvent()
        {
            EventAggregator.BeginPublishOnUIThread(new AfterCollectionSavedEventArgs
              {
                  ViewModelName = this.GetType().Name
              });
        }

        protected virtual void OnCloseDetailViewExecute()
        {
            if (HasChanges)
            {
                var result = MessageDialogService.ShowOkCancelDialog(
                  "You've made changes. Close this item?", "Question");
                if (result == MessageDialogResult.Cancel)
                {
                    return;
                }
            }

            EventAggregator.BeginPublishOnUIThread(new AfterDetailClosedEventArgs
              {
                  Id = this.Id,
                  ViewModelName = this.GetType().Name
              });
        }

        protected async Task SaveWithOptimisticConcurrencyAsync(Func<Task> saveFunc,
          System.Action afterSaveAction)
        {
            await saveFunc();

            //try
            //{
            //    await saveFunc();
            //}
            //catch (DbUpdateConcurrencyException ex)
            //{
            //    var databaseValues = ex.Entries.Single().GetDatabaseValues();
            //    if (databaseValues == null)
            //    {
            //        MessageDialogService.ShowInfoDialog("The entity has been deleted by another user");
            //        RaiseDetailDeletedEvent(Id);
            //        return;
            //    }

            //    var result = MessageDialogService.ShowOkCancelDialog("The entity has been changed in "
            //     + "the meantime by someone else. Click OK to save your changes anyway, click Cancel "
            //     + "to reload the entity from the database.", "Question");

            //    if (result == MessageDialogResult.OK)
            //    {
            //        // Update the original values with database-values
            //        var entry = ex.Entries.Single();
            //        entry.OriginalValues.SetValues(entry.GetDatabaseValues());
            //        await saveFunc();
            //    }
            //    else
            //    {
            //        // Reload entity from database
            //        await ex.Entries.Single().ReloadAsync();
            //        await LoadAsync(Id);
            //    }
            //};

            afterSaveAction();
        }

    }
}
