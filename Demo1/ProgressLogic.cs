using System;
using MySql.Data.MySqlClient;

namespace Demo1
{
    public class ProgressLogic
    {
        private readonly string _connectionString;
        public ProgressLogic(string connectionString) { _connectionString = connectionString; }

        public int? GetUserId(string username)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT id FROM users WHERE name = @username";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    object result = cmd.ExecuteScalar();
                    if (result == null) return null;
                    return Convert.ToInt32(result);
                }
            }
        }

        public float GetTotalCalories(int userId)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT COALESCE(SUM(calories), 0) FROM activities WHERE user_id = @userid";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userid", userId);
                    object result = cmd.ExecuteScalar();
                    if (result == null || result == DBNull.Value) return 0;
                    return Convert.ToSingle(result);
                }
            }
        }

        public float GetGoalCalories(int userId)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT goal_calories FROM goals WHERE user_id = @userid AND status = 'ongoing'";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userid", userId);
                    object result = cmd.ExecuteScalar();
                    if (result == null || result == DBNull.Value) return 0;
                    return Convert.ToSingle(result);
                }
            }
        }
    }
}