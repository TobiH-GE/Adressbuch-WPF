using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Adressbuch_ViewModel
{
    public class AddUserCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public MainViewModel Parent;
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Parent.EntryList.Add(new Adressbuch_Model.Address { ForeName = Parent.SelectedForeName, LastName = Parent.SelectedLastName, Street = Parent.SelectedStreet, Town = Parent.SelectedTown, Country = Parent.SelectedCountry });
        }
    }
}
