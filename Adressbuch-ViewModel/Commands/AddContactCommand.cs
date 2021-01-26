using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Adressbuch_Model;

namespace Adressbuch_ViewModel
{
    public class AddContactCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public MainViewModel Parent;
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter) 
        {
            Contact newContact = new Contact { ForeName = Parent.SelectedForeName, LastName = Parent.SelectedLastName, Street = Parent.SelectedStreet, Town = Parent.SelectedTown, Country = Parent.SelectedCountry };

            Database contactsDatabase = new Database();
            contactsDatabase.SaveContactToDatabase(newContact);

            Parent.GetContactsFromDatabase();
        }
    }
}
