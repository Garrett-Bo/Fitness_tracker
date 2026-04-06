using System;

namespace Demo1
{
    // Service layer - calculations and validations
    public class FitnessService
    {
        // Try parse and validate metrics. Keeps the exact validation logic and messages from the original form.
        public bool TryParseMetrics(string m1Text, string m2Text, string m3Text, string weightText,
            out float metric1, out float metric2, out float metric3, out float durationHours, out float weight, out string error)
        {
            metric1 = metric2 = metric3 = durationHours = weight = 0f;
            error = null;

            float durationMinutes;
            // Note: This mirrors the original parsing logic exactly (including the double-parse of metric2)
            if (!float.TryParse(m1Text, out metric1) ||
                !float.TryParse(m2Text, out metric2) ||
                !float.TryParse(m3Text, out metric3) ||
                !float.TryParse(weightText, out weight) ||
                !float.TryParse(m2Text, out durationMinutes)) // assuming metric2 is time in min
            {
                error = "Please enter valid numbers for all metrics.";
                return false;
            }

            // convert minutes to hours (keeps original calculation)
            durationHours = durationMinutes / 60f;
            return true;
        }

        // Keep the simple calories formula the same as original logic
        public float CalculateCalories(float durationHours, float weightKg)
        {
            return durationHours * weightKg;
        }
    }
}
