using Foundation;
using UIKit;
using Xunit.Runner;
using Xunit.Sdk;

namespace TMDBApp.TestRunner.iOS
{
    [Register("UnitTestAppDelegate")]
    public partial class UnitTestAppDelegate : RunnerAppDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            AddExecutionAssembly(typeof(ExtensibilityPointFactory).Assembly);
            AddTestAssembly(typeof(UnitTests.Services.GenreServiceTests).Assembly);

            return base.FinishedLaunching(app, options);
        }
    }
}
