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
        private ObservableCollection<Address> entries;

        private int _selectedIndex = 0;
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                if (_selectedIndex != value)
                {
                    _selectedIndex = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedIndex)));
                    GetUserCommand run = new GetUserCommand() { Parent = this };
                    run.Execute(_selectedIndex);
                }
            }
        }
        private string _selectedForeName;
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
        private string _selectedLastName;
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
        private string _selectedStreet;
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
        private string _selectedTown;
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
        private string _selectedCountry;
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

        public ICommand AddUser { get; init; }
        public ICommand ModifyUser { get; init; }
        public ICommand GetUser { get; init; }

        public MainViewModel()
        {
            EntryList = new ObservableCollection<Address>(StaticData.AdressList);

            AddUser = new AddUserCommand() { Parent = this };
            ModifyUser = new ModifyUserCommand() { Parent = this };
            GetUser = new GetUserCommand() { Parent = this };
        }

        public ObservableCollection<Address> EntryList
        {
            get => entries;
            set
            {
                if (entries != value)
                {
                    entries = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EntryList)));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
