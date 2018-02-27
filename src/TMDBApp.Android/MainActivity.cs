using Android.App;
using Android.Content.PM;
using Android.OS;
using FFImageLoading.Forms.Droid;
using TMDBApp.Core;

namespace TMDBApp.Droid
{
    [Activity(Label = "TMDBApp", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            SupportActionBar.SetDisplayShowHomeEnabled(true);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowCustomEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(false);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            CachedImageRenderer.Init(false);

            LoadApplication(new App());
        }
    }
}