using System;
using System.Windows.Input;

namespace FastLearningApp.Base
{
    public class CommandHandler : ICommand
    {
        private Action<object> execute;
        private Func<bool> canExecute;
        public CommandHandler(Action<object> execute, Func<bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return canExecute?.Invoke() ?? true;
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
