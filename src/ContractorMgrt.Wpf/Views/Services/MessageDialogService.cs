
/// <summary>
/// https://app.pluralsight.com/library/courses/wpf-mvvm-entity-framework-app
/// </summary>
namespace ContractorMgrt.Wpf.Views.Services
{
    using System.Windows;
    public class MessageDialogService : IMessageDialogService
    {
        public MessageDialogResult ShowOkCancelDialog(string text, string title)
        {
            var result = MessageBox.Show(text, title, MessageBoxButton.OKCancel);
            return result == MessageBoxResult.OK
              ? MessageDialogResult.OK
              : MessageDialogResult.Cancel;
        }
        public void ShowInfoDialog(string text)
        {
            MessageBox.Show(text, "Info");
        }

    }
}
