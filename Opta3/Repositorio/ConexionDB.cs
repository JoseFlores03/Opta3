/*using Npgsql;
using System;

namespace MiProyecto.Repositorio
{
    /* public class ConexionDB
     {
         private string connectionString;

         public ConexionDB(string connectionString)
         {
             this.connectionString = connectionString;
         }

         public NpgsqlConnection OpenConnection()
         {
             try
             {
                 var conn = new NpgsqlConnection(connectionString);
                 conn.Open();
                 return conn;
             }
             catch (Exception ex)
             {
                 throw ex;
             }
         }
     }*/
/* using Npgsql;

 namespace Opta3.Repositorio
 {
     public class ConexionDB
     {
         private string connectionString;

         public ConexionDB(string connectionString)
         {
             this.connectionString = connectionString;
         }

         public NpgsqlConnection OpenConnection()
         {
             try
             {
                 var conn = new NpgsqlConnection(connectionString);
                 conn.Open();
                 return conn;
             }
             catch (Exception ex)
             {
                 throw ex;
             }
         }
     }
 }

} */
using Npgsql;
using System.Data;

namespace Opta3
{
    public class DatabaseConnection
    {
        private readonly string _connectionString;

        public DatabaseConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }
    }
}


