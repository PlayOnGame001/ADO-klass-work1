using ADO_klass_work1.DAL.DAO;
using ADO_klass_work1.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for CrudWindow.xaml
    /// </summary>
    public partial class CrudWindow : Window
    {
        public ObservableCollection<User> Users { get; set; }
        public CrudWindow()
        {
            Users = [];
            this.DataContext = Users;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (User user in UserDao.GetAll())
            {
                Users.Add(user);
            }
        }
       private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
       {
          if (sender is ListViewItem item)
          {
            if (item.Content is User user)
            {
                    UserWindow dialog = new(user);
                    dialog.ShowDialog();
                    switch (dialog.SelectedAction)
                    {
                        case CrudActions.Delete: DeletUser(user); break;
                        case CrudActions.Update: UpdateUser(user); break;
                    }
            }
          }
       }
        private void DeletUser(User user)
        {

        }
        private void UpdateUser(User user)
        {
            if (UserDao.UpdateUser(user))
            {
                MessageBox.Show("Успешнон обновление");
            }
            else
            {
                MessageBox.Show("Операция отменина");
            }
        }
    }
}
//Не писать SQL в окнах не в каком случае!!!