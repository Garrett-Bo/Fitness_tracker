using System;
using MySql.Data.MySqlClient;

namespace Demo1
{
    public class RegisterLogic
    {
        private readonly string _connectionString;
        public RegisterLogic(string connectionString) { _connectionString = connectionString; }

        public bool RegisterUser(string username, string password, out string error)
        {
            error = null;
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                error = "Username and password required.";
                return false;
            }
            using (var conn = new MySqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    string checkQuery = "SELECT COUNT(*) FROM users WHERE name = @name";
                    using (var cmd = new MySqlCommand(checkQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", username);
                        int exists = Convert.ToInt32(cmd.ExecuteScalar());
                        if (exists > 0)
                        {
                            error = "Username already exists.";
                            return false;
                        }
                    }
                    string insertQuery = "INSERT INTO users (name, password) VALUES (@name, @password)";
                    using (var cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    error = "Database error: " + ex.Message;
                    return false;
                }
            }
        }
    }
}