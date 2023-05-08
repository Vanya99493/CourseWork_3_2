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

namespace DictionaryTranslator.Pages
{
    public partial class MainContent : Page
    {
        private string _login;

        public MainContent(string login)
        {
            InitializeComponent();
            _login = login;
            Textblock_UserLogin.Text = _login;
            NavigateToTranslator(null, null);
        }

        public void NavigateToTranslator(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Navigate(new Pages.MainContentSubpages.TranslatorPage(_login));
        }

        public void NavigateToLibrary(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Navigate(new Pages.MainContentSubpages.FavoritesPage(_login));
        }

        public void NavigateToManageData(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Navigate(new Pages.MainContentSubpages.ManageDataPage());
        }
    }
}
