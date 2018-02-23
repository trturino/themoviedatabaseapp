using System;
namespace TMDBApp.Services.Settings
{
    public interface ISettingsService
    {
        string UrlBase { get; }

        string ApiKey { get; }
    }
}
