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
            return ExecuteQuery(query, null, parameters);
        }

        public static DataTable ExecuteQuery(string query, MySqlTransaction transaction, params MySqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            try
            {
                if (transaction != null)
                {
                    using (var cmd = new MySqlCommand(query, transaction.Connection, transaction))
                    {
                        if (parameters != null) cmd.Parameters.AddRange(parameters);
                        using (var adapter = new MySqlDataAdapter(cmd))
                            adapter.Fill(dt);
                    }
                }
                else
                {
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
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sorgu çalıştırma hatası: " + ex.Message, ex);
            }
            return dt;
        }

        public static int ExecuteNonQuery(string query, params MySqlParameter[] parameters)
        {
            return ExecuteNonQuery(query, null, parameters);
        }

        public static int ExecuteNonQuery(string query, MySqlTransaction transaction, params MySqlParameter[] parameters)
        {
            try
            {
                if (transaction != null)
                {
                    using (var cmd = new MySqlCommand(query, transaction.Connection, transaction))
                    {
                        if (parameters != null) cmd.Parameters.AddRange(parameters);
                        return cmd.ExecuteNonQuery();
                    }
                }
                else
                {
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
            }
            catch (Exception ex)
            {
                throw new Exception("Sorgu çalıştırma hatası: " + ex.Message, ex);
            }
        }

        public static object ExecuteScalar(string query, params MySqlParameter[] parameters)
        {
            return ExecuteScalar(query, null, parameters);
        }

        public static object ExecuteScalar(string query, MySqlTransaction transaction, params MySqlParameter[] parameters)
        {
            try
            {
                if (transaction != null)
                {
                    using (var cmd = new MySqlCommand(query, transaction.Connection, transaction))
                    {
                        if (parameters != null) cmd.Parameters.AddRange(parameters);
                        return cmd.ExecuteScalar();
                    }
                }
                else
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
            }
            catch (Exception ex)
            {
                throw new Exception("Sorgu çalıştırma hatası: " + ex.Message, ex);
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

        public static MySqlTransaction BeginTransaction(MySqlConnection connection)
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();

            return connection.BeginTransaction();
        }
    }
}