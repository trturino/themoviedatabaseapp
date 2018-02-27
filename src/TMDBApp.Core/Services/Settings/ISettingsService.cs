namespace TMDBApp.Core.Services.Settings
{
    public interface ISettingsService
    {
        string UrlBase { get; }

        string ApiKey { get; }
    }
}
