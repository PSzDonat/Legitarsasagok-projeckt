﻿using PushToWin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Legitarsasagok_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindowModel context = new MainWindowModel();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = context;
            MainWindow.context.MakeVisible("Page1");
            this.PreviewKeyDown += new KeyEventHandler(HandleKeyboard);
        }
        private void HandleKeyboard(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape) MainWindow.context.MakeVisible("Page1");
        }
    }
}
