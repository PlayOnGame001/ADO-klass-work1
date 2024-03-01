using ADO_klass_work1.EfContext;
using ADO_klass_work1.EfCrudViews;
using ADO_klass_work1.Models;
using Microsoft.EntityFrameworkCore;
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

namespace ADO_klass_work1
{
    /// <summary>
    /// Interaction logic for EfCrudWindow.xaml
    /// </summary>
    public partial class EfCrudWindow : Window
    {
        public EfCrudWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            DepartmetsListView.ItemsSource = null;

            App.EfDataContext.Departments.Load();
            DepartmetsListView.ItemsSource =
                App.EfDataContext
                .Departments
                .Local
                .ToObservableCollection();
        }
        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(sender is ListViewItem item && item.Content is Department department) 
            {
                EfDepartmentCrudWindow dialog = new(DepartmentModel.FromEntity(department));
               dialog.ShowDialog();

                if(dialog.Action == CrudActions.Update)
                {
                    department.Name = dialog.Model.Name;
                    department.InternationlName = dialog.Model.InternationalName;
                    //App.EfDataContext.SaveChanges();
                    //App.EfDataContext.Update(department);
                    LoadData();
                }
                if (dialog.Action == CrudActions.Delete)
                {
                    department.DeleteDt = DateTime.Now;
                    App.EfDataContext.SaveChanges();
                    LoadData();
                }
            }
        }

        private void AddDepartmentButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
