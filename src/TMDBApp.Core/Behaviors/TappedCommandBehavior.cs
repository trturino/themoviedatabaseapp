using System;
using System.Windows.Input;
using TMDBApp.Core.Models;
using Xamarin.Forms;

namespace TMDBApp.Core.Behaviors
{
    public class TappedCommandBehavior : Behavior<ListView>
    {
        public static readonly BindableProperty CommandProperty =
            BindableProperty.CreateAttached("LoadMoreCommand", typeof(ICommand), typeof(TappedCommandBehavior), null);

        private ListView _associatedListView;

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);

            _associatedListView = bindable;

            bindable.BindingContextChanged += OnListViewBindingContextChanged;
            bindable.ItemTapped += BindableOnItemTapped;

            BindingContext = _associatedListView.BindingContext;
        }

        private void BindableOnItemTapped(object sender, ItemTappedEventArgs itemTappedEventArgs)
        {
            if (Command != null && Command.CanExecute(null))
                Command.Execute(itemTappedEventArgs.Item);
        }

        protected override void OnDetachingFrom(ListView bindable)
        {
            bindable.BindingContextChanged -= OnListViewBindingContextChanged;

            base.OnDetachingFrom(bindable);
        }

        private void OnListViewBindingContextChanged(object sender, EventArgs e)
        {
            BindingContext = _associatedListView.BindingContext;
        }
    }
}