using ADO_klass_work1.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ADO_klass_work1.DAL.DAO
{
    internal class UserDao
    {
        public static bool UpdateUser(User user)
        {
            ArgumentNullException.ThrowIfNull(user);
            if(user.Id == default) //можно улучшить и проверять наличие в БД.
            {
                throw new ArgumentException("Id field value must not be default", "user.Id");
            }
            using var cmd = new SqlCommand(
            $"UPDATE Users SET  Name=@name, Login=@login, BirthDate=@birthDate, PasswordHash=@passHash" +
            $"WHERE Id=@id",
            App.MsSqlConnection);
            cmd.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.UniqueIdentifier)
            {
                Value = user.Id
            });
            cmd.Parameters.Add(new SqlParameter("@name", System.Data.SqlDbType.VarChar, 64)
            {
                Value = user.Name
            });
            cmd.Parameters.Add(new SqlParameter("@login", System.Data.SqlDbType.VarChar, 64)
            {
                Value = user.Login
            });
            cmd.Parameters.Add(new SqlParameter("@birthdate", System.Data.SqlDbType.DateTime, 64)
            {
                Value = user.BirthDate
            });
            cmd.Parameters.Add(new SqlParameter("@passHash", System.Data.SqlDbType.Char, 32)
            {
                Value = user.PasswordHash
            });
            try
            {
                cmd.Prepare();
                cmd.ExecuteNonQuery(); 
                return true;
            }
            catch (Exception ex)
            {
                App.LogError(ex.Message);
                return false;
            }
            return true;
        }
        public static List<User> GetAll()
        {
            using SqlCommand cmd = new("SELECT * FROM Users", App.MsSqlConnection);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<User> users = new();
                while (reader.Read())
                {
                    users.Add(new User(reader));
                }
                return users;
            }
            catch (Exception ex)
            {
                return null!;
            }
        }
        public static bool AddUser(User user)
        {
            ArgumentNullException.ThrowIfNull(user);
            using var cmd = new SqlCommand(
                $"INSERT INTO Users(Id, Name, Login, BirthDate, PasswordHash)" +
                $"VALUES( NEWID(), @name, @login, @birthdate, @passHash)",
                App.MsSqlConnection);
            cmd.Parameters.Add(new SqlParameter("@name", System.Data.SqlDbType.VarChar, 64)
            {
                Value = user.Name
            });
            cmd.Parameters.Add(new SqlParameter("@login", System.Data.SqlDbType.VarChar, 64)
            {
                Value = user.Login
            });
            cmd.Parameters.Add(new SqlParameter("@birthdate", System.Data.SqlDbType.DateTime, 64)
            {
                Value = user.BirthDate
            });
            cmd.Parameters.Add(new SqlParameter("@passHash", System.Data.SqlDbType.Char, 32)
            {
                Value = user.PasswordHash
            });
            try
            {
                cmd.Prepare(); // підготовка запиту - компіляція без параметрів
                cmd.ExecuteNonQuery(); // виконання - передача данних у скомпільований запит
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static User? GetUserByCredentials(string login, string password)
        {
            ArgumentNullException.ThrowIfNull(login);
            ArgumentNullException.ThrowIfNull(password);
            using var cmd = new SqlCommand(
                "SELECT * FROM Users u WHERE u.login = @login",
                App.MsSqlConnection);
            cmd.Parameters.Add(new SqlParameter("@login", System.Data.SqlDbType.VarChar, 64)
            {
                Value = login
            });
            try
            {
                cmd.Prepare();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    //ДЗ Забезпечити перевірку паролю, підключити My, у разі виявлення користувача за даними логіну
                    return new User(reader);
                }
                else // юзер не знайдений
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}