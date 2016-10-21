using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Session_Timer {
    public class Command : ICommand {
        readonly Action<object> execute;
        readonly Predicate<object> canExecute;

        public Command(Action<object> execute) : this(execute, null) { }
        public Command(Action<object> execute, Predicate<object> canExecute) {
            this.execute = execute;
            this.canExecute = canExecute;
        }
        public Command(Action execute) {
            this.execute = (object p) => execute();
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) {
            if (canExecute != null) {
                return canExecute(parameter);
            } else return true;
        }

        public void Execute(object parameter) {
            execute(parameter);
        }
    }
}
