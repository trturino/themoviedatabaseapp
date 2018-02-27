using System.Threading.Tasks;

namespace TMDBApp.Core.Services.Dialog
{
    public class DialogService : IDialogService
    {
        public Task ShowAlertAsync(string message, string title, string buttonLabel)
        {
            return Task.CompletedTask;
        }
    }
}
