using System;
using MySql.Data.MySqlClient;

namespace Demo1
{
    public class GoalsettingLogic
    {
        private readonly string _connectionString;
        public GoalsettingLogic(string connectionString) { _connectionString = connectionString; }

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

        public int? GetOngoingGoalCalories(int userId)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT goal_calories FROM goals WHERE user_id = @userid AND status = 'ongoing'";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userid", userId);
                    object result = cmd.ExecuteScalar();
                    if (result == null) return null;
                    return Convert.ToInt32(result);
                }
            }
        }

        public bool SaveGoal(int userId, int goalCalories, out string error)
        {
            error = null;
            try
            {
                using (var conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    string update = "UPDATE goals SET status = 'completed' WHERE user_id = @userid AND status = 'ongoing'";
                    using (var cmd = new MySqlCommand(update, conn))
                    {
                        cmd.Parameters.AddWithValue("@userid", userId);
                        cmd.ExecuteNonQuery();
                    }
                    string insert = "INSERT INTO goals (user_id, goal_calories, status) VALUES (@userid, @goal, 'ongoing')";
                    using (var cmd = new MySqlCommand(insert, conn))
                    {
                        cmd.Parameters.AddWithValue("@userid", userId);
                        cmd.Parameters.AddWithValue("@goal", goalCalories);
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }
    }
}