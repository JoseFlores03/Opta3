/*using Dapper;
using Opta3.Modelo;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Opta3.Repositorio
{
    public class ProductoRepository
    {
        private readonly IDbConnection _dbConnection;

        public ProductoRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void InsertarProducto(Producto producto)
        {
            var query = @"INSERT INTO ""Producto"" (""Id"", ""Nombre"", ""Descripcion"", ""Precio"", ""Stock"")
                          VALUES (@Id, @Nombre, @Descripcion, @Precio, @Stock)";
            _dbConnection.Execute(query, producto);
        }

        public Producto ObtenerProductoPorId(int id)
        {
            var query = @"SELECT * FROM ""Producto"" WHERE ""Id"" = @Id";
            return _dbConnection.Query<Producto>(query, new { Id = id }).FirstOrDefault();
        }

        public IEnumerable<Producto> ObtenerTodosLosProductos()
        {
            var query = @"SELECT * FROM ""Producto""";
            return _dbConnection.Query<Producto>(query);
        }

        public void ActualizarProducto(Producto producto)
        {
            var query = @"UPDATE ""Producto"" SET ""Nombre"" = @Nombre, ""Descripcion"" = @Descripcion, ""Precio"" = @Precio, ""Stock"" = @Stock 
                          WHERE ""Id"" = @Id";
            _dbConnection.Execute(query, producto);
        }

        public void EliminarProducto(int id)
        {
            var query = @"DELETE FROM ""Producto"" WHERE ""Id"" = @Id";
            _dbConnection.Execute(query, new { Id = id });
        }
    }
}*/
/*using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using Opta3.Modelo;

namespace Opta3.Repositorio
{
    public class ProductoRepository
    {
        private readonly IDbConnection _dbConnection;

        public ProductoRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void InsertarProducto(Producto producto)
        {
            try
            {
                var query = @"
                INSERT INTO ""Productos"" (
                    ""Descripcion"", ""Cantminima"", ""Preciocompra"", ""Precioventa"", ""Categoria"", ""Marca"", ""Estado"", ""Cantstock""
                ) VALUES (
                    @Descripcion, @Cantminima, @Preciocompra, @Precioventa, @Categoria, @Marca, @Estado, @Cantstock
                )";

                _dbConnection.Execute(query, producto);
                Console.WriteLine("Producto insertado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar producto: {ex.Message}");
                throw; // Puedes omitir el throw si manejas la excepción de otra manera
            }
        }

        public Producto ObtenerProductoPorId(int id)
        {
            var query = @"SELECT * FROM ""Productos"" WHERE ""Id"" = @Id";
            return _dbConnection.QueryFirstOrDefault<Producto>(query, new { Id = id });
        }

        public IEnumerable<Producto> ObtenerTodosLosProductos()
        {
            var query = @"SELECT * FROM ""Productos""";
            return _dbConnection.Query<Producto>(query);
        }

        public void ActualizarProducto(Producto producto)
        {
            var query = @"
            UPDATE ""Productos"" SET
                ""Descripcion"" = @Descripcion,
                ""Cantminima"" = @Cantminima,
                ""Preciocompra"" = @Preciocompra,
                ""Precioventa"" = @Precioventa,
                ""Categoria"" = @Categoria,
                ""Marca"" = @Marca,
                ""Estado"" = @Estado,
                ""Cantstock"" = @Cantstock
            WHERE ""Id"" = @Id";

            _dbConnection.Execute(query, producto);
        }

        public void EliminarProducto(int id)
        {
            var query = @"DELETE FROM ""Productos"" WHERE ""Id"" = @Id";
            _dbConnection.Execute(query, new { Id = id });
        }
    }
}*/
/*using System.Data;
using Dapper;
using Opta3.Modelo;

namespace Opta3.Repositorio
{
    public class ProductoRepository
    {
        private readonly IDbConnection _connection;

        public ProductoRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public void InsertarProducto(Producto producto)
        {
            string sql = "INSERT INTO Producto (Id, Descripcion, Cantminima, Preciocompra, Precioventa, Categoria, Marca, Estado) VALUES (@Id, @Descripcion, @Cantminima, @Preciocompra, @Precioventa, @Categoria, @Marca, @Estado)";
            _connection.Execute(sql, producto);
        }

        public Producto ObtenerProductoPorId(int id)
        {
            string sql = "SELECT * FROM Producto WHERE Id = @Id";
            return _connection.QuerySingleOrDefault<Producto>(sql, new { Id = id });
        }

        public IEnumerable<Producto> ObtenerTodosLosProductos()
        {
            string sql = "SELECT * FROM Producto";
            return _connection.Query<Producto>(sql);
        }

        public void ActualizarProducto(Producto producto)
        {
            string sql = "UPDATE Producto SET Descripcion = @Descripcion, Cantminima = @Cantminima, Preciocompra = @Preciocompra, Precioventa = @Precioventa, Categoria = @Categoria, Marca = @Marca, Estado = @Estado WHERE Id = @Id";
            _connection.Execute(sql, producto);
        }

        public void EliminarProducto(int id)
        {
            string sql = "DELETE FROM Producto WHERE Id = @Id";
            _connection.Execute(sql, new { Id = id });
        }
    }
}
*/
/*using System.Collections.Generic;
using Dapper;
using System.Data;
using Opta3.Modelo;

namespace Opta3.Repositorio
{
    public class ProductoRepositorio
    {
        private readonly IDbConnection _connection;

        public ProductoRepositorio(IDbConnection connection)
        {
            _connection = connection;
        }

        public void Insertar(Producto producto)
        {
            string sql = "INSERT INTO Productos (Descripcion, Cantminima, Preciocompra, Precioventa, Categoria, Marca, Estado, Cantstock) VALUES (@Descripcion, @Cantminima, @Preciocompra, @Precioventa, @Categoria, @Marca, @Estado, @Cantstock)";
            _connection.Execute(sql, producto);
        }

        public Producto ObtenerPorId(int id)
        {
            string sql = "SELECT * FROM Producto WHERE Id = @Id";
            return _connection.QuerySingleOrDefault<Producto>(sql, new { Id = id });
        }

        public IEnumerable<Producto> ObtenerTodos()
        {
            string sql = "SELECT * FROM Producto";
            return _connection.Query<Producto>(sql);
        }

        public void Actualizar(Producto producto)
        {
            string sql = "UPDATE Producto SET Descripcion = @Descripcion, Cantminima = @Cantminima, Preciocompra = @Preciocompra, Precioventa = @Precioventa, Categoria = @Categoria, Marca = @Marca, Estado = @Estado, Cantstock = @Cantstock WHERE Id = @Id";
            _connection.Execute(sql, producto);
        }

        public void Eliminar(int id)
        {
            string sql = "DELETE FROM Producto WHERE Id = @Id";
            _connection.Execute(sql, new { Id = id });
        }
    }
}*/
using Dapper;
using System.Collections.Generic;
using System.Data;
using Opta3.Modelo;

namespace Opta3.Repositorio
{
    public class ProductoRepository
    {
        private readonly IDbConnection _dbConnection;

        public ProductoRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void InsertarProducto(Producto producto)
        {
            var query = @"
        INSERT INTO ""Productos"" (
            ""Id"", ""Descripcion"", ""Cantminima"", ""Preciocompra"", ""Precioventa"", ""Categoria"", ""Marca"", ""Estado"", ""Cantstock""
        ) VALUES (
            @Id, @Descripcion, @Cantminima, @Preciocompra, @Precioventa, @Categoria, @Marca, @Estado, @Cantstock
        )";

            _dbConnection.Execute(query, producto);
        }

        public Producto ObtenerProductoPorId(int id)
        {
            var query = @"SELECT * FROM ""Productos"" WHERE ""Id"" = @Id";
            return _dbConnection.QueryFirstOrDefault<Producto>(query, new { Id = id });
        }

        public IEnumerable<Producto> ObtenerTodosLosProductos()
        {
            var query = @"SELECT * FROM ""Productos""";
            return _dbConnection.Query<Producto>(query);
        }

        public void ActualizarProducto(Producto producto)
        {
            var query = @"
                UPDATE ""Productos"" SET
                    ""Descripcion"" = @Descripcion,
                    ""Cantminima"" = @Cantminima,
                    ""Preciocompra"" = @Preciocompra,
                    ""Precioventa"" = @Precioventa,
                    ""Categoria"" = @Categoria,
                    ""Marca"" = @Marca,
                    ""Estado"" = @Estado,
                    ""Cantstock"" = @Cantstock
                WHERE ""Id"" = @Id";

            _dbConnection.Execute(query, producto);
        }

        public void EliminarProducto(int id)
        {
            var query = @"DELETE FROM ""Productos"" WHERE ""Id"" = @Id";
            _dbConnection.Execute(query, new { Id = id });
        }
    }
}
