using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ADO_klass_work1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new IntroWindow().ShowDialog();
            this.Show();
        }

        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new AuthWindow().ShowDialog();
            this.Show();
        }
    }
}