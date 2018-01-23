
/// <summary>
/// https://app.pluralsight.com/library/courses/wpf-mvvm-entity-framework-app
/// </summary>
namespace ContractorMgrt.Wpf.Views.Services
{
    public interface IMessageDialogService
    {
        MessageDialogResult ShowOkCancelDialog(string text, string title);
        void ShowInfoDialog(string text);
    }
    public enum MessageDialogResult
    {
        OK,
        Cancel
    }
}
