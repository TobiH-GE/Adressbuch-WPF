﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Adressbuch_Model;

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

            Address modifiedAddress = new Address { ID = Parent.SelectedIndex, ForeName = Parent.SelectedForeName, LastName = Parent.SelectedLastName, Street = Parent.SelectedStreet, Town = Parent.SelectedTown, Country = Parent.SelectedCountry };
            Parent.EntryList[(int)parameter] = modifiedAddress;

            Database addressDatabase = new Database();
            addressDatabase.ModifyAddressInDatabase(modifiedAddress);
        }
    }
}
