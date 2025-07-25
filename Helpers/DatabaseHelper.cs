using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace StokTakipOtomasyonu.Helpers
{
    public static class DatabaseHelper
    {                 
        public static SqlConnection GetConnection()
        {
            // Her defasında güncel connection string'i oku!
            string connStr = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
            return new SqlConnection(connStr);
        }


        public static DataTable ExecuteQuery(string query, params SqlParameter[] parameters)
        {
            return ExecuteQuery(query, null, parameters);
        }

        public static DataTable ExecuteQuery(string query, SqlTransaction transaction, params SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            try
            {
                if (transaction != null)
                {
                    using (var cmd = new SqlCommand(query, transaction.Connection, transaction))
                    {
                        if (parameters != null) cmd.Parameters.AddRange(parameters);
                        using (var adapter = new SqlDataAdapter(cmd))
                            adapter.Fill(dt);
                    }
                }
                else
                {
                    using (var conn = GetConnection())
                    {
                        conn.Open();
                        using (var cmd = new SqlCommand(query, conn))
                        {
                            if (parameters != null) cmd.Parameters.AddRange(parameters);
                            using (var adapter = new SqlDataAdapter(cmd))
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

        public static int ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            return ExecuteNonQuery(query, null, parameters);
        }

        public static int ExecuteNonQuery(string query, SqlTransaction transaction, params SqlParameter[] parameters)
        {
            try
            {
                if (transaction != null)
                {
                    using (var cmd = new SqlCommand(query, transaction.Connection, transaction))
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
                        using (var cmd = new SqlCommand(query, conn))
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

        public static object ExecuteScalar(string query, params SqlParameter[] parameters)
        {
            return ExecuteScalar(query, null, parameters);
        }

        public static object ExecuteScalar(string query, SqlTransaction transaction, params SqlParameter[] parameters)
        {
            try
            {
                if (transaction != null)
                {
                    using (var cmd = new SqlCommand(query, transaction.Connection, transaction))
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
                        using (var cmd = new SqlCommand(query, conn))
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

        public static SqlTransaction BeginTransaction(SqlConnection connection)
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();

            return connection.BeginTransaction();
        }
    }
}
