﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using WpfStorage.ViewModels;

namespace WpfStorage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel(this);
        }
    }
}
