using ADO_klass_work1.EfContext;
using ADO_klass_work1.EfCrudViews;
using ADO_klass_work1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private ICollectionView departmentsView;
        private readonly Predicate<Object> departmentsFilter = obj => (obj as Department)?.DeleteDt == null;
        public EfCrudWindow()
        {
            InitializeComponent();

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
            LoadProdData();
            LoadMangersData();
        }
        private void LoadMangersData()
        {
            ManagersListView.ItemsSource = null;
            App.EfDataContext.Managers.Load();
            ManagersListView.ItemsSource = App.EfDataContext.Managers.Local.ToObservableCollection();
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
            departmentsView = CollectionViewSource.GetDefaultView(DepartmetsListView.ItemsSource);
            departmentsView.Filter = obj => (obj as Department)?.DeleteDt == null;
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
        private void LoadProdData()
        {
            ProductListView.ItemsSource = null;

            App.EfDataContext.Products.Load();

            ProductListView.ItemsSource = App.EfDataContext
                .Products
                .Local
                .ToObservableCollection();
        }
        private void AddDepartmentButton_Click(object sender, RoutedEventArgs e)
        {
            Department department = new()
            {
                Id = Guid.NewGuid(),
            };
            EfDepartmentCrudWindow dialog = new(DepartmentModel.FromEntity(department));
            dialog.ShowDialog();
            if (dialog.Action == CrudActions.Update)
            {
                department.Name = dialog.Model.Name;
                department.InternationlName = dialog.Model.InternationalName;
                App.EfDataContext.Add(department);
                App.EfDataContext.SaveChanges();
                LoadData();
            }
        }

        private void AllDepartmensButton_Click(object sender, RoutedEventArgs e)
        {
            departmentsView.Filter = departmentsView.Filter == null
            ? departmentsFilter : null;
        }

        private void AddManagers_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AllManagers_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListViewItem_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            if(sender is ListViewItem item && item.Content is Manager manager)
            {
                EfManagerCrudWindow dialog = new( new ManagerModel(manager)
                {
                    Departments = App.EfDataContext.Departments.Select(d=> new IdName { Id=d.Id, Name =d.Name}).ToList(),
                   
                });
                dialog.ShowDialog();
            }
        }

        private void DepartmetsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ProductListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
