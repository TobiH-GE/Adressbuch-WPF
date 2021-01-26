using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Adressbuch_Model;

namespace Adressbuch_ViewModel
{
    public class ModifyContactCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public MainViewModel Parent;
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter) //TODO: error handling
        {
            Contact modifiedContact = new Contact { ID = Parent.SelectedID, ForeName = Parent.SelectedForeName, LastName = Parent.SelectedLastName, Street = Parent.SelectedStreet, Town = Parent.SelectedTown, Country = Parent.SelectedCountry, EMail = Parent.SelectedEMail, Facebook = Parent.SelectedFacebook, Instagram = Parent.SelectedInstagram, Twitter = Parent.SelectedTwitter, Xing = Parent.SelectedXing };

            Database contactsDatabase = new Database();
            contactsDatabase.ModifyContactInDatabase(modifiedContact);

            Parent.GetContactsFromDatabase();
        }
    }
}
