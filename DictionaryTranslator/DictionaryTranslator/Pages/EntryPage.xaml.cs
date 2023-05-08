using DictionaryTranslator.Scripts.Data;
using DictionaryTranslator.Scripts.Enums;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup.Localizer;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DictionaryTranslator.Pages
{
    public partial class EntryPage : Page
    {
        public event Action<string> OnEnter;

        private DataController _dataController;
        private EntryState _entryState;
        private bool _isHidePassword;

        public EntryPage()
        {
            InitializeComponent();
            _dataController = DataController.Instance;
            _entryState = EntryState.Entry;
            _isHidePassword = true;
        }

        public EntryPage(DataController dataController)
        {
            _dataController = dataController;
        }

        private void ChangeState(object sender, RoutedEventArgs e)
        {
            if(_entryState == EntryState.Entry)
            {
                _entryState = EntryState.Registration;
                TextBlock_EntryState.Text = "Registration";
                Button_ChangeEntryState.Content = "ENTRY";
            }
            else if(_entryState == EntryState.Registration)
            {
                _entryState = EntryState.Entry;
                TextBlock_EntryState.Text = "Entry";
                Button_ChangeEntryState.Content = "REGISTRATION";
            }
            else
            {
                new Exception("Non available entry state");
            }
        }

        public void Enter(object sender, RoutedEventArgs e)
        {
            string login = TextBox_Login.Text;
            string password = _isHidePassword ? PasswordBox_Password.Password : TextBox_Password.Text;

            if((_entryState == EntryState.Entry && !_dataController.EnterInProgram(login, password)) || 
                (_entryState == EntryState.Registration && !_dataController.RegistrationInProgram(login, password)))
            {
                MessageBox.Show(_entryState == EntryState.Entry ? "Wrong password" : "Login is busy");
                return;
            }
            else
            {
                new Exception("Non available entry state");
            }

            OnEnter?.Invoke(login);
        }

        private void CheckBox_Password_Checked(object sender , RoutedEventArgs e)
        {
            PasswordBox_Password.Visibility = Visibility.Collapsed;
            TextBox_Password.Visibility = Visibility.Visible;
            TextBox_Password.Text = PasswordBox_Password.Password;
            _isHidePassword = false;
        }

        private void CheckBox_Password_Unchecked(object sender, RoutedEventArgs e)
        {
            PasswordBox_Password.Visibility = Visibility.Visible;
            TextBox_Password.Visibility = Visibility.Collapsed;
            PasswordBox_Password.Password = TextBox_Password.Text;
            _isHidePassword = true;
        }
    }
}