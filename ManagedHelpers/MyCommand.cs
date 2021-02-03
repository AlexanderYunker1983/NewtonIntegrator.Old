using System;
using System.Windows.Input;

namespace ManagedHelpers
{
    public class MyCommand<T> : ICommand
    {
        // Fields
        private readonly Predicate<T> canExecuteMethod;
        private readonly Action<T> executeMethod;

        // Events
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public string Header { get; set; }
        public bool ParameterIsSelf { get; set; }

        // Methods

        public MyCommand(Action<T> executeMethod, Predicate<T> canExecuteMethod = null, string header = null)
        {
            Header = header;
            this.executeMethod = null;
            this.canExecuteMethod = null;
            if ((executeMethod == null) && (canExecuteMethod == null))
            {
                throw new ArgumentNullException("executeMethod");
            }
            this.executeMethod = executeMethod;
            this.canExecuteMethod = canExecuteMethod;
        }

        public bool CanExecute(T parameter)
        {
            if (ParameterIsSelf && typeof(T).IsAssignableFrom(GetType()))
            {
                parameter = (T)(object)this;
            }
            return ((canExecuteMethod == null) || canExecuteMethod(parameter));
        }

        public void Execute(T parameter)
        {
            if (ParameterIsSelf && typeof(T).IsAssignableFrom(GetType()))
            {
                parameter = (T)(object)this;
            }
            if (executeMethod != null)
            {
                executeMethod(parameter);
            }
        }

        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute(parameter.GetObjectSafeCastedAs<T>());
        }

        void ICommand.Execute(object parameter)
        {
            Execute(parameter.GetObjectSafeCastedAs<T>());
        }

    }
}