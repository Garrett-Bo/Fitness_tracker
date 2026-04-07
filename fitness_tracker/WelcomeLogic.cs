using MySql.Data.MySqlClient;

namespace fitness_tracker
{
    public class WelcomeLogic
    {
        private readonly string _connectionString;

        public WelcomeLogic(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool TestConnection()
        {
            using (var con = new MySqlConnection(_connectionString))
            {
                con.Open();
                return con.State == System.Data.ConnectionState.Open;
            }
        }
    }
}