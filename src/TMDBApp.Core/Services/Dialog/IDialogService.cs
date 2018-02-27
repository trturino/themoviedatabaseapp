using System.Threading.Tasks;

namespace TMDBApp.Core.Services.Dialog
{
    public interface IDialogService
    {
        Task ShowAlertAsync(string message, string title, string buttonLabel);
    }
}
