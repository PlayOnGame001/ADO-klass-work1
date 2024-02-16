using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Windows;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace ADO_klass_work1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static void LogError(String message, [CallerMemberName] string callerName="undefined")
        {
            System.IO.File.AppendAllText("logs.txt", $"{DateTime.Now} [{callerName}] {message}\n");

        }
        public static SqlConnection? _msConnection;
        public static SqlConnection MsSqlConnection
        {
            get
            {
                if (_msConnection == null)
                {
                    _msConnection = new(
                    JsonSerializer.Deserialize<JsonElement>(
                    System.IO.File.ReadAllText("appsettings.json")
                    )
                        .GetProperty("ConnectionStrings")
                        .GetProperty("LocalMS")
                        .GetString()!
                    );
                    _msConnection.Open();
                }
                return _msConnection;
            }
        }
        public static MySqlConnection? mySqlConnection;
        public static MySqlConnection MySqlConnection
        {
            get
            {
                if (mySqlConnection == null)
                {
                    try
                    {
                        mySqlConnection = new(
                            JsonSerializer.Deserialize<JsonElement>(
                            System.IO.File.ReadAllText("appsettings.json")
                            )
                            .GetProperty("ConnectionStrings")
                            .GetProperty("LocalMy")
                            .GetString()!
                            );
                        mySqlConnection.Open();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                return mySqlConnection;
            }
        }

        public static string md5(String imput)
        {
            return Convert.ToHexString(
                System.Security.Cryptography.MD5.HashData(
                    System.Text.Encoding.UTF8.GetBytes(imput)));
        }
    }
}
