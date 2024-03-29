﻿using ADO_klass_work1.EfContext;
using ADO_klass_work1.Models;
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
using System.Windows.Shapes;


namespace ADO_klass_work1.EfCrudViews
{
    /// <summary>
    /// Interaction logic for EfManagerCrudWindow.xaml
    /// </summary>
    public partial class EfManagerCrudWindow : Window
    {
         public ManagerModel Model { get; init; }
         public CrudActions Action { get; private set; }
         public EfManagerCrudWindow(ManagerModel model)
         {
        InitializeComponent();
        this.Model = model;
        this.DataContext = this;
        Action = CrudActions.None;
         }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainDepComboBox.SelectedItem = this.Model.Departments.First(idName => idName.Id == Model.MainDep.Id);
            if(Model.SecDep != null) 
            {
                SecDepComboBox.SelectedItem = this.Model.Departments.First(idName => idName.Id == Model.SecDep.Id);
            }

            if(Model.Chef != null)
            {
                CheifComboBox.SelectedItem = Model.Chiefs.First(m => m.Id == Model.Chef.Id);
            }
        }
        private void DeletButton_Click(object sender, RoutedEventArgs e)
        {
            Action = CrudActions.Delete;
            Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Action = CrudActions.Update;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Action = CrudActions.None;
            Close();
        }

        private void ClearSecDep_Click(object sender, RoutedEventArgs e)
        {
            SecDepComboBox.SelectedItem = null;
        }

        private void CheifComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Model.Chef = CheifComboBox.SelectedItem as IdName;
        }

        private void CheifBoxClear_Click(object sender, RoutedEventArgs e)
        {
            CheifComboBox.SelectedIndex = -1;
        }

        private void SecDepComboBox_Selected(object sender, RoutedEventArgs e)
        {
            Model.SecDep = SecDepComboBox.SelectedItem as IdName;
        }

        private void MainDepComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Model.MainDep = (IdName)MainDepComboBox.SelectedItem;
        }

    }
}
