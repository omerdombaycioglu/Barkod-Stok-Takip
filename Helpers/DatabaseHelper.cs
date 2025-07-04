using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace StokTakipOtomasyonu.Helpers
{
    public static class DatabaseHelper
    {
        private static string _connectionString = "server=localhost;database=stok_takip_otomasyonu;uid=root;pwd=;";

        public static void SetConnectionString(string connectionString)
        {
            _connectionString = connectionString;
        }

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }

        public static DataTable ExecuteQuery(string query, params MySqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    using (var adapter = new MySqlDataAdapter(cmd))
                        adapter.Fill(dt);
                }
            }
            return dt;
        }

        public static int ExecuteNonQuery(string query, MySqlTransaction transaction = null, params MySqlParameter[] parameters)
        {
            if (transaction != null)
            {
                using (var cmd = new MySqlCommand(query, transaction.Connection, transaction))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteNonQuery();
                }
            }

            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static object ExecuteScalar(string query, params MySqlParameter[] parameters)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteScalar();
                }
            }
        }

        public static bool TestConnection()
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}