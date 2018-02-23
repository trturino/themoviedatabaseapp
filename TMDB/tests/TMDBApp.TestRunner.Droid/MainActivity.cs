using Android.App;
using Android.OS;
using Xunit.Runners.UI;
using Xunit.Sdk;

namespace TMDBApp.TestRunner.Droid
{
    [Activity(Label = "TMDBApp.TestRunner.Droid", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : RunnerActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            AddExecutionAssembly(typeof(ExtensibilityPointFactory).Assembly);

            AddTestAssembly(typeof(UnitTests.Services.GenreServiceTests).Assembly);

            base.OnCreate(savedInstanceState);
        }
    }
}