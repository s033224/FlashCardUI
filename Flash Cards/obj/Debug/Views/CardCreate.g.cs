﻿#pragma checksum "..\..\..\Views\CardCreate.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6E8FEA9CBF532AA96829B967F1B09925F5A7F8E9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Flash_Cards.Views;
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


namespace Flash_Cards.Views {
    
    
    /// <summary>
    /// CardCreate
    /// </summary>
    public partial class CardCreate : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 56 "..\..\..\Views\CardCreate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView CardList;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\Views\CardCreate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Front;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\Views\CardCreate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Back;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\Views\CardCreate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddCard;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\Views\CardCreate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CardDeckName;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\..\Views\CardCreate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddDeck;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\..\Views\CardCreate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelDeck;
        
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
            System.Uri resourceLocater = new System.Uri("/Flash Cards;component/views/cardcreate.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\CardCreate.xaml"
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
            this.CardList = ((System.Windows.Controls.ListView)(target));
            return;
            case 2:
            this.Front = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Back = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.AddCard = ((System.Windows.Controls.Button)(target));
            
            #line 92 "..\..\..\Views\CardCreate.xaml"
            this.AddCard.Click += new System.Windows.RoutedEventHandler(this.AddCard_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.CardDeckName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.AddDeck = ((System.Windows.Controls.Button)(target));
            
            #line 117 "..\..\..\Views\CardCreate.xaml"
            this.AddDeck.Click += new System.Windows.RoutedEventHandler(this.AddDeck_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.CancelDeck = ((System.Windows.Controls.Button)(target));
            
            #line 128 "..\..\..\Views\CardCreate.xaml"
            this.CancelDeck.Click += new System.Windows.RoutedEventHandler(this.CancelDeck_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

