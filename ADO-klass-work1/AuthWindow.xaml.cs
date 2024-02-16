using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private String? GetInputError()
        {
            if (String.IsNullOrEmpty(RegName.Text))
            {
                return "Fill Name box";
            }
            if (String.IsNullOrEmpty(RegLogin.Text))
            {
                return "Fill Login box";
            }
            if (String.IsNullOrEmpty(RegPassword.Password))
            {
                return "Fill Password box";
            }
            if (RegPassword.Password != RegRepeat.Password)
            {
                return "Passwords mismatch";
            }
            return null;
        }


       /* private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            var errorMessage = GetInputError();
            if (errorMessage != null)
            {
                MessageBox.Show(errorMessage, "Выполнение прекращенно", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            using var cmd = new SqlCommand($"INSERT INTO Users VALUES( NEWID(), @name, @login, '{App.md5(RegPassword.Password)}' )", App.MsSqlConnection);
            cmd.Parameters.Add(new SqlParameter("@name", System.Data.SqlDbType.VarChar, 64)
            {
                Value = RegName.Text
            });
            cmd.Parameters.Add(new SqlParameter("@login", System.Data.SqlDbType.VarChar, 64)
            {
                Value = RegLogin.Text
            });
            try
            {
                cmd.Prepare();  // підготовка запиту - компіляція без параметрів
                cmd.ExecuteNonQuery();  // виконання - передача даних у скомпільований запит
                MessageBox.Show("Insert OK");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }*/

        private void Login_Button(object sender, RoutedEventArgs e)
        {

        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
              var errorMessage = GetInputError();
            if (errorMessage != null)
            {
                MessageBox.Show(errorMessage,
                    "Виконання зупинене",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }
            using var cmd = new MySqlCommand(
                $"INSERT INTO Users VALUES( UUID(), @name, @login, @birthdate, '{App.md5(RegPassword.Password)}' )",
                App.MySqlConnection);
            cmd.Parameters.Add(new MySqlParameter("@name", MySqlDbType.VarChar, 64)
            {
                Value = RegName.Text
            });
            cmd.Parameters.Add(new MySqlParameter("@login", MySqlDbType.VarChar, 64)
            {
                Value = RegLogin.Text
            });
            cmd.Parameters.Add(new MySqlParameter("@birthdate", MySqlDbType.VarChar, 64)
            {
                Value = BirthDatePicker.SelectedDate.Value.ToShortDateString()
            });
            //using var cmd = new MySqlCommand(
            //    $"INSERT INTO Users VALUES( UUID(), '{RegName.Text}',
            try
            {
                cmd.Prepare();  // підготовка запиту - компіляція без параметрів
                cmd.ExecuteNonQuery();  // виконання - передача даних у скомпільований запит
                MessageBox.Show("Insert OK");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}


/*
 CRUD - Create Read Update Delete 
 -жизненный цикл данных 
 -перечисление необходимых операций для полноты системы что рабоатет с данными. 
 -CRUD - полнота требований к системе что до её функциональности 
 
 ORM. DAO. DAL.
 Object Relation Mapping (ORM) - отображения (Maping) 
 данных и связей между ними (Relation) на объекты. Другими словами, создание объектов языка программирования которые за структурой максимально приблеженные 
 к данным, которые находят к программам (БД, JSON, другие) такие объекты известны как DTO (data transfer object) или Entity 
 Работа с данными переводиться к работе с объектами.
 Образует переход способа - DAO (data access object)
 UserDao.CreateUser(UserDto.GatAll)
 List<UserDto>UserDao.GatAll()
 Совокупность DAO для разных данных образует DAL (data access layer) -
 архитектура шар работает, также известный как контекст данных 
 */
//Подключения разных ресурсов (окон)
//Подключение к бд - достаточно сложный ресур и открывать 
//несколько подключений к одной БД - потеря ресурсов. 
// = с одной стороны, сама платформа .NET контролирует подключение и про попытки открыть новое подключение с теми ж данными, что и подсчетом открытых подключений, 
// вернет направление на видный объект( не будет открывать новое подключение) 
// = С другой стороны, не все платформы обеспечивают такой контроль и архитектуру программы имеет от начала строиться правильно без команд повторного открытия подключений. 
