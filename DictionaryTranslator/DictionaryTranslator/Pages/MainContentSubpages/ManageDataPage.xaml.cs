using DictionaryTranslator.Scripts.Data;
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

namespace DictionaryTranslator.Pages.MainContentSubpages
{
    public delegate List<string> DataList();

    public partial class ManageDataPage : Page
    {
        private DataController _dataController;
        private string _selectedTable;
        private string _selectedField;
        private Dictionary<string, DataList> _mapTablesGetMethods;

        public ManageDataPage()
        {
            InitializeComponent();
            _dataController = DataController.Instance;
            _mapTablesGetMethods = new Dictionary<string, DataList>()
            {
                { "words", _dataController.GetWords },
                { "categories", _dataController.GetCategories },
                { "favorites", _dataController.GetFavorites },
                { "languages", _dataController.GetLanguages }
            };

            _selectedTable = null;
            _selectedField = null;

            FillTablesComboBox();
        }

        public void Button_DeleteField(object sender, RoutedEventArgs e)
        {
            if(_selectedTable == null)
            {
                MessageBox.Show("Error. Table is not selected");
                return;
            }
            if(_selectedField == null)
            {
                MessageBox.Show("Error. Field is not selected");
                return;
            }

            switch (_selectedTable)
            {
                case "words":
                    _dataController.DeleteWord(_selectedField);
                    break;
                case "categories":
                    _dataController.DeleteCategory(_selectedField);
                    break;
                case "favorites":
                    _dataController.DeleteFavoriteList(_selectedField);
                    break;
                case "languages":
                    _dataController.DeleteLanguage(_selectedField);
                    break;
                default:
                    break;
            }

            ComboBox_SelectField.SelectedIndex = -1;
            ComboBox_SelectTable.SelectedIndex = -1; 
            ComboBox_SelectField.Items.Clear();
        }

        public void ComboBox_OnSelectTable(object sender, SelectionChangedEventArgs e)
        {
            if(ComboBox_SelectTable.SelectedIndex == -1)
            {
                return;
            }
            ComboBox_SelectField.SelectedIndex = -1;
            ComboBox_SelectField.Items.Clear();
            _selectedTable = ComboBox_SelectTable.SelectedItem.ToString();
            List<string> list = _mapTablesGetMethods[_selectedTable].Invoke();
            foreach (string item in list)
            {
                ComboBox_SelectField.Items.Add(item);
            }
        }

        public void ComboBox_OnSelectField(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox_SelectField.SelectedIndex == -1)
            {
                return;
            }
            _selectedField = ComboBox_SelectField.SelectedItem?.ToString();
        }

        private void FillTablesComboBox()
        {
            ComboBox_SelectTable.Items.Clear();
            foreach (string tableName in _mapTablesGetMethods.Keys)
            {
                ComboBox_SelectTable.Items.Add(tableName);
            }
        }
    }
}