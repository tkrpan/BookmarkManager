using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookmarkManager.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TKrpan.BookmarkManager.Infrastructure.BookmarkManager _bookmarkManager;

        public MainWindow()
        {
            InitializeComponent();

            _bookmarkManager = new TKrpan.BookmarkManager.Infrastructure.BookmarkManager();

            _RefreshList();
        }

        private void _RefreshList()
        {
            listView.Items.Clear();

            var allBookmarks = _bookmarkManager.GetAllBookmarks();

            foreach(var bookmark in allBookmarks)
            {
                listView.Items.Add(bookmark);
            }
        }

        private void _buttonDodaj_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxNaziv.Text))
            {
                var isAdded = _bookmarkManager.Add(textBoxNaziv.Text, textBoxUrl.Text);

                if (!isAdded)
                {
                    MessageBox.Show("Unešeni url nije ispravan!");
                }
                else
                {
                    textBoxNaziv.Clear();
                    textBoxUrl.Clear();
                    _RefreshList();
                }
            }
            else
            {
                MessageBox.Show("Unesite naziv!");
            }
        }

        private int _GetSelectedIndex()
        {
            return listView.SelectedIndex;
        }

        private void _buttonUkloni_Click(object sender, RoutedEventArgs e)
        {
            var index = _GetSelectedIndex();

            if (index != -1)
            {
                _bookmarkManager.Remove(index);
                _RefreshList();
            }
            else
            {
                MessageBox.Show("Nije odabran niti jedan bookmark!");
            }
        }

        private void _buttonOtvori_Click(object sender, RoutedEventArgs e)
        {
            var index = _GetSelectedIndex();

            if (index != -1)
            {
                _bookmarkManager.Run(index);
            }
            else
            {
                MessageBox.Show("Nije odabran niti jedan bookmark!");
            }
        }
    }
}
