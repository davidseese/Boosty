﻿#pragma checksum "..\..\..\..\MVVM\View\BasicView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D32D5D6B34BC2D0ADD7E09CF3BB1DC9E6FEA687F759B9ADD9B27F23E2FCD1C64"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Boosty.MVVM.View;
using Boosty.MVVM.ViewModel;
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


namespace Boosty.MVVM.View {
    
    
    /// <summary>
    /// BasicView
    /// </summary>
    public partial class BasicView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 83 "..\..\..\..\MVVM\View\BasicView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button WSOptimization;
        
        #line default
        #line hidden
        
        
        #line 149 "..\..\..\..\MVVM\View\BasicView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NVIDIAOpimization;
        
        #line default
        #line hidden
        
        
        #line 213 "..\..\..\..\MVVM\View\BasicView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AMDOptimization;
        
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
            System.Uri resourceLocater = new System.Uri("/Boosty;component/mvvm/view/basicview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\MVVM\View\BasicView.xaml"
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
            this.WSOptimization = ((System.Windows.Controls.Button)(target));
            
            #line 90 "..\..\..\..\MVVM\View\BasicView.xaml"
            this.WSOptimization.Click += new System.Windows.RoutedEventHandler(this.WindowsOptimization_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.NVIDIAOpimization = ((System.Windows.Controls.Button)(target));
            
            #line 156 "..\..\..\..\MVVM\View\BasicView.xaml"
            this.NVIDIAOpimization.Click += new System.Windows.RoutedEventHandler(this.NVIDIAOptimization_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.AMDOptimization = ((System.Windows.Controls.Button)(target));
            
            #line 220 "..\..\..\..\MVVM\View\BasicView.xaml"
            this.AMDOptimization.Click += new System.Windows.RoutedEventHandler(this.AMDOptimization_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
