﻿#pragma checksum "..\..\..\Properties\Window1.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D7DDCFB007ECB413FCB4554CDC297C424B23FE86CFF32DD69AB1C1402C01F428"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Blocknote.Properties;
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


namespace Blocknote.Properties {
    
    
    /// <summary>
    /// Window1
    /// </summary>
    public partial class Window1 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\..\Properties\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Blocknote.Properties.Window1 Do_You_Want_Saving;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\Properties\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button YES;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Properties\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NO;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Properties\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CANCEL_OP;
        
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
            System.Uri resourceLocater = new System.Uri("/Blocknote;component/properties/window1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Properties\Window1.xaml"
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
            this.Do_You_Want_Saving = ((Blocknote.Properties.Window1)(target));
            return;
            case 2:
            this.YES = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\Properties\Window1.xaml"
            this.YES.Click += new System.Windows.RoutedEventHandler(this.YES_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.NO = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\Properties\Window1.xaml"
            this.NO.Click += new System.Windows.RoutedEventHandler(this.NO_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.CANCEL_OP = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\Properties\Window1.xaml"
            this.CANCEL_OP.Click += new System.Windows.RoutedEventHandler(this.CANCEL_OP_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

