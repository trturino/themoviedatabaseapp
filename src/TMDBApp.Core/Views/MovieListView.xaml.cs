using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TMDBApp.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieListView : ContentView
    {
        public MovieListView()
        {
            InitializeComponent();
        }
    }
}