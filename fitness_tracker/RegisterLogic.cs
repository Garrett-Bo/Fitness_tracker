using System;
using MySql.Data.MySqlClient;

namespace fitness_tracker
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
            // Username validation: only letters and numbers allowed
            foreach (char c in username)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    error = "Username can only contain letters and numbers (no special characters).";
                    return false;
                }
            }

            // Check if username and password are the same
            if (username.Equals(password, StringComparison.Ordinal))
            {
                error = "Username and password cannot be the same.";
                return false;
            }

            // Password validation: must contain uppercase, lowercase, and special character
            bool hasUppercase = false;
            bool hasLowercase = false;
            bool hasSpecialChar = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c))
                    hasUppercase = true;
                else if (char.IsLower(c))
                    hasLowercase = true;
                else if (!char.IsLetterOrDigit(c))
                    hasSpecialChar = true;
            }

            if (!hasUppercase)
            {
                error = "Password must contain at least one uppercase letter.";
                return false;
            }

            if (!hasLowercase)
            {
                error = "Password must contain at least one lowercase letter.";
                return false;
            }

            if (!hasSpecialChar)
            {
                error = "Password must contain at least one special character.";
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
                            error = $"Username '{username}' already exists.";
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
                catch (MySqlException ex)
                {
                    error = $"MySQL error {ex.Number}: {ex.Message}";
                    return false;
                }
                catch (Exception ex)
                {
                    error = $"General error: {ex.Message}";
                    return false;
                }
            }
        }
    }
}