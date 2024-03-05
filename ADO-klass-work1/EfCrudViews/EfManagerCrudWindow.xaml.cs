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

        private void DeletButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
