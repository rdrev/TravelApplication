﻿#pragma checksum "..\..\AddTaskPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E87F547DCD01A4217DA4B4369BF1C43CD47B0839D66EAAD87DF7957206BD845C"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

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
using ДорожноеПриложение;


namespace ДорожноеПриложение {
    
    
    /// <summary>
    /// AddTaskPage
    /// </summary>
    public partial class AddTaskPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 36 "..\..\AddTaskPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CBB;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\AddTaskPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CBK;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\AddTaskPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DP;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\AddTaskPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CleBtn;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\AddTaskPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/ДорожноеПриложение;component/addtaskpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddTaskPage.xaml"
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
            this.CBB = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.CBK = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.DP = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            this.CleBtn = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\AddTaskPage.xaml"
            this.CleBtn.Click += new System.Windows.RoutedEventHandler(this.CleBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.AddBtn = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\AddTaskPage.xaml"
            this.AddBtn.Click += new System.Windows.RoutedEventHandler(this.AddBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

