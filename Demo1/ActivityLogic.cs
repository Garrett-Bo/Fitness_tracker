using System;

namespace Demo1
{
    public class ActivityLogic
    {
        private readonly DatabaseManager _db;
        private readonly FitnessService _service;

        public ActivityLogic(string connectionString)
        {
            // use provided connection string but centralize DB ops in DatabaseManager
            _db = new DatabaseManager(connectionString);
            _service = new FitnessService();
        }

        public int? GetUserId(string username)
        {
            return _db.GetUserId(username);
        }

        public bool SaveActivity(int userId, string activityType, float metric1, float metric2, float metric3, float durationHours, float weightKg, out string error)
        {
            error = null;
            // Keep original calorie formula exactly
            float calories = _service.CalculateCalories(durationHours, weightKg);
            return _db.SaveActivity(userId, activityType, metric1, metric2, metric3, durationHours, weightKg, calories, out error);
        }
    }
}