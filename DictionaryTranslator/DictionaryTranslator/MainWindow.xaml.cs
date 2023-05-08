using DictionaryTranslator.Pages;
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

namespace DictionaryTranslator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            EntryPage entryPage = new EntryPage();
            entryPage.OnEnter += (string login) => { 
                MainWindowFrame.Navigate(new MainContent(login)); 
            };
            MainWindowFrame.Navigate(entryPage);
        }
    }
}