﻿using System.Reflection;
using AssemblyBrowser;

namespace SPP_LAB3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new AssemblyBrowserViewModel();
        }    
    }
}