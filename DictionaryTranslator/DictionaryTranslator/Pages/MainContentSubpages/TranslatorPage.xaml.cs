using DictionaryTranslator.Scripts.Data;
using DictionaryTranslator.Scripts.Enums;
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
    /// <summary>
    /// Interaction logic for TranslatorPage.xaml
    /// </summary>
    public partial class TranslatorPage : Page
    {
        private DataController _dataController;
        private TranslateState _translateState;
        private string _login;

        public TranslatorPage(string login)
        {
            InitializeComponent();
            _dataController = DataController.Instance;
            _login = login;

            SetTranslateMode(TranslateState.Translate);

            FillLanguagesComboBoxes();
            FillLibrariesComboBox();
            FillCategoriesComboBoxes();
        }

        public void ExecuteAction(object sender, RoutedEventArgs e)
        {
            switch (_translateState)
            {
                case TranslateState.Translate:
                    Row_AddToFavorite.Height = new GridLength(2, GridUnitType.Star);
                    Row_InputOutputBlocks.Height = new GridLength(14, GridUnitType.Star);
                    string translation = "";
                    try
                    {
                        _dataController.GetTranslation(out translation, TextBox_EnterSourceWord.Text, ComboBox_SourceWordLanguage.SelectedItem.ToString(), ComboBox_TargetWordLanguage.SelectedItem.ToString());
                    }
                    catch (NullReferenceException)
                    {
                        MessageBox.Show("Error. Wrong parameters");
                    }
                    TextBlock_OutputTargetWord.Text = translation;
                    break;
                case TranslateState.Add:
                    try
                    {
                        if (ComboBox_SourceWordLanguage.SelectedItem.ToString() == ComboBox_TargetWordLanguage.SelectedItem.ToString())
                        {
                            MessageBox.Show("Error. Wrong parameters");
                        }
                        _dataController.AddTranslation(TextBox_EnterSourceWord.Text, TextBox_EnterTargetWord.Text, ComboBox_SourceWordLanguage.SelectedItem.ToString(), ComboBox_TargetWordLanguage.SelectedItem.ToString());
                        
                    }
                    catch (NullReferenceException)
                    {
                        MessageBox.Show("Error. Wrong parameters");
                    }
                    try
                    {
                        _dataController.AddCategoryToWord(TextBox_EnterSourceWord.Text, ComboBox_SourceWordCategory.SelectedItem.ToString());
                        _dataController.AddCategoryToWord(TextBox_EnterTargetWord.Text, ComboBox_TargetWordCategory.SelectedItem.ToString());
                    }
                    catch (NullReferenceException){}
                    break;
            }
        }

        public void SwitchTranslateMode(object sender, RoutedEventArgs e)
        {
            switch (_translateState)
            {
                case TranslateState.Translate:
                    SetTranslateMode(TranslateState.Add);
                    break;
                case TranslateState.Add:
                    SetTranslateMode(TranslateState.Translate);
                    break;
            }
        }

        public void ChangeSourceWordField(object sender, RoutedEventArgs e)
        {
            TextBlock_OutputTargetWord.Text = "";
            Row_AddToFavorite.Height = new GridLength(0, GridUnitType.Star);
            Row_InputOutputBlocks.Height = new GridLength(16, GridUnitType.Star);
        }

        public void Button_AddNewLanguage(object sender, RoutedEventArgs e)
        {
            if (!_dataController.AddLanguage(TextBox_NewLanguageField.Text))
            {
                MessageBox.Show("Error");
            }

            FillLanguagesComboBoxes();
        }

        public void Button_SaveToFavorite(object sender, RoutedEventArgs e)
        {
            try
            {
                _dataController.SaveToLibrary(
                    ComboBox_Libraries.SelectedItem.ToString(),
                    TextBox_EnterSourceWord.Text,
                    _translateState == TranslateState.Translate ? TextBlock_OutputTargetWord.Text : TextBox_EnterTargetWord.Text,
                    ComboBox_SourceWordLanguage.SelectedItem.ToString(),
                    ComboBox_TargetWordLanguage.SelectedItem.ToString()
                    );
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Parameters error");
            }

            FillLibrariesComboBox();
        }

        public void Button_AddNewCategory(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!_dataController.AddNewCategory(TextBox_NewCategoryField.Text))
                {
                    MessageBox.Show("Parameters error");
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Parameters error");
            }

            FillCategoriesComboBoxes();
            TextBox_NewCategoryField.Text = "";
        }

        private void FillLanguagesComboBoxes()
        {
            List<string> languages = _dataController.GetLanguages();

            ComboBox_SourceWordLanguage.Items.Clear();
            ComboBox_TargetWordLanguage.Items.Clear();

            foreach (string language in languages)
            {
                ComboBox_SourceWordLanguage.Items.Add(language);
                ComboBox_TargetWordLanguage.Items.Add(language);
            }
        }

        private void FillLibrariesComboBox()
        {
            List<string> libraries = _dataController.GetAllLibraries(_login);

            ComboBox_Libraries.Items.Clear();

            foreach (string library in libraries)
            {
                ComboBox_Libraries.Items.Add(library);
            }
        }

        private void FillCategoriesComboBoxes()
        {
            List<string> categories = _dataController.GetCategories();

            ComboBox_SourceWordCategory.Items.Clear();
            ComboBox_TargetWordCategory.Items.Clear();

            foreach (string category in categories)
            {
                ComboBox_SourceWordCategory.Items.Add(category);
                ComboBox_TargetWordCategory.Items.Add(category);
            }
        }

        private void SetTranslateMode(TranslateState translateState)
        {
            _translateState = translateState;
            switch (_translateState)
            {
                case TranslateState.Translate:
                    Button_ExecuteAction.Content = "TRANSLATE";
                    Button_SwitchTranslateMode.Content = "TO ADD";
                    TextBox_EnterTargetWord.Visibility = Visibility.Collapsed;
                    TextBlock_OutputTargetWord.Text = "";
                    TextBlock_OutputTargetWord.Visibility = Visibility.Visible;
                    Row_InputOutputBlocks.Height = new GridLength(16, GridUnitType.Star);
                    Row_CategoriesController.Height = new GridLength(0, GridUnitType.Star);
                    Row_AddNewLanguage.Height = new GridLength(0, GridUnitType.Star);
                    Row_AddToFavorite.Height = new GridLength(0, GridUnitType.Star);
                    break;
                case TranslateState.Add:
                    Button_ExecuteAction.Content = "ADD";
                    Button_SwitchTranslateMode.Content = "TO TRANSLATE";
                    TextBox_EnterTargetWord.Text = "";
                    TextBox_EnterTargetWord.Visibility = Visibility.Visible;
                    TextBlock_OutputTargetWord.Visibility = Visibility.Collapsed;
                    TextBox_NewLanguageField.Text = "";
                    Row_InputOutputBlocks.Height = new GridLength(12, GridUnitType.Star);
                    Row_CategoriesController.Height = new GridLength(2, GridUnitType.Star);
                    Row_AddNewLanguage.Height = new GridLength(2, GridUnitType.Star);
                    Row_AddToFavorite.Height = new GridLength(0, GridUnitType.Star);
                    break;
            }
        }

        private void TextBox_OutputTargetWord_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {

        }
    }
}
