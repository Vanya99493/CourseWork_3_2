﻿#pragma checksum "..\..\..\..\Pages\MainContentSubpages\FavoritesPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "999EDAB49A5A260C4B687F85F6F7340635AE6FD9303D94C51E84983B809556CE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DictionaryTranslator.Pages.MainContentSubpages;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace DictionaryTranslator.Pages.MainContentSubpages {
    
    
    /// <summary>
    /// FavoritesPage
    /// </summary>
    public partial class FavoritesPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\..\Pages\MainContentSubpages\FavoritesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox_CustomQuery;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Pages\MainContentSubpages\FavoritesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBox_FavoritesLists;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Pages\MainContentSubpages\FavoritesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox_NewLibraryName;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\Pages\MainContentSubpages\FavoritesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGrid_DataView;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/DictionaryTranslator;component/pages/maincontentsubpages/favoritespage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\MainContentSubpages\FavoritesPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TextBox_CustomQuery = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            
            #line 25 "..\..\..\..\Pages\MainContentSubpages\FavoritesPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_SelectCustomQuery);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ComboBox_FavoritesLists = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            
            #line 28 "..\..\..\..\Pages\MainContentSubpages\FavoritesPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_SelectFavoriteList);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TextBox_NewLibraryName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            
            #line 36 "..\..\..\..\Pages\MainContentSubpages\FavoritesPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_AddNewLibrary);
            
            #line default
            #line hidden
            return;
            case 7:
            this.DataGrid_DataView = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

