using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Adressbuch_Model;

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
            Address newAddress = new Address { ForeName = Parent.SelectedForeName, LastName = Parent.SelectedLastName, Street = Parent.SelectedStreet, Town = Parent.SelectedTown, Country = Parent.SelectedCountry };
            Parent.EntryList.Add(newAddress);

            Database addressDatabase = new Database();
            addressDatabase.SaveAddressToDatabase(newAddress);
        }
    }
}
