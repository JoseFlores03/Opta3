using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Opta3.Repositorio
{
    public class ConexionDB
    {
        private string connectionString;
        public ConexionDB(string connectionString)
        {


            this.connectionString = connectionString;

        }

        // Método para establecer una conexión 
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

