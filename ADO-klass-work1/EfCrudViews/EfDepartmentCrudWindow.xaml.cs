using ADO_klass_work1.EfContext;
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
    public partial class EfDepartmentCrudWindow : Window
    {   
        public DepartmentModel Model { get; init; } 
        public CrudActions Action { get; private set; }
       /* private readonly DepartmentModel model;*/
        public EfDepartmentCrudWindow(DepartmentModel model)
        {
            InitializeComponent();
            this.Model = model;
            this.DataContext = this;
            Action = CrudActions.None;
        }

        private void DeletButton_Click(object sender, RoutedEventArgs e)
        {
            Action = CrudActions.Delete;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Action = CrudActions.Update;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Action = CrudActions.None;
        }
    }
}
