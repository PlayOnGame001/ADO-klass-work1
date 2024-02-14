using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_klass_work1.DAL.DTO
{
    internal class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public DateTime? BirthDate { get; set; }

        public User() { }
        public User(Guid id, string name, string login, string passwordHash, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Login = login;
            PasswordHash = passwordHash;
            BirthDate = birthDate;
        }
        public User(DbDataReader reader)
        {
            Id = reader.GetGuid("Id");
            Name = reader.GetString("Name");
            Login = reader.GetString("Login");
            BirthDate = reader.IsDBNull("PasswordHash")
                ? null
                : reader.GetDateTime("BirthDate");
            PasswordHash = reader.GetString("PasswordHash");
        }
    }
}
