using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Adressbuch_ViewModel
{
    public class GetContactCommand : ICommand
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
            Parent.SelectedID = Parent.EntryList[(int)parameter].ID;
            Parent.SelectedForeName = Parent.EntryList[(int)parameter].ForeName;
            Parent.SelectedLastName = Parent.EntryList[(int)parameter].LastName;
            Parent.SelectedStreet = Parent.EntryList[(int)parameter].Street;
            Parent.SelectedTown = Parent.EntryList[(int)parameter].Town;
            Parent.SelectedCountry = Parent.EntryList[(int)parameter].Country;
            Parent.SelectedEMail = Parent.EntryList[(int)parameter].EMail;
            Parent.SelectedFacebook = Parent.EntryList[(int)parameter].Facebook;
            Parent.SelectedInstagram = Parent.EntryList[(int)parameter].Instagram;
            Parent.SelectedTwitter = Parent.EntryList[(int)parameter].Twitter;
            Parent.SelectedXing = Parent.EntryList[(int)parameter].Xing;
        }
    }
}
