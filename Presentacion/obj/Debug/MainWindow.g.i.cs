﻿#pragma checksum "..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5C1FAAA739B4B2A1D8269D20737C430C2B362F55"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Presentacion;
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


namespace Presentacion {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Negro;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid redNegro;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle rectUsu;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Usuario;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle rect2;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle RecCon;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox COntraseña;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button iniciobtn;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Incorrecto;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Cloase;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Login1;
        
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
            System.Uri resourceLocater = new System.Uri("/Presentacion;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
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
            this.Negro = ((System.Windows.Controls.Border)(target));
            
            #line 10 "..\..\MainWindow.xaml"
            this.Negro.Loaded += new System.Windows.RoutedEventHandler(this.B_Load);
            
            #line default
            #line hidden
            return;
            case 2:
            this.redNegro = ((System.Windows.Controls.Grid)(target));
            
            #line 11 "..\..\MainWindow.xaml"
            this.redNegro.Loaded += new System.Windows.RoutedEventHandler(this.Grid_Loaded);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 12 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Grid_MouseDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.rectUsu = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 5:
            this.Usuario = ((System.Windows.Controls.TextBox)(target));
            
            #line 14 "..\..\MainWindow.xaml"
            this.Usuario.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Usuario_TextChanged);
            
            #line default
            #line hidden
            
            #line 14 "..\..\MainWindow.xaml"
            this.Usuario.GotFocus += new System.Windows.RoutedEventHandler(this.Usuario_GotFocus);
            
            #line default
            #line hidden
            
            #line 14 "..\..\MainWindow.xaml"
            this.Usuario.LostFocus += new System.Windows.RoutedEventHandler(this.Usuario_LostFocus);
            
            #line default
            #line hidden
            
            #line 14 "..\..\MainWindow.xaml"
            this.Usuario.KeyDown += new System.Windows.Input.KeyEventHandler(this.Usuario_KeyDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.rect2 = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 7:
            this.RecCon = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 8:
            this.COntraseña = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 19 "..\..\MainWindow.xaml"
            this.COntraseña.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.COntraseña_MouseDown);
            
            #line default
            #line hidden
            
            #line 19 "..\..\MainWindow.xaml"
            this.COntraseña.GotFocus += new System.Windows.RoutedEventHandler(this.COntraseña_GotFocus);
            
            #line default
            #line hidden
            
            #line 19 "..\..\MainWindow.xaml"
            this.COntraseña.DataContextChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.COntraseña_DataContextChanged);
            
            #line default
            #line hidden
            
            #line 19 "..\..\MainWindow.xaml"
            this.COntraseña.LostFocus += new System.Windows.RoutedEventHandler(this.COntraseña_LostFocus);
            
            #line default
            #line hidden
            
            #line 19 "..\..\MainWindow.xaml"
            this.COntraseña.PasswordChanged += new System.Windows.RoutedEventHandler(this.COntraseña_PasswordChanged);
            
            #line default
            #line hidden
            
            #line 19 "..\..\MainWindow.xaml"
            this.COntraseña.KeyDown += new System.Windows.Input.KeyEventHandler(this.COntraseña_KeyDown);
            
            #line default
            #line hidden
            return;
            case 9:
            this.iniciobtn = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\MainWindow.xaml"
            this.iniciobtn.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            
            #line 21 "..\..\MainWindow.xaml"
            this.iniciobtn.MouseMove += new System.Windows.Input.MouseEventHandler(this.Button_MouseMove);
            
            #line default
            #line hidden
            
            #line 21 "..\..\MainWindow.xaml"
            this.iniciobtn.GotFocus += new System.Windows.RoutedEventHandler(this.iniciobtn_GotFocus);
            
            #line default
            #line hidden
            
            #line 21 "..\..\MainWindow.xaml"
            this.iniciobtn.IsStylusDirectlyOverChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.iniciobtn_IsStylusDirectlyOverChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.Incorrecto = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.Cloase = ((System.Windows.Controls.Image)(target));
            
            #line 41 "..\..\MainWindow.xaml"
            this.Cloase.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Cloase_MouseDown);
            
            #line default
            #line hidden
            return;
            case 12:
            this.Login1 = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

