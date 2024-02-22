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

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            foreach(var dep in App.EfDataContext.Departments)
            {
                Resultlabel.Content += $"{dep.Name} \n";
            }
            var query = App.EfDataContext
                .Departments
                .Where(d => d.InternationlName != null)
                .Take(10)
                .OrderBy(d => d.Name);
            foreach (var dep in query)
            {
                Resultlabel.Content += $"int - {dep.InternationlName} \n";
            }
            var query2 = App.EfDataContext
                .Departments
                .Select(d => d.Name);
            Resultlabel.Content += query2.Min();

            var query3 = App.EfDataContext
                .Departments
                .OrderBy(d => d.Id)
                .AsEnumerable()
                .Select(d => new { Card = d.Id.ToString()[..5] + d.Name })
                .OrderBy(a => a.Card)
                .First();
            Resultlabel.Content += query3.Card + "\n";
        }

        private void CheapButton_Click(object sender, RoutedEventArgs e)
        {
            Resultlabel.Content = App.EfDataContext 
                .Products
                .OrderBy(p => p.Price)
                .Select(p => p.Name + "" + "\n" + p.Price * 84.22111)
                .First();

           
        }
    }
}

/*Entity Framework Core - инструментарий для упрощения работы с данными, ориентированный на базы данных. 
 * 
 */