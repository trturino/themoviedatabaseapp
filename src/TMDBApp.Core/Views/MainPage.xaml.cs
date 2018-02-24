
using TMDBApp.Core.ViewModels;

namespace TMDBApp.Core.Views
{
	public partial class MainPage
	{
	    protected MovieListViewModel MovieListViewModel => MovieListView.BindingContext as MovieListViewModel;


        public MainPage()
		{
			InitializeComponent();
		}

	    protected async override void OnAppearing()
	    {
	        base.OnAppearing();

	        await MovieListViewModel.InitializeAsync(null);
	    }
	}
}
