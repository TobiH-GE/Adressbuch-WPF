using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Adressbuch_ViewModel
{
    public class OpenURLCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public MainViewModel Parent;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = (string)parameter,
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            catch (Exception)
            {

                throw; //TODO: error
            }
        }
    }
}
