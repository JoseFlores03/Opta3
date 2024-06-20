using Dapper;
using System.Data;
using Opta3.Modelo;

namespace Opta3.Repositorio
{
    public class ClienteRepository
    {
        private readonly IDbConnection _dbConnection;

        public ClienteRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void InsertarCliente(Cliente cliente)
        {
            var query = @"INSERT INTO ""Cliente"" (""Idbanco"", ""Nombre"", ""Apellido"", ""Documento"", ""Direccion"", ""Mail"", ""Celular"", ""Estado"")
                          VALUES (@Idbanco, @Nombre, @Apellido, @Documento, @Direccion, @Mail, @Celular, @Estado)";
            _dbConnection.Execute(query, cliente);
        }

        public Cliente ObtenerClientePorId(int id)
        {
            var query = @"SELECT * FROM ""Cliente"" WHERE ""Id"" = @Id";
            return _dbConnection.Query<Cliente>(query, new { Id = id }).FirstOrDefault();
        }

        public IEnumerable<Cliente> ObtenerTodosLosClientes()
        {
            var query = @"SELECT * FROM ""Cliente""";
            return _dbConnection.Query<Cliente>(query);
        }

        public void ActualizarCliente(Cliente cliente)
        {
            var query = @"UPDATE ""Cliente"" SET ""Idbanco"" = @Idbanco, ""Nombre"" = @Nombre, ""Apellido"" = @Apellido, 
                          ""Documento"" = @Documento, ""Direccion"" = @Direccion, ""Mail"" = @Mail, ""Celular"" = @Celular, 
                          ""Estado"" = @Estado WHERE ""Id"" = @Id";
            _dbConnection.Execute(query, cliente);
        }

        public void EliminarCliente(int id)
        {
            var query = @"DELETE FROM ""Cliente"" WHERE ""Id"" = @Id";
            _dbConnection.Execute(query, new { Id = id });
        }

        
    }
}
