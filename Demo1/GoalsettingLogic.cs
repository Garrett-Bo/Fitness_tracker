using System;
using MySql.Data.MySqlClient;

namespace Demo1
{
    public class GoalResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public bool IsNewGoal { get; set; }
        public int GoalCalories { get; set; }
    }

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
            try
            {
                using (var conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = "SELECT goal_calories FROM goals WHERE user_id = @userid AND status = 'ongoing'";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userid", userId);
                        object result = cmd.ExecuteScalar();
                        if (result == null || result == DBNull.Value)
                        {
                            return null;
                        }
                        return Convert.ToInt32(result);
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        public GoalResult SaveGoal(int userId, int goalCalories)
        {
            try
            {
                // Validate inputs
                if (userId <= 0)
                {
                    return new GoalResult
                    {
                        Success = false,
                        Message = "Error: Invalid user ID",
                        IsNewGoal = false,
                        GoalCalories = 0
                    };
                }

                if (goalCalories <= 0)
                {
                    return new GoalResult
                    {
                        Success = false,
                        Message = "Error: Goal calories must be greater than 0",
                        IsNewGoal = false,
                        GoalCalories = 0
                    };
                }

                using (var conn = new MySqlConnection(_connectionString))
                {
                    try
                    {
                        conn.Open();
                    }
                    catch (Exception connEx)
                    {
                        return new GoalResult
                        {
                            Success = false,
                            Message = $"Error: Cannot connect to database - {connEx.Message}",
                            IsNewGoal = false,
                            GoalCalories = 0
                        };
                    }

                    // Check if user has an existing ongoing goal
                    string checkQuery = "SELECT COUNT(*) FROM goals WHERE user_id = @userid AND status = 'ongoing'";
                    int existingGoalCount = 0;
                    try
                    {
                        using (var cmd = new MySqlCommand(checkQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@userid", userId);
                            object result = cmd.ExecuteScalar();
                            if (result != null && result != DBNull.Value)
                            {
                                existingGoalCount = Convert.ToInt32(result);
                            }
                        }
                    }
                    catch (Exception checkEx)
                    {
                        return new GoalResult
                        {
                            Success = false,
                            Message = $"Error: Cannot check existing goal - {checkEx.Message}",
                            IsNewGoal = false,
                            GoalCalories = 0
                        };
                    }

                    bool isNewGoal = existingGoalCount == 0;

                    // Update old goal if exists
                    if (!isNewGoal)
                    {
                        try
                        {
                            string update = "UPDATE goals SET status = 'completed' WHERE user_id = @userid AND status = 'ongoing'";
                            using (var cmd = new MySqlCommand(update, conn))
                            {
                                cmd.Parameters.AddWithValue("@userid", userId);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        catch (Exception updateEx)
                        {
                            return new GoalResult
                            {
                                Success = false,
                                Message = $"Error: Cannot update old goal - {updateEx.Message}",
                                IsNewGoal = false,
                                GoalCalories = 0
                            };
                        }
                    }

                    // Insert new goal
                    try
                    {
                        string insert = "INSERT INTO goals (user_id, goal_calories, status) VALUES (@userid, @goal, 'ongoing')";
                        using (var cmd = new MySqlCommand(insert, conn))
                        {
                            cmd.Parameters.AddWithValue("@userid", userId);
                            cmd.Parameters.AddWithValue("@goal", goalCalories);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception insertEx)
                    {
                        return new GoalResult
                        {
                            Success = false,
                            Message = $"Error: Cannot save goal - {insertEx.Message}",
                            IsNewGoal = false,
                            GoalCalories = 0
                        };
                    }

                    // Generate appropriate message
                    string message = isNewGoal
                        ? $"✓ New goal created successfully!\nYour goal: {goalCalories} calories"
                        : $"✓ Goal updated successfully!\nNew goal: {goalCalories} calories";

                    return new GoalResult
                    {
                        Success = true,
                        Message = message,
                        IsNewGoal = isNewGoal,
                        GoalCalories = goalCalories
                    };
                }
            }
            catch (Exception ex)
            {
                return new GoalResult
                {
                    Success = false,
                    Message = $"Unexpected error: {ex.Message}",
                    IsNewGoal = false,
                    GoalCalories = 0
                };
            }
        }
    }
}