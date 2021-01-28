using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Adressbuch_Model;

namespace Adressbuch_ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Contact> entries;
        private ObservableCollection<Contact> entriesWithFilter = new ObservableCollection<Contact>();
        public ICommand AddUser { get; init; }
        public ICommand ModifyUser { get; init; }
        public ICommand GetUser { get; init; }
        public ICommand OpenURL { get; init; }

        private int     _selectedID = 0;
        private int     _selectedIndex = 0;
        private Contact _selectedItem;
        private string  _selectedForeName = "";
        private string  _selectedLastName = "";
        private string  _selectedTown = "";
        private string  _selectedStreet = "";
        private string  _selectedCountry = "";
        private string  _selectedEMail = "";
        private string  _selectedFacebook = "";
        private string  _selectedInstagram = "";
        private string  _selectedTwitter = "";
        private string  _selectedXing = "";
        private string _filter = "";

        public string Filter
        {
            get { return _filter; }
            set
            {
                if (_filter != value)
                {
                    _filter = value;
                    FilterEntries();
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Filter)));
                }
            }
        }

        public MainViewModel()
        {
            GetContactsFromDatabase();

            AddUser = new AddContactCommand() { Parent = this };
            ModifyUser = new ModifyContactCommand() { Parent = this };
            GetUser = new GetContactCommand() { Parent = this };
            OpenURL = new OpenURLCommand() { Parent = this };
        }
        public void GetContactsFromDatabase()
        {
            entries = new ObservableCollection<Contact>(Database.LoadContactsDatabase());
            FilterEntries();
        }
        private void FilterEntries()
        {
            entriesWithFilter.Clear();
            foreach (var item in entries)
                if (item.ForeName.Contains(_filter) ||
                    item.LastName.Contains(_filter) ||
                    item.Street.Contains(_filter) ||
                    item.Town.Contains(_filter) ||
                    item.Country.Contains(_filter))
                    EntryList.Add(item);
        }
        public int SelectedIndex // TODO: remove, only needed for ListView
        {
            get { return _selectedIndex; }
            set
            {
                if (_selectedIndex != value && value != -1)
                {
                    _selectedIndex = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedIndex)));
                    GetContactCommand run = new GetContactCommand() { Parent = this };
                    run.Execute(_selectedIndex);
                }
            }
        }
        public Contact SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value && value != null)
                {
                    _selectedItem = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedItem)));
                    GetContactCommand run = new GetContactCommand() { Parent = this };
                    run.Execute(_selectedItem.ID - 1);
                }
            }
        }
        public int SelectedID
        {
            get { return _selectedID; }
            set
            {
                if (_selectedID != value && value != -1)
                {
                    _selectedID = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedID)));
                }
            }
        }
        public string SelectedForeName
        {
            get { return _selectedForeName; }
            set
            {
                if (_selectedForeName != value)
                {
                    _selectedForeName = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedForeName)));
                }
            }
        }
        public string SelectedLastName
        {
            get { return _selectedLastName; }
            set
            {
                if (_selectedLastName != value)
                {
                    _selectedLastName = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedLastName)));
                }
            }
        }
        public string SelectedStreet
        {
            get { return _selectedStreet; }
            set
            {
                if (_selectedStreet != value)
                {
                    _selectedStreet = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedStreet)));
                }
            }
        }
        public string SelectedTown
        {
            get { return _selectedTown; }
            set
            {
                if (_selectedTown != value)
                {
                    _selectedTown = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedTown)));
                }
            }
        }
        public string SelectedCountry
        {
            get { return _selectedCountry; }
            set
            {
                if (_selectedCountry != value)
                {
                    _selectedCountry = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedCountry)));
                }
            }
        }
        public string SelectedEMail
        {
            get { return _selectedEMail; }
            set
            {
                if (_selectedEMail != value)
                {
                    _selectedEMail = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedEMail)));
                }
            }
        }
        public string SelectedFacebook
        {
            get { return _selectedFacebook; }
            set
            {
                if (_selectedFacebook != value)
                {
                    _selectedFacebook = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedFacebook)));
                }
            }
        }
        public string SelectedInstagram
        {
            get { return _selectedInstagram; }
            set
            {
                if (_selectedInstagram != value)
                {
                    _selectedInstagram = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedInstagram)));
                }
            }
        }
        public string SelectedTwitter
        {
            get { return _selectedTwitter; }
            set
            {
                if (_selectedTwitter != value)
                {
                    _selectedTwitter = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedTwitter)));
                }
            }
        }
        public string SelectedXing
        {
            get { return _selectedXing; }
            set
            {
                if (_selectedXing != value)
                {
                    _selectedXing = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedXing)));
                }
            }
        }
        public ObservableCollection<Contact> EntryList
        {
            get => entriesWithFilter;
            set
            {
                if (entriesWithFilter != value)
                {
                    entriesWithFilter = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EntryList)));
                }
            }
        }
    }
}
