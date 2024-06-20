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
using Dapper;
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
            var query = @"INSERT INTO ""Producto"" (""Id"", ""Nombre"", ""Descripcion"", ""Precio"", ""Stock"", ""Cantminima"", ""Preciocompra"", ""Precioventa"", ""Categoria"", ""Marca"", ""Estado"")
                          VALUES (@Id, @Nombre, @Descripcion, @Precio, @Stock, @CantMinima, @PrecioCompra, @PrecioVenta, @Categoria, @Marca, @Estado)";
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
            var query = @"UPDATE ""Producto"" SET ""Nombre"" = @Nombre, ""Descripcion"" = @Descripcion, ""Precio"" = @Precio, ""Stock"" = @Stock,
                          ""Cantminima"" = @CantMinima, ""Preciocompra"" = @PrecioCompra, ""Precioventa"" = @PrecioVenta,
                          ""Categoria"" = @Categoria, ""Marca"" = @Marca, ""Estado"" = @Estado
                          WHERE ""Id"" = @Id";
            _dbConnection.Execute(query, producto);
        }

        public void EliminarProducto(int id)
        {
            var query = @"DELETE FROM ""Producto"" WHERE ""Id"" = @Id";
            _dbConnection.Execute(query, new { Id = id });
        }
    }
}

