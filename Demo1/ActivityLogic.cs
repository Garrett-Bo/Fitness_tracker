using System;
using MySql.Data.MySqlClient;

namespace Demo1
{
    public class ActivityLogic
    {
        private readonly string _connectionString;
        public ActivityLogic(string connectionString) { _connectionString = connectionString; }

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

        public bool SaveActivity(int userId, string activityType, float metric1, float metric2, float metric3, out string error)
        {
            error = null;
            try
            {
                using (var conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    string insert = "INSERT INTO activities (user_id, activity_type, metric1, metric2, metric3, calories) VALUES (@userid, @type, @m1, @m2, @m3, @calories)";
                    using (var cmd = new MySqlCommand(insert, conn))
                    {
                        cmd.Parameters.AddWithValue("@userid", userId);
                        cmd.Parameters.AddWithValue("@type", activityType);
                        cmd.Parameters.AddWithValue("@m1", metric1);
                        cmd.Parameters.AddWithValue("@m2", metric2);
                        cmd.Parameters.AddWithValue("@m3", metric3);
                        // For demo, calories = metric2 (time) * 5
                        cmd.Parameters.AddWithValue("@calories", metric2 * 5);
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