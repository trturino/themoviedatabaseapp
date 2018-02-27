using FFImageLoading.Forms.Touch;
using Foundation;
using TMDBApp.Core;
using UIKit;

namespace TMDBApp.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            CachedImageRenderer.Init();

            return base.FinishedLaunching(app, options);
        }
    }
}