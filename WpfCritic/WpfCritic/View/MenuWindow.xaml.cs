﻿using System;
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
using System.Windows.Shapes;
using WpfCritic.ViewModel;

namespace WpfCritic.View
{
    public partial class MenuWindow : Window
    {

        private MenuWindowVM _viewModel = new MenuWindowVM();

        public MenuWindowVM ViewModel
        {
            get { return _viewModel; }
        }

        public MenuWindow()
        {
            InitializeComponent();

            DataContext = _viewModel;
        }

        private void moviesShowButton_Click(object sender, RoutedEventArgs e)
        {
            ((MenuWindowVM)DataContext).MoviesShowButtonClick();
            this.Close();
        }

        private void musicShowButton_Click(object sender, RoutedEventArgs e)
        {
            //музыку добавить
            this.Close();
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
