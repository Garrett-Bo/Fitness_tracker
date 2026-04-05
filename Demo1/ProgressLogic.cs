using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Demo1
{
    public class ActivityLogEntry
    {
        public int ActivityId { get; set; }
        public int UserId { get; set; }
        public string ActivityType { get; set; }
        public float Metric1 { get; set; }
        public float Metric2 { get; set; }
        public float Metric3 { get; set; }
        public float DurationHours { get; set; }
        public float WeightKg { get; set; }
        public float Calories { get; set; }
        public DateTime Date { get; set; }
    }

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

        public List<ActivityLogEntry> GetActivities(int userId)
        {
            var activities = new List<ActivityLogEntry>();
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT activity_id, user_id, activity_type, metric1, metric2, metric3, duration_hours, weight_kg, calories, DATE_FORMAT(NOW(), '%Y-%m-%d') as date FROM activities WHERE user_id = @userid ORDER BY activity_type, date DESC";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userid", userId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            activities.Add(new ActivityLogEntry
                            {
                                ActivityId = reader.GetInt32(0),
                                UserId = reader.GetInt32(1),
                                ActivityType = reader.GetString(2),
                                Metric1 = reader.GetFloat(3),
                                Metric2 = reader.GetFloat(4),
                                Metric3 = reader.GetFloat(5),
                                DurationHours = reader.GetFloat(6),
                                WeightKg = reader.GetFloat(7),
                                Calories = reader.GetFloat(8),
                                Date = DateTime.Now // Placeholder, update to real date if available
                            });
                        }
                    }
                }
            }
            return activities;
        }
    }
}