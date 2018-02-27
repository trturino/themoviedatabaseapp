using Android.App;
using Android.OS;
using Xunit.Runners.UI;
using Xunit.Sdk;

namespace TMDBApp.TestRunner.Android
{
    [Activity(Label = "TMDBApp.TestRunner.Android", MainLauncher = true)]
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

