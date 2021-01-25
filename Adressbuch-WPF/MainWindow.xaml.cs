using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Adressbuch_Model;
using Adressbuch_ViewModel;

namespace Adressbuch_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string _filter = "";
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        public string Filter
        {
            get { return _filter; }
            set
            {
                if (_filter != value)
                {
                    _filter = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Filter)));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Contacts_Filter(object sender, System.Windows.Data.FilterEventArgs e)
        {
            bool accept = true;

            var item = (Contact)e.Item;

            accept = item.ForeName.Contains(FilterTextBox.Text);

            /*if (_filter != "")
            {
                accept = item.ForeName.Contains(_filter);
            }*/

            e.Accepted = accept;
        }
    }
}
