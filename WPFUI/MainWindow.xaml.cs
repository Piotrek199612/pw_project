﻿using System.Collections.Generic;
using System.Windows;
using Sturmer.AircraftCompany.Interfaces;

namespace Sturmer.AircraftCompany.WPFUI
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
    
        public MainWindow()
        {
            BL.BL bl = new BL.BL(Properties.Settings.Default.LibraryName);
            InitializeComponent();
        }
    }
}
