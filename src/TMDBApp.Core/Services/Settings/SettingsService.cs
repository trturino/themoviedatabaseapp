namespace TMDBApp.Core.Services.Settings
{
    public class SettingsService : ISettingsService
    {
        public string UrlBase => GlobalSetting.BackendUrl;
        public string ApiKey => GlobalSetting.ApiKey;
    }
}
