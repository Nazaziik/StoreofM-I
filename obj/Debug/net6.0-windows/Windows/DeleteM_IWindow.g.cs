﻿#pragma checksum "..\..\..\..\Windows\DeleteM_IWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4575D759D37DC8584454D749177ECA6700795AA4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using StoreofM_I.Windows;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace StoreofM_I.Windows {
    
    
    /// <summary>
    /// DeleteM_IWindow
    /// </summary>
    public partial class DeleteM_IWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\..\Windows\DeleteM_IWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dltGrid;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\Windows\DeleteM_IWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SurenameDltBox;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\Windows\DeleteM_IWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PeselDltBox;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\Windows\DeleteM_IWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DoBDltDatePicker;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/StoreofM-I;component/windows/deletem_iwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\DeleteM_IWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.dltGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.SurenameDltBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 45 "..\..\..\..\Windows\DeleteM_IWindow.xaml"
            this.SurenameDltBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.FilterData_textChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.PeselDltBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 48 "..\..\..\..\Windows\DeleteM_IWindow.xaml"
            this.PeselDltBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.FilterData_textChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.DoBDltDatePicker = ((System.Windows.Controls.TextBox)(target));
            
            #line 51 "..\..\..\..\Windows\DeleteM_IWindow.xaml"
            this.DoBDltDatePicker.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.FilterData_textChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 62 "..\..\..\..\Windows\DeleteM_IWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CancelDeleteButton_click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 65 "..\..\..\..\Windows\DeleteM_IWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SubmitDeleteButton_click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

