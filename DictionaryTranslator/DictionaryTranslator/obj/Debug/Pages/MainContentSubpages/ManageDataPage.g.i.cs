﻿#pragma checksum "..\..\..\..\Pages\MainContentSubpages\ManageDataPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B8B0B8D7FC812E44F085692B5C6D13F1C236DA7E83A79E7589CFB0F2E0BE62B3"
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
    /// ManageDataPage
    /// </summary>
    public partial class ManageDataPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\..\Pages\MainContentSubpages\ManageDataPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBox_SelectTable;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\Pages\MainContentSubpages\ManageDataPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBox_SelectField;
        
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
            System.Uri resourceLocater = new System.Uri("/DictionaryTranslator;component/pages/maincontentsubpages/managedatapage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\MainContentSubpages\ManageDataPage.xaml"
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
            this.ComboBox_SelectTable = ((System.Windows.Controls.ComboBox)(target));
            
            #line 14 "..\..\..\..\Pages\MainContentSubpages\ManageDataPage.xaml"
            this.ComboBox_SelectTable.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBox_OnSelectTable);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ComboBox_SelectField = ((System.Windows.Controls.ComboBox)(target));
            
            #line 15 "..\..\..\..\Pages\MainContentSubpages\ManageDataPage.xaml"
            this.ComboBox_SelectField.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBox_OnSelectField);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 16 "..\..\..\..\Pages\MainContentSubpages\ManageDataPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_DeleteField);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

