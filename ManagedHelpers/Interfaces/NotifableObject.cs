using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;

namespace ManagedHelpers.Interfaces
{
    public class NotifableObject : DependencyObject, INotifyPropertyChanged
    {

        public void ExecuteOnOwnThread(Action action)
        {
            var dispatcher = Dispatcher;
            if (dispatcher.CheckAccess())
            {
                action();
            }
            else
            {
                dispatcher.Invoke(action);
            }
        }

        public void ExecuteOnOwnThreadOrAsync(Action action)
        {
            var dispatcher = Dispatcher;
            if (dispatcher.CheckAccess())
            {
                action();
            }
            else
            {
                dispatcher.BeginInvoke(action);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        public void VerifyPropertyName(string propertyName)
        {
            if (DebugDefines.UsePropertyNamesVerification)
            {
                if (TypeDescriptor.GetProperties(this)[propertyName] == null)
                {
                    string msg = "Invalid property name: " + propertyName;
                    Debug.Fail(msg);
                }
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            VerifyPropertyName(propertyName);

            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}