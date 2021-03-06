﻿using System.Threading.Tasks;
using TMDBApp.Core.ViewModels.Base;

namespace TMDBApp.Core.Services.Navigation
{
    public interface INavigationService
    {
        ViewModelBase PreviousPageViewModel { get; }

        Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase;

        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase;

        Task RemoveLastFromBackStackAsync();

        Task RemoveBackStackAsync();
    }
}
