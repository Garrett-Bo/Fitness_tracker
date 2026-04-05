using MySql.Data.MySqlClient;

namespace Demo1
{
    public class LoginLogic
    {
        private readonly string _connectionString;
        public LoginLogic(string connectionString) { _connectionString = connectionString; }

        public bool ValidateLogin(string username, string password, out string error)
        {
            error = null;
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                error = "Please enter both username and password.";
                return false;
            }
            using (var conn = new MySqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM users WHERE name = @name AND password = @password";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        int count = System.Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
                catch (System.Exception ex)
                {
                    error = "Database error: " + ex.Message;
                    return false;
                }
            }
        }
    }
}