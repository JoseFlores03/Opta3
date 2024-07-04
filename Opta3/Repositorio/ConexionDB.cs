/*using Npgsql;
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
}*/
using System;
using System.Data;
using Npgsql;

namespace Opta3.Repositorio
{
    public class ConexionDB
    {
        private readonly string _connectionString;

        public ConexionDB(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }
    }
}


