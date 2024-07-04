/*using Dapper;
using System.Data;
using Opta3.Modelo;

namespace Opta3.Repositorio
{
    public class ProveedorRepository
    {
        private readonly IDbConnection _dbConnection;

        public ProveedorRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void InsertarProveedor(Proveedor proveedor)
        {
            var query = @"INSERT INTO ""Proveedor"" (""Nombre"", ""Apellido"", ""Documento"", ""Direccion"", ""Mail"", ""Telefono"")
                          VALUES (@Nombre, @Apellido, @Documento, @Direccion, @Mail, @Telefono)";
            _dbConnection.Execute(query, proveedor);
        }

        public Proveedor ObtenerProveedorPorId(int id)
        {
            var query = @"SELECT * FROM ""Proveedor"" WHERE ""Id"" = @Id";
            return _dbConnection.Query<Proveedor>(query, new { Id = id }).FirstOrDefault();
        }

        public IEnumerable<Proveedor> ObtenerTodosLosProveedores()
        {
            var query = @"SELECT * FROM ""Proveedor""";
            return _dbConnection.Query<Proveedor>(query);
        }

        public void ActualizarProveedor(Proveedor proveedor)
        {
            var query = @"UPDATE ""Proveedor"" SET ""Nombre"" = @Nombre, ""Apellido"" = @Apellido, 
                          ""Documento"" = @Documento, ""Direccion"" = @Direccion, ""Mail"" = @Mail, 
                          ""Telefono"" = @Telefono WHERE ""Id"" = @Id";
            _dbConnection.Execute(query, proveedor);
        }

        public void EliminarProveedor(int id)
        {
            var query = @"DELETE FROM ""Proveedor"" WHERE ""Id"" = @Id";
            _dbConnection.Execute(query, new { Id = id });
        }
    }
}*/
/*using System.Data;
using Dapper;
using Opta3.Modelo;

namespace Opta3.Repositorio
{
    public class ProveedorRepository
    {
        private readonly IDbConnection _connection;

        public ProveedorRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public void InsertarProveedor(Proveedor proveedor)
        {
            string sql = "INSERT INTO Proveedor (Id, RazonSocial, TipoDocumento, NumeroDocumento, Celular) VALUES (@Id, @RazonSocial, @TipoDocumento, @NumeroDocumento, @Celular)";
            _connection.Execute(sql, proveedor);
        }

        public Proveedor ObtenerProveedorPorId(int id)
        {
            string sql = "SELECT * FROM Proveedor WHERE Id = @Id";
            return _connection.QuerySingleOrDefault<Proveedor>(sql, new { Id = id });
        }

        public IEnumerable<Proveedor> ObtenerTodosLosProveedores()
        {
            string sql = "SELECT * FROM Proveedor";
            return _connection.Query<Proveedor>(sql);
        }

        public void ActualizarProveedor(Proveedor proveedor)
        {
            string sql = "UPDATE Proveedor SET RazonSocial = @RazonSocial, TipoDocumento = @TipoDocumento, NumeroDocumento = @NumeroDocumento, Celular = @Celular WHERE Id = @Id";
            _connection.Execute(sql, proveedor);
        }

        public void EliminarProveedor(int id)
        {
            string sql = "DELETE FROM Proveedor WHERE Id = @Id";
            _connection.Execute(sql, new { Id = id });
        }
    }
}
*/
using System.Collections.Generic;
using System.Data;
using Dapper;
using Opta3.Modelo;

namespace Opta3.Repositorio
{
    public class ProveedorRepositorio
    {
        private readonly IDbConnection _connection;

        public ProveedorRepositorio(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Proveedor> ObtenerTodos()
        {
            return _connection.Query<Proveedor>("SELECT * FROM \"Proveedor\"");
        }

        public Proveedor ObtenerPorId(int id)
        {
            return _connection.QueryFirstOrDefault<Proveedor>("SELECT * FROM \"Proveedor\" WHERE \"Id\" = @Id", new { Id = id });
        }

        public void Insertar(Proveedor proveedor)
        {
            var sql = "INSERT INTO \"Proveedor\" (\"Razonsocial\", \"Tipodocumento\", \"Documento\", \"Direccion\", \"Mail\", \"Celular\", \"Estado\") VALUES (@Razonsocial, @Tipodocumento, @Documento, @Direccion, @Mail, @Celular, @Estado)";
            _connection.Execute(sql, proveedor);
        }

        public void Actualizar(Proveedor proveedor)
        {
            var sql = "UPDATE \"Proveedor\" SET \"Razonsocial\" = @Razonsocial, \"Tipodocumento\" = @Tipodocumento, \"Documento\" = @Documento, \"Direccion\" = @Direccion, \"Mail\" = @Mail, \"Celular\" = @Celular, \"Estado\" = @Estado WHERE \"Id\" = @Id";
            _connection.Execute(sql, proveedor);
        }

        public void Eliminar(int id)
        {
            var sql = "DELETE FROM \"Proveedor\" WHERE \"Id\" = @Id";
            _connection.Execute(sql, new { Id = id });
        }
    }
}

