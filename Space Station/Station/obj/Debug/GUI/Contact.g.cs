﻿#pragma checksum "..\..\..\GUI\Contact.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C004CA899EC5CF08F64F06C1A560F56F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Station.GUI;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace Station.GUI {
    
    
    /// <summary>
    /// Contact
    /// </summary>
    public partial class Contact : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\GUI\Contact.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_Search;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\GUI\Contact.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Search;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\GUI\Contact.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LV_Search;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\GUI\Contact.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_Name;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\GUI\Contact.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_Jop;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\GUI\Contact.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_Phone;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\GUI\Contact.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_Age;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\GUI\Contact.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_Gender;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\GUI\Contact.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_Address;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\GUI\Contact.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Photo;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\GUI\Contact.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Close;
        
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
            System.Uri resourceLocater = new System.Uri("/Station;component/gui/contact.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\GUI\Contact.xaml"
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
            this.txt_Search = ((System.Windows.Controls.TextBox)(target));
            
            #line 25 "..\..\..\GUI\Contact.xaml"
            this.txt_Search.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.txt_Search_PreviewKeyDown);
            
            #line default
            #line hidden
            
            #line 25 "..\..\..\GUI\Contact.xaml"
            this.txt_Search.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txt_Search_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Search = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.LV_Search = ((System.Windows.Controls.ListView)(target));
            
            #line 27 "..\..\..\GUI\Contact.xaml"
            this.LV_Search.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.LV_Search_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txt_Name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txt_Jop = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txt_Phone = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txt_Age = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.txt_Gender = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.txt_Address = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.Photo = ((System.Windows.Controls.Image)(target));
            return;
            case 11:
            this.btn_Close = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\..\GUI\Contact.xaml"
            this.btn_Close.Click += new System.Windows.RoutedEventHandler(this.btn_Close_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

