﻿#pragma checksum "..\..\EmployeeLoginFormPL.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A4B33CF5D9483C052736986849296C86D980C6ACE310969DBA3461A615909F8F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using EmployeeTravelBookingSystemWPF;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace EmployeeTravelBookingSystemWPF {
    
    
    /// <summary>
    /// EmployeeLoginFormPL
    /// </summary>
    public partial class EmployeeLoginFormPL : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\EmployeeLoginFormPL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtUsername;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\EmployeeLoginFormPL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox pwdbxPassword;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\EmployeeLoginFormPL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnReset;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\EmployeeLoginFormPL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLogin;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\EmployeeLoginFormPL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnExit;
        
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
            System.Uri resourceLocater = new System.Uri("/EmployeeTravelBookingSystemWPF;component/employeeloginformpl.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\EmployeeLoginFormPL.xaml"
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
            this.txtUsername = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.pwdbxPassword = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 3:
            this.btnReset = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\EmployeeLoginFormPL.xaml"
            this.btnReset.Click += new System.Windows.RoutedEventHandler(this.btnreset_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnLogin = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\EmployeeLoginFormPL.xaml"
            this.btnLogin.Click += new System.Windows.RoutedEventHandler(this.btnlogin_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnExit = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\EmployeeLoginFormPL.xaml"
            this.btnExit.Click += new System.Windows.RoutedEventHandler(this.btnexit_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

