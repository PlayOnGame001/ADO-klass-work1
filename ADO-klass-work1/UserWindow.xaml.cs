using ADO_klass_work1.DAL.DTO;
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
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        private readonly User _user;
        public CrudActions SelectedAction;
        public UserWindow(User user)
        {
            InitializeComponent();
            _user = user;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IdTextBox.Text = _user.Id.ToString();
            NameTextBox.Text = _user.Name.ToString();
            LoginTextBox.Text = _user.Login.ToString();
            DkTextBox.Text = _user.PasswordHash.ToString();
            DateBirthdayPicker.SelectedDate = _user.BirthDate;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = null;
            this.Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedAction = CrudActions.Update;
            this.DialogResult = true;
        }

        private void DeletButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedAction = CrudActions.Delete;
            this.DialogResult = false;
        }
    }
}
