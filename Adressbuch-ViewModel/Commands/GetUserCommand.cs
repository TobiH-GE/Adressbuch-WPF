using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Adressbuch_ViewModel
{
    public class GetUserCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public MainViewModel Parent;
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if ((int)parameter < 0 || (int)parameter >= Parent.EntryList.Count) return;
            Parent.SelectedForeName = Parent.EntryList[(int)parameter].ForeName;
            Parent.SelectedLastName = Parent.EntryList[(int)parameter].LastName;
            Parent.SelectedStreet = Parent.EntryList[(int)parameter].Street;
            Parent.SelectedTown = Parent.EntryList[(int)parameter].Town;
            Parent.SelectedCountry = Parent.EntryList[(int)parameter].Country;
        }
    }
}
