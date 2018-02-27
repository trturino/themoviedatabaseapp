using TMDBApp.Core.Views;
using TMDBApp.Core.Views.Templates;
using Xamarin.Forms;

namespace TMDBApp.Core
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

			MainPage = new NavigationView(new PrincipalPage());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
