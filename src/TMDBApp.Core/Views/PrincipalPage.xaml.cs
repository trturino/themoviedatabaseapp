
using TMDBApp.Core.ViewModels;

namespace TMDBApp.Core.Views
{
	public partial class PrincipalPage
    {
	    protected MovieListViewModel MovieListViewModel => MovieListView.BindingContext as MovieListViewModel;


        public PrincipalPage()
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
