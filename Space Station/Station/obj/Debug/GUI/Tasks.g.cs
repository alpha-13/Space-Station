﻿#pragma checksum "..\..\..\GUI\Tasks.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "37B21BFFE95AA6FC7C9E7D1B15118C4B"
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
    /// Tasks
    /// </summary>
    public partial class Tasks : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\..\GUI\Tasks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_Title;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\GUI\Tasks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_Target;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\GUI\Tasks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_Search;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\GUI\Tasks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Hint;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\GUI\Tasks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LV_Employees;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\GUI\Tasks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox rtb_Task;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\GUI\Tasks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_Message;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\GUI\Tasks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Send;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\GUI\Tasks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Cancel;
        
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
            System.Uri resourceLocater = new System.Uri("/Station;component/gui/tasks.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\GUI\Tasks.xaml"
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
            this.txt_Title = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txt_Target = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txt_Search = ((System.Windows.Controls.TextBox)(target));
            
            #line 43 "..\..\..\GUI\Tasks.xaml"
            this.txt_Search.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Search_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Hint = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.LV_Employees = ((System.Windows.Controls.ListView)(target));
            
            #line 45 "..\..\..\GUI\Tasks.xaml"
            this.LV_Employees.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.LV_Employees_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.rtb_Task = ((System.Windows.Controls.RichTextBox)(target));
            return;
            case 7:
            this.txt_Message = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.btn_Send = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\GUI\Tasks.xaml"
            this.btn_Send.Click += new System.Windows.RoutedEventHandler(this.btn_Send_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btn_Cancel = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\..\GUI\Tasks.xaml"
            this.btn_Cancel.Click += new System.Windows.RoutedEventHandler(this.btn_Cancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

