using System;
using System.ComponentModel;
using System.Windows;
using ManagedHelpers.Interfaces;

namespace NewtonIntegrator.Interfaces
{
    public abstract class DocumentViewModel<T> : DocumentViewModel where T : FrameworkElement
    {
        private T view;

        public new virtual T View
        {
            get { return view; }
            set
            {
                if (view != null)
                {
                    view.Loaded -= OnLoadedInternal;
                }
                view = value;
                base.View = value;
                OnViewSet();
                if (view != null)
                {
                    view.DataContext = this;
                    view.Loaded += OnLoadedInternal;
                }
            }
        }

        protected virtual void CloseWindow(bool? dialogResult = false)
        {
            var window = Window.GetWindow(View);
            if (window != null)
            {
                window.DialogResult = dialogResult;
                window.Close();
            }
        }

        protected virtual void OnLoaded(object sender, RoutedEventArgs e)
        {

        }

        private void OnLoadedInternal(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(View);
            if (window != null)
            {
                window.Closed -= OnWindowClosed;
                window.Closed += OnWindowClosed;
                window.Closing -= OnWindowClosing;
                window.Closing += OnWindowClosing;
            }
            OnLoaded(sender, e);
        }

        protected virtual void OnWindowClosing(object sender, CancelEventArgs e)
        {
        }

        protected virtual void OnWindowClosed(object sender, EventArgs e)
        {
        }

        protected virtual void OnViewSet()
        {
        }

        public void ShowWindow()
        {
            var window = new Window();
            window.Content = View;
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.SizeToContent = SizeToContent.WidthAndHeight;
            window.Show();
        }
    }
}
