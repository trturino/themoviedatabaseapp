using Xamarin.Forms;

namespace TMDBApp.Core.Views
{
    public partial class NavigationView : NavigationPage
    {
        public NavigationView() : base()
        {
            InitializeComponent();
        }

        public NavigationView(Page root) : base(root)
        {
            InitializeComponent();
        }
    }
}
