using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Main.ViewModels;

namespace Main.Command
{
    public class ButtonCommand : ICommand
    {
        private Action<object> handler;
        public ButtonCommand(Action<object> commandHandler)
        {
            handler = commandHandler;
        }
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            handler(parameter);
        }
    }
}