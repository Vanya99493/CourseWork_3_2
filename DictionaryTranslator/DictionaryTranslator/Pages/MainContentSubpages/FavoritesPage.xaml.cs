using System;
using System.Collections.Generic;
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
using DictionaryTranslator.Scripts.Data;

namespace DictionaryTranslator.Pages.MainContentSubpages
{
    /// <summary>
    /// Interaction logic for FavoritesPage.xaml
    /// </summary>
    public partial class FavoritesPage : Page
    {
        private DataController _dataController;
        private string _login;

        public FavoritesPage(string login)
        {
            InitializeComponent();
            _dataController = DataController.Instance;
            _login = login;

            FillFavoritesLists();
        }

        public void Button_SelectCustomQuery(object sender, RoutedEventArgs e)
        {
            DataGrid_DataView.ItemsSource = _dataController.GetDataView(TextBox_CustomQuery.Text);
        }

        public void Button_AddNewLibrary(object sender, RoutedEventArgs e)
        {
            _dataController.AddNewLibrary(_login, TextBox_NewLibraryName.Text);
            TextBox_NewLibraryName.Text = "";
            FillFavoritesLists();
        }

        public void Button_SelectFavoriteList(object sender, RoutedEventArgs e)
        {
            try
            {
                DataGrid_DataView.ItemsSource = _dataController.GetFavoriteList(ComboBox_FavoritesLists.SelectedItem.ToString());
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Error. Wrong parameters");
            }
        }

        private void FillFavoritesLists()
        {
            ComboBox_FavoritesLists.Items.Clear();
            List<string> favoritesLists = _dataController.GetAllLibraries(_login);
            foreach (string favoritesList in favoritesLists)
            {
                ComboBox_FavoritesLists.Items.Add(favoritesList);
            }
        }
    }
}