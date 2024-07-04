/*using System.Data;
using Dapper;
using Opta3.Modelo;
using Opta3.Modelos;

public class SucursalRepository
{
    private readonly IDbConnection _connection;

    public SucursalRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public void InsertarSucursal(Sucursal sucursal)
    {
        string query = "INSERT INTO \"Sucursal\" (\"Id\", \"Descripcion\", \"Direccion\", \"Telefono\", \"Whatsapp\", \"Mail\", \"Estado\") VALUES (@Id, @Descripcion, @Direccion, @Telefono, @Whatsapp, @Mail, @Estado)";
        _connection.Execute(query, sucursal);
    }

    public Sucursal ObtenerSucursalPorId(int id)
    {
        string query = "SELECT * FROM \"Sucursal\" WHERE \"Id\" = @Id";
        return _connection.QuerySingleOrDefault<Sucursal>(query, new { Id = id });
    }

    public IEnumerable<Sucursal> ObtenerTodasLasSucursales()
    {
        string query = "SELECT * FROM \"Sucursal\"";
        return _connection.Query<Sucursal>(query);
    }

    public void ActualizarSucursal(Sucursal sucursal)
    {
        string query = "UPDATE \"Sucursal\" SET \"Descripcion\" = @Descripcion, \"Direccion\" = @Direccion, \"Telefono\" = @Telefono, \"Whatsapp\" = @Whatsapp, \"Mail\" = @Mail, \"Estado\" = @Estado WHERE \"Id\" = @Id";
        _connection.Execute(query, sucursal);
    }

    public void EliminarSucursal(int id)
    {
        string query = "DELETE FROM \"Sucursal\" WHERE \"Id\" = @Id";
        _connection.Execute(query, new { Id = id });
    }
}*/
/*using System.Collections.Generic;
using Dapper;
using System.Data;
using Opta3.Modelos;

namespace Opta3.Repositorio
{
    public class SucursalRepositorio
    {
        private readonly IDbConnection _connection;

        public SucursalRepositorio(IDbConnection connection)
        {
            _connection = connection;
        }

        public void Insertar(Sucursal sucursal)
        {
            string sql = "INSERT INTO Sucursal (Descripcion, Direccion, Telefono, Whatsapp, Mail, Estado) VALUES (@Descripcion, @Direccion, @Telefono, @Whatsapp, @Mail, @Estado)";
            _connection.Execute(sql, sucursal);
        }

        public Sucursal ObtenerPorId(int id)
        {
            string sql = "SELECT * FROM Sucursal WHERE Id = @Id";
            return _connection.QuerySingleOrDefault<Sucursal>(sql, new { Id = id });
        }

        public IEnumerable<Sucursal> ObtenerTodos()
        {
            string sql = "SELECT * FROM Sucursal";
            return _connection.Query<Sucursal>(sql);
        }

        public void Actualizar(Sucursal sucursal)
        {
            string sql = "UPDATE Sucursal SET Descripcion = @Descripcion, Direccion = @Direccion, Telefono = @Telefono, Whatsapp = @Whatsapp, Mail = @Mail, Estado = @Estado WHERE Id = @Id";
            _connection.Execute(sql, sucursal);
        }

        public void Eliminar(int id)
        {
            string sql = "DELETE FROM Sucursal WHERE Id = @Id";
            _connection.Execute(sql, new { Id = id });
        }
    }
}*/
/*using System.Collections.Generic;
using System.Data;
using Dapper;
using Opta3.Modelos;

namespace Opta3.Repositorio
{
    public class SucursalRepositorio
    {
        private readonly IDbConnection _connection;

        public SucursalRepositorio(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Sucursal> ObtenerTodos()
        {
            return _connection.Query<Sucursal>("SELECT * FROM \"Sucursal\"");
        }

        public Sucursal ObtenerPorId(int id)
        {
            return _connection.QueryFirstOrDefault<Sucursal>("SELECT * FROM \"Sucursal\" WHERE \"Id\" = @Id", new { Id = id });
        }

        public void Insertar(Sucursal sucursal)
        {
            var sql = "INSERT INTO \"Sucursal\" (\"Descripcion\", \"Direccion\", \"Telefono\", \"Whatsapp\", \"Mail\", \"Estado\") VALUES (@Descripcion, @Direccion, @Telefono, @Whatsapp, @Mail, @Estado)";
            _connection.Execute(sql, sucursal);
        }

        public void Actualizar(Sucursal sucursal)
        {
            var sql = "UPDATE \"Sucursal\" SET \"Descripcion\" = @Descripcion, \"Direccion\" = @Direccion, \"Telefono\" = @Telefono, \"Whatsapp\" = @Whatsapp, \"Mail\" = @Mail, \"Estado\" = @Estado WHERE \"Id\" = @Id";
            _connection.Execute(sql, sucursal);
        }

        public void Eliminar(int id)
        {
            var sql = "DELETE FROM \"Sucursal\" WHERE \"Id\" = @Id";
            _connection.Execute(sql, new { Id = id });
        }
    }
}*/
using System.Collections.Generic;
using System.Data;
using Dapper;
using Opta3.Modelos;

namespace Opta3.Repositorio
{
    public class SucursalRepositorio
    {
        private readonly IDbConnection _connection;

        public SucursalRepositorio(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Sucursal> ObtenerTodos()
        {
            return _connection.Query<Sucursal>("SELECT * FROM \"Sucursal\"");
        }

        public Sucursal ObtenerPorId(int id)
        {
            return _connection.QueryFirstOrDefault<Sucursal>("SELECT * FROM \"Sucursal\" WHERE \"Id\" = @Id", new { Id = id });
        }

        public void Insertar(Sucursal sucursal)
        {
            var sql = "INSERT INTO \"Sucursal\" (\"Id\", \"Descripcion\", \"Direccion\", \"Telefono\", \"Whatsapp\", \"Mail\", \"Estado\") VALUES (@Id, @Descripcion, @Direccion, @Telefono, @Whatsapp, @Mail, @Estado)";
            _connection.Execute(sql, sucursal);
        }

        public void Actualizar(Sucursal sucursal)
        {
            var sql = "UPDATE \"Sucursal\" SET \"Descripcion\" = @Descripcion, \"Direccion\" = @Direccion, \"Telefono\" = @Telefono, \"Whatsapp\" = @Whatsapp, \"Mail\" = @Mail, \"Estado\" = @Estado WHERE \"Id\" = @Id";
            _connection.Execute(sql, sucursal);
        }

        public void Eliminar(int id)
        {
            var sql = "DELETE FROM \"Sucursal\" WHERE \"Id\" = @Id";
            _connection.Execute(sql, new { Id = id });
        }
    }
}





