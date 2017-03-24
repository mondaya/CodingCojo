using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using LoginReg.Models;
using LoginReg.Factory;

namespace DapperApp.Factory
{
    public class UserFactory : IFactory<User>
    {
        private string connectionString;
        public UserFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=8889;database=aspdb;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }


        public void Add(User item)
        {
            using (IDbConnection dbConnection = Connection) {
                string query =  "INSERT INTO users (first_name,last_name,email, password, created_at, updated_at) VALUES (@FirstName, @LastName, @Email, @Password, NOW(), NOW())";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
        public IEnumerable<User> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<User>("SELECT * FROM users");
            }
        }
        public User FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<User>("SELECT * FROM users WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public User FindByEmail(string email)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<User>("SELECT * FROM users WHERE email = @Email", new { Email = email }).FirstOrDefault();
            }
        }
    }
}