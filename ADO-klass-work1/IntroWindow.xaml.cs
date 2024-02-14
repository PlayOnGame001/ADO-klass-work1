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
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Text.Json;
using System.Security.Cryptography;
using System.Data;
using System.Reflection.PortableExecutable;

namespace ADO_klass_work1
{

    public partial class IntroWindow : Window
    {
        private readonly String _myConnectionString;
        private readonly String _msConnectionString;
        SqlConnection? msConnection;
        MySqlConnection? mySqlConnection;

        public IntroWindow()
        {
            InitializeComponent();

            var config = JsonSerializer.Deserialize<JsonElement>(
                System.IO.File.ReadAllText("appsettings.json"));


            var connectionStrings = config
                .GetProperty("ConnectionStrings");

            /* _msConnectionString = connectionStrings
                 .GetProperty("LocalMs")
                 .GetString()!;*/

            _myConnectionString = connectionStrings
                .GetProperty("LocalMy")
                .GetString()!;
        }

        private void ConnectMsButton_Click(object sender, RoutedEventArgs e)
        {
            /*MsSqlConnection myConnection = new(_msConnectionString);
            try
            {
                myConnection.Open();
                MsConnectionStatusLabel.Content = "Connected";
            }
            catch (Exception ex) 
            {
                MsConnectionStatusLabel.Content = ex.Message;
            }*/
        }

        private void ConnectMyButton_Click(object sender, RoutedEventArgs e)
        {

            mySqlConnection = new(_myConnectionString);
            try
            {
                mySqlConnection.Open();
                MyConnectionStatusLabel.Content = "Connected";
            }
            catch (Exception ex)
            {
                MyConnectionStatusLabel.Content = ex.Message;
            }
        }
        private string? GetInputError()
        {
            if (string.IsNullOrEmpty(UserNameTextBox.Text))
            {
                return "Fill Name box";
            }

            if (string.IsNullOrEmpty(UserLoginTextBox.Text))
            {
                return "Fill Login box";
            }

            if (BirthDatePicker.SelectedDate == null)
            {
                return "Fill BirthDate Box";
            }

            if (string.IsNullOrEmpty(UserPasswordTextBox.Password))
            {
                return "Fill Password box";
            }

            return null;
        }
        private String md5(String input)
        {
            return Convert.ToHexString(
            System.Security.Cryptography.MD5.HashData(
                System.Text.Encoding.UTF8.GetBytes(input)));
        }


        private string Md5(string Input)
        {
            return Convert.ToHexString(MD5.HashData(Encoding.UTF8.GetBytes(Input)));
        }

        private void CreateMsButton_Click(object sender, RoutedEventArgs e)
        {
            /*SqlCommand cmd = new();
            cmd.Connection = msConnection;
            cmd.CommandText = @"
                                CREATE TABLE USERS (Id UNIQEUIDENTIFIER PRIMARY KEY,
                                Name NVARCHAR(64)  NOT NULL,
                                Login NVARCHAR(64) NOT NULL,
                                PasswordHash char(32)  NOT NULL
                                )";
            try
            {
                cmd.ExecuteNonQuery();
                MsCreateStatusLabel.Content = "Execute OK";
            }
            catch 
            {
                MsCreateStatusLabel.Content = ex.Message;
            }*/
        }

        private void CreateMyButton_Click(object sender, RoutedEventArgs e)
        {
            using MySqlCommand cmd = new();
            cmd.Connection = mySqlConnection;
            cmd.CommandText = @"
                                CREATE TABLE USERS (Id CHAR(36) PRIMARY KEY,
                                Name NVARCHAR(64)  NOT NULL,
                                Login NVARCHAR(64) NOT NULL,
                                PasswordHash char(32)  NOT NULL
                                )Engine = InnoDb, DEFAULT CHARSET = utf8mb4";
            try
            {
                cmd.ExecuteNonQuery();
                MyCreateStatusLabel.Content = "Create OK";
            }
            catch (Exception ex)
            {
                MyCreateStatusLabel.Content = ex.Message;
            }
        }

        private void InsertMyButton_Click(object sender, RoutedEventArgs e)
        {
            string? ErrorMessage = GetInputError();

            if (ErrorMessage != null)
            {
                MessageBox.Show(ErrorMessage);

                return;
            }

            using MySqlCommand Cmd = new($"INSERT INTO Users VALUES(UUID(), '{UserNameTextBox.Text}', '{UserLoginTextBox.Text}', '{Md5(UserPasswordTextBox.Password)}')", mySqlConnection);
            Cmd.Parameters.Add(new MySqlParameter("name", MySqlDbType.VarChar, 64)
            {
                Value = UserNameTextBox.Text,
            });
            Cmd.Parameters.Add(new MySqlParameter("@login", MySqlDbType.VarChar, 64)
            {
                Value = UserLoginTextBox.Text
            });
            Cmd.Parameters.Add(new MySqlParameter("@birthdate", MySqlDbType.DateTime, 64)
            {
                Value = BirthDatePicker.SelectedDate
            });
            try
            {
                Cmd.Prepare();
                Cmd.ExecuteNonQuery();
                InsertStatusLabel.Content = "Insert OK";
            }
            catch (Exception Ex)
            {
                InsertStatusLabel.Content = Ex.Message;
            }
        }

        private void SelectMsButton_Click(object sender, RoutedEventArgs e)
        {/*
            if (msConnection == null || msConnection.State == System.Data.ConnectionState.Closed)
            {
                MessageBox.Show("Проверьте соединение", "Выполнение прекращенно", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            using SqlCommand cmd = new("SELECT * FROM * Users", msConnection);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                //Reader - отображение таблицы (с свободным количеством полей). Его схема работы запрос данных по одному ряду. Метод .Read() передает ряд данных в объект reader,
                //после чего данные полей ряда доступные
                //а) по ключу reader["id"]
                //b) с помощью get-теров reader.GetGuid("id") (->Guid)
                //Для перехода на следуйщий ряд снова добавляеться команда .Read() когда данные закончатся, вызывает Read() проверку false 
                SelectMsTextBlock.Text = "";
                while (reader.Read())
                {
                    var id = reader.GetGuid("id").ToString();
                    var name = reader.GetString("name");
                    var login = reader.GetString("login");
                    var hash = reader.GetString("PasswordHash");
                    SelectMsTextBlock.Text += $"{id[..5]}... {name} {login} {hash[..5]}...\n";
                }
            }
            catch (Exception Ex)
            {
                SelectMsTextBlock.Text = Ex.Message;
            }*/
        }

        private void SelectMyButton_Click(object sender, RoutedEventArgs e)
        {
            if (mySqlConnection == null || mySqlConnection.State == System.Data.ConnectionState.Closed)
            {
                MessageBox.Show("Проверьте соединение", "Выполнение прекращенно", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            using MySqlCommand cmd = new("SELECT * FROM Users", mySqlConnection);
            try
            {
                using MySqlDataReader reader = cmd.ExecuteReader();
                SelectMyTextBlock.Text = "";

                //Reader - отображение таблицы (с свободным количеством полей). Его схема работы запрос данных по одному ряду. Метод .Read() передает ряд данных в объект reader,
                //после чего данные полей ряда доступные
                //а) по ключу reader["id"]
                //b) с помощью get-теров reader.GetGuid("id") (->Guid)
                //Для перехода на следуйщий ряд снова добавляеться команда .Read() когда данные закончатся, вызывает Read() проверку false 
                //!!После использования reader необходимо закрыть (Или добавить using при создании) 
                while (reader.Read())
                {
                    var id = reader.GetGuid("id");
                    var name = reader.GetString("name");
                    var login = reader.GetString("login");
                    string Birthdate = reader.GetDateTime("BirthDate").ToShortDateString();
                    var hash = reader.GetString("PasswordHash");
                    SelectMyTextBlock.Text += $"{id.ToString()[..5]}... {name} {login} {hash[..5]}...\n";
                }
            }
            catch (Exception Ex)
            {
                SelectMyTextBlock.Text = Ex.Message;
            }
        }
        private void BirthDatePicker_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
    /* private void InsertMsButton_Click_test(object sender, RoutedEventArgs e)
     {
         string? ErrorMessage = GetInputError();

         if (ErrorMessage != null)
         {
             MessageBox.Show(ErrorMessage);

             return;
         }

         using SqlCommand Cmd = new($"INSERT INTO Users VALUES(NEWID(), @name, @login, '{Md5(UserPasswordTextBox.Password)}')", msConnection);

         Cmd.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, 64)
         {
             Value = UserNameTextBox.Text
         });

         Cmd.Parameters.Add(new SqlParameter("@login", SqlDbType.VarChar, 64)
         {
             Value = UserLoginTextBox.Text
         });

         try
         {
             Cmd.Prepare();
             Cmd.ExecuteNonQuery();

             InsertStatusLabel.Content = "Insert OK";
         }
         catch (Exception Ex)
         {
             InsertStatusLabel.Content = Ex.Message;
         }
     }*/
}


