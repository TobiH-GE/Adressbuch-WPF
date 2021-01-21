using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Adressbuch_ViewModel
{
    public class ModifyUserCommand : ICommand
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
            Parent.EntryList[(int)parameter].ForeName = Parent.SelectedForeName;
            Parent.EntryList[(int)parameter].LastName = Parent.SelectedLastName;
            Parent.EntryList[(int)parameter].Street = Parent.SelectedStreet;
            Parent.EntryList[(int)parameter].Town = Parent.SelectedTown;
            Parent.EntryList[(int)parameter].Country = Parent.SelectedCountry;
        }
    }
}
