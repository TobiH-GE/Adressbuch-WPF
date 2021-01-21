using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adressbuch_Model
{
    public class Address : INotifyPropertyChanged
    {
        private int _id;
        private string _foreName;
        private string _lastName;
        private string _street;
        private string _town;
        private string _country;

        public int ID
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ID)));
                }
            }
        }
        public string ForeName
        {
            get => _foreName;
            set
            {
                if (_foreName != value)
                {
                    _foreName = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ForeName)));
                }
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LastName)));
                }
            }
        }
        public string Street
        {
            get => _street;
            set
            {
                if (_street != value)
                {
                    _street = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Street)));
                }
            }
        }
        public string Town
        {
            get => _town;
            set
            {
                if (_town != value)
                {
                    _town = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Town)));
                }
            }
        }
        public string Country
        {
            get => _country;
            set
            {
                if (_country != value)
                {
                    _country = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Country)));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
