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
    /// Interaction logic for EfWindow.xaml
    /// </summary>
    public partial class EfWindow : Window
    {
        public EfWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ManagersCountLabel.Content = App.EfDataContext.Managers.Count();
            ProductCountLabel.Content = App.EfDataContext.Products.Count();
            SaleCountLabel.Content = App.EfDataContext.Sales.Count();
        }
    }
}

/*Entity Framework Core - инструментарий для упрощения работы с данными, ориентированный на базы данных. 
 * 
 */