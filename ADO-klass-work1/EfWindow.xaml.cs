using ADO_klass_work1.EfContext;
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
        private void DisplayStatistics()
        {
            ManagersCountLabel.Content = App.EfDataContext.Managers.Count();
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

        private async void SalestButton_Click(object sender, RoutedEventArgs e)
        {
            /*AddSales().ContinueWith((_) => DisplayStatistics());*/
            SaleCountLabel.Content = "Updating...";
            Task.Run(AddSales);
        }
        private async Task AddSales()
        {
            for (int i = 0; i < 1000; i++)
            {
                App.EfDataContext.Sales.Add(new EfContext.Sale()
                {
                    Id = Guid.NewGuid(),
                    ManagerId = App.EfDataContext.Managers.OrderBy(r => Guid.NewGuid()).First().Id,
                    ProductId = App.EfDataContext.Products.OrderBy(r => Guid.NewGuid()).First().Id,
                    Quantity = App.Random.Next(1, 10),
                    SaleDt = new DateTime(2023, 1, 1)
                    .AddDays(App.Random.Next(365))
                    .AddHours(App.Random.Next(9, 20))
                    .AddMinutes(App.Random.Next(0, 59))
                    .AddSeconds(App.Random.Next(0, 59))
                });
            }
           await App.EfDataContext.SaveChangesAsync();
           this.Dispatcher.Invoke(DisplayStatistics); // run
        }

        private void ProductSalesButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = new(2023, 02, 23);
            var query = App.EfDataContext.Products 
            .GroupJoin(
                App.EfDataContext.Sales,
                p => p.Id,
                s => s.ProductId,
                (product, sales) => new {Name = product.Name, 
                    Pcs = sales.Where(s => s.SaleDt.Date == date).Sum(s => s.Quantity)
                }
                );
            foreach (var item in query)
            {
                Resultlabel.Content += $"{item.Name} {item.Pcs} \n";
            }
        }

        private void NavButton1_Click(object sender, RoutedEventArgs e)
        {
            Resultlabel.Content = "";
            foreach(var man in
                App.EfDataContext
                .Managers
                .Include(m => m.MainDepartment)
                .Take(10))
            {
                Resultlabel.Content += $"{man.Surname} {man.MainDepartment.Name}\n";
            }
            Resultlabel.Content += "\n";
                foreach(var str in
                App.EfDataContext 
                .Departments
                .Include(d => d.MainWorkers)
                .Select(d => $"{d.Name} {d.MainWorkers.Count}"))
            {
                Resultlabel.Content += $"{str}\n";
            }
        }

        private void NavButton2_Click(object sender, RoutedEventArgs e)
        {
           /* Resultlabel.Content = "";
            foreach (var str in
                App.EfDataContext
                .Managers
                .Include(m => m.SecondaryWorkers)
                .Select(m => $"{m.Surname} {(m.SecondaryDepartment == null ? "--" : m.SecondaryDepartment.Name)}"))
                *//*.Take(10))*//*
            {
                Resultlabel.Content += $"{str}\n";
            }*/
        }

        private void ChiefButton_Click(object sender, RoutedEventArgs e)
        {
            Resultlabel.Content = "";
            foreach(Manager man in
            App.EfDataContext
                .Managers
                .Include(m => m.Chief))
            {
                Resultlabel.Content += $"{man.Surname} -- {man.Chief?.Surname ?? "NOOOOO!!!!"}\n";
            }
        }

        private void SubOrdinatesButton_Click(object sender, RoutedEventArgs e)
        {
            Resultlabel.Content = "";
            foreach (Manager man in
            App.EfDataContext
                .Managers
                .Include(m => m.Subordinates))
            {
                Resultlabel.Content += $"{man.Surname} -- {String.Join(",", man.Subordinates.Select(m=>m.Surname))}\n";
            }
        }

        private void SalesPrudButton_Click(object sender, RoutedEventArgs e)
        {
          /*  Resultlabel.Content = "";
            foreach (Product p in
            App.EfDataContext
                .Products
                .Include(p => p.Sales))
            {
                int cheksToday = p.Sales.Where(s => SalesDt.Date == date).Count();
                Resultlabel.Content += $"{p.Name} -- {checksToday}\n";
            }*/
        }
    }
}

/*Entity Framework Core - инструментарий для упрощения работы с данными, ориентированный на базы данных. 
 * 
 */