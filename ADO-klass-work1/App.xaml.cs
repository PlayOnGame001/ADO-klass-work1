using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json;
using System.Windows;

namespace ADO_klass_work1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static SqlConnection? _msConnection;
        public static SqlConnection MsSqlConnection
        {
            get
            {
                if( _msConnection == null)
                {
                    _msConnection = new (
                     JsonSerializer.Deserialize<JsonElement>(
                     System.IO.File.ReadAllText("appsettings.json"))
                 .GetProperty("ConnectionString")
                 .GetProperty("LocalMs")
                 .GetString()!
                 );
                    _msConnection.Open();
                }
                return _msConnection;
            }
        }

        public static String md5(String input)
        {
            return Convert.ToHexString(
            System.Security.Cryptography.MD5.HashData(
                System.Text.Encoding.UTF8.GetBytes(input)));
        }
    }

}
