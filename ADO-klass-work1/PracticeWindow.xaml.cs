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
    /// Interaction logic for PracticeWindow.xaml
    /// </summary>
    public partial class PracticeWindow : Window
    {
        public PracticeWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DateTime data = DateTime.Today.AddYears(-1).Date;

            ///////1
            Questable_label.Content = "";
            DateTime MinSale = App.EfDataContext.Sales
                .Where(s => s.SaleDt.Date == data)
                .Min(s => s.SaleDt);
            Questable_label.Content = MinSale.TimeOfDay.ToString();

            ////////2
            Questable_label2.Content = "";
            DateTime MaxSale = App.EfDataContext.Sales
                .Where(s => s.SaleDt.Date == data)
                .Max(s => s.SaleDt);
            Questable_label2.Content = MaxSale.TimeOfDay.ToString();

            ////////3 (max)
            int MaxProd = App.EfDataContext.Sales
            .Where(s => s.SaleDt.Date == data)
            .Max(s => s.Quantity);
            Questable_label3.Content = MaxProd;

            ///////4(среденее midle)
            int MidleProduct = (int)App.EfDataContext.Sales
            .Where(s => s.SaleDt.Year == data.Year && s.SaleDt.Month == data.Month && s.SaleDt.Day == data.Day)
            .Select(s => s.Quantity)
            .Average();
            Questable_label4.Content = MidleProduct;

            ///////5(среденее midle)
            int Check = (int)Math.Round(App.EfDataContext.Sales
                .Where(s => s.SaleDt.Date == data)
                .Select(s => s.Quantity * s.Product.Price)
                .Average());
            Questable_label5.Content = Check;
        }
    }
}
