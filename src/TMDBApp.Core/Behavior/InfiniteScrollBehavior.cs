using System;
using System.Collections;
using System.Windows.Input;
using Xamarin.Forms;

namespace TMDBApp.Core.Behavior
{
    public class InfiniteScrollBehavior : Behavior<ListView>
    {
        public static readonly BindableProperty LoadMoreCommandProperty =
            BindableProperty.Create(
                nameof(LoadMoreCommand),
                typeof(bool),
                typeof(InfiniteScrollBehavior),
                default(bool),
                BindingMode.OneWayToSource);

        private ListView _associatedListView;

        public ICommand LoadMoreCommand
        {
            get => (ICommand)GetValue(LoadMoreCommandProperty);
            private set => SetValue(LoadMoreCommandProperty, value);
        }

        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);

            _associatedListView = bindable;

            bindable.BindingContextChanged += OnListViewBindingContextChanged;
            bindable.ItemAppearing += OnListViewItemAppearing;

            BindingContext = _associatedListView.BindingContext;
        }

        protected override void OnDetachingFrom(ListView bindable)
        {
            bindable.BindingContextChanged -= OnListViewBindingContextChanged;
            bindable.ItemAppearing -= OnListViewItemAppearing;

            base.OnDetachingFrom(bindable);
        }

        private void OnListViewItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            if (!ShouldLoadMore(e.Item)) return;

            if (LoadMoreCommand != null && LoadMoreCommand.CanExecute(null)) LoadMoreCommand.Execute(null);
        }

        private void OnListViewBindingContextChanged(object sender, EventArgs e)
        {
            BindingContext = _associatedListView.BindingContext;
        }

        private bool ShouldLoadMore(object item)
        {
            if (_associatedListView.ItemsSource is IList list)
            {
                if (list.Count == 0)
                    return true;
                var lastItem = list[list.Count - 1];
                if (_associatedListView.IsGroupingEnabled && lastItem is IList group)
                    return group.Count == 0 || group[group.Count - 1] == item;
                else
                    return lastItem == item;
            }
            return false;
        }
    }
}