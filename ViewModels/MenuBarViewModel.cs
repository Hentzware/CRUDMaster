using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Commands;
using Prism.Mvvm;

namespace CRUDMaster.ViewModels
{
    public class MenuBarViewModel : BindableBase
    {
        private DelegateCommand _exitCommand;

        public DelegateCommand ExitCommand =>
            _exitCommand ?? new DelegateCommand(ExecuteExitCommand);

        private void ExecuteExitCommand()
        {
            Application.Current.Shutdown(0);
        }
    }
}
