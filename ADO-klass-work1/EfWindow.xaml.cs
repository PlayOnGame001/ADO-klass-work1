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

        private void SalesTodayProdButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = new(2023, 03, 02);
            Resultlabel.Content = "";
            foreach (Product p in
                    App.EfDataContext
                        .Products
                        .Include(p => p.Sales
                        .Where(s => s.SaleDt.Date == date)))
            {
                int checksToday = p.Sales.Count();
                int quantity = p.Sales.Select(s => s.Quantity).Sum();
                float totalCost = (float)p.Sales.Select(s => s.Quantity * s.Product.Price).Sum();

                Resultlabel.Content += $"{p.Name}" +
                    $"{(p.Name.Length > 16 ? "\t" : "\t\t")}" +
                    $"-- {checksToday} чеків \t--  {quantity} шт.  \t--  {totalCost} грн.\n";
            }
        }

        private void SalesProdButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = new(2023, 03, 02);
            Resultlabel.Content = "";
            foreach (Product p in
                 App.EfDataContext
                    .Products
                    .Include(p => p.Sales))
            {
                int checksToday = p.Sales.Where(s => s.SaleDt.Date == date).Count();
                Resultlabel.Content += $"{p.Name} -- {checksToday}\n";
            }
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            Resultlabel.Content = "";
            var shortestProduct = App.EfDataContext
            .Products
            .Select(p => p.Name)
            .Min();
            var random = new Random();
            var randomManagerIndex = random.Next(0, App.EfDataContext.Managers.Count());
            var randomProductIndex = random.Next(0, App.EfDataContext.Products.Count());

            var randomManager = App.EfDataContext
                .Managers
                .OrderBy(e => e.Id)
                .Skip(randomManagerIndex)
                .FirstOrDefault();

            var randomProduct = App.EfDataContext
                .Products
                .OrderBy(p => p.Id)
                .Skip(randomProductIndex)
                .FirstOrDefault();

            var randomSaleDate = new DateTime(
                2023, random.Next(1, 13), random.Next(1, 29),
                random.Next(9, 20), random.Next(0, 60), random.Next(0, 60));

            Resultlabel.Content += $"Товар з найкоротшою назвою --- {shortestProduct}\n" +
                                   $"Випадковий товар --- {randomProduct.Name} --- {randomProduct.Price} грн\n" +
                                   $"Випадковий менеджер --- {randomManager.Surname} {randomManager.Name}\n" +
                                   $"Випадковий час продажу --- {randomSaleDate}";
        }

        private void Manager_Click(object sender, RoutedEventArgs e)
        {
            Resultlabel.Content = "";

            DateTime date = DateTime.Now.AddYears(-1).Date;
            //StatisticLabel.Content += $"Статистика за {date.ToShortDateString()} число\n";

            /* Вивести статистику продажів по менеджерах за "сьогодні" -
               тільки за торік (2023) */
            var query = App.EfDataContext.Managers                   // FROM Managers M
                .GroupJoin(
                    App.EfDataContext.Sales,                         // LEFT JOIN Sales S
                    m => m.Id,                                       // ON M.Id =
                    s => s.ManagerId,                                //      S.ManagerId
                    (manager, sales) => new                          // GROUP BY M
                    {
                        Name = manager.Surname + ' ' + manager.Name, // SELECT E.Name AS Name,
                        TotalSales = sales                           // SUM(S.Quantity) AS TotalSales
                        .Where(s => s.SaleDt.Date == date)           // WHERE S.SaleDate.Date = today
                        .Sum(s => s.Quantity),
                    }
                );

            foreach (var item in query)
            {
                Resultlabel.Content += $"{item.Name} --- {item.TotalSales}\n";
            }
        }

    }
}

/*Entity Framework Core - инструментарий для упрощения работы с данными, ориентированный на базы данных. 
 * 
 */