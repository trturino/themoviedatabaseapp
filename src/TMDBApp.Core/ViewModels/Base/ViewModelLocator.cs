using System;
using System.Globalization;
using System.Reflection;
using TMDBApp.Core.Services.Dialog;
using TMDBApp.Core.Services.Genres;
using TMDBApp.Core.Services.Movies;
using TMDBApp.Core.Services.Navigation;
using TMDBApp.Core.Services.RequestsProvider;
using TMDBApp.Core.Services.Settings;
using TMDBApp.Core.TinyIoC;
using Xamarin.Forms;

namespace TMDBApp.Core.ViewModels.Base
{
    public class ViewModelLocator
    {
        private static TinyIoCContainer _container;

        public static readonly BindableProperty AutoWireViewModelProperty =
            BindableProperty.CreateAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), default(bool), propertyChanged: OnAutoWireViewModelChanged);

        public static bool GetAutoWireViewModel(BindableObject bindable)
        {
            return (bool)bindable.GetValue(ViewModelLocator.AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(BindableObject bindable, bool value)
        {
            bindable.SetValue(ViewModelLocator.AutoWireViewModelProperty, value);
        }

        public static T Resolve<T>() where T : class
        {
            return _container.Resolve<T>();
        }

        private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as Element;
            if (view == null)
            {
                return;
            }

            var viewType = view.GetType();
            var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}Model, {1}", viewName, viewAssemblyName);

            var viewModelType = Type.GetType(viewModelName);
            if (viewModelType == null)
            {
                return;
            }
            var viewModel = _container.Resolve(viewModelType);
            view.BindingContext = viewModel;
        }

        static ViewModelLocator()
        {
            _container = new TinyIoCContainer();

            _container.Register<MovieDetailsViewModel>();
            _container.Register<MovieListViewModel>();

            _container.Register<INavigationService, NavigationService>();
            _container.Register<IDialogService, DialogService>();
            _container.Register<IMovieService, MovieService>();
            _container.Register<IGenreService, GenreService>();
            _container.Register<IRequestProvider, RequestProvider>();
            _container.Register<ISettingsService, SettingsService>();
        }
    }
}
