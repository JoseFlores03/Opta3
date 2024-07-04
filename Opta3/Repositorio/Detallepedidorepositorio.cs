

/*namespace Opta3.Repositorio
{
    public class DetallePedidoRepository
    {
        private readonly IDbConnection _dbConnection;

        public DetallePedidoRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void InsertarDetallePedido(Detallepedido detallePedido)
        {
            var query = @"INSERT INTO ""DetallePedido"" (""IdPedido"", ""IdProducto"", ""Cantidad"", ""PrecioUnitario"", ""Subtotal"")
                          VALUES (@IdPedido, @IdProducto, @Cantidad, @PrecioUnitario, @Subtotal)";
            _dbConnection.Execute(query, detallePedido);
        }

        public Detallepedido ObtenerDetallePedidoPorId(int id)
        {
            var query = @"SELECT * FROM ""DetallePedido"" WHERE ""IdPedido"" = @Id";
            return _dbConnection.Query<Detallepedido>(query, new { Id = id }).FirstOrDefault();
        }

        public IEnumerable<Detallepedido> ObtenerTodosLosDetallePedidos()
        {
            var query = @"SELECT * FROM ""DetallePedido""";
            return _dbConnection.Query<Detallepedido>(query);
        }

        public void ActualizarDetallePedido(Detallepedido detallePedido)
        {
            var query = @"UPDATE ""DetallePedido"" SET ""IdProducto"" = @IdProducto, ""Cantidad"" = @Cantidad, 
                          ""PrecioUnitario"" = @PrecioUnitario, ""Subtotal"" = @Subtotal 
                          WHERE ""IdPedido"" = @IdPedido";
            _dbConnection.Execute(query, detallePedido);
        }

        public void EliminarDetallePedido(int id)
        {
            var query = @"DELETE FROM ""DetallePedido"" WHERE ""IdPedido"" = @Id";
            _dbConnection.Execute(query, new { Id = id });
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
    public class DetallepedidoRepositorio
    {
        private readonly IDbConnection _connection;

        public DetallepedidoRepositorio(IDbConnection connection)
        {
            _connection = connection;
        }

        public void Insertar(Detallepedido detallepedido)
        {
            string sql = "INSERT INTO Detallepedido (Idpedido, Idproducto, Cantproducto, Subtotal) VALUES (@Idpedido, @Idproducto, @Cantproducto, @Subtotal)";
            _connection.Execute(sql, detallepedido);
        }

        public Detallepedido ObtenerPorId(int id)
        {
            string sql = "SELECT * FROM Detallepedido WHERE Id = @Id";
            return _connection.QuerySingleOrDefault<Detallepedido>(sql, new { Id = id });
        }

        public IEnumerable<Detallepedido> ObtenerTodos()
        {
            string sql = "SELECT * FROM Detallepedido";
            return _connection.Query<Detallepedido>(sql);
        }

        public void Actualizar(Detallepedido detallepedido)
        {
            string sql = "UPDATE Detallepedido SET Idpedido = @Idpedido, Idproducto = @Idproducto, Cantproducto = @Cantproducto, Subtotal = @Subtotal WHERE Id = @Id";
            _connection.Execute(sql, detallepedido);
        }

        public void Eliminar(int id)
        {
            string sql = "DELETE FROM Detallepedido WHERE Id = @Id";
            _connection.Execute(sql, new { Id = id });
        }
    }
}*/
using System.Collections.Generic;
using System.Data;
using Dapper;
using Opta3.Modelo;

namespace Opta3.Repositorio
{
    public class DetallepedidoRepositorio
    {
        private readonly IDbConnection _conexion;

        public DetallepedidoRepositorio(IDbConnection conexion)
        {
            _conexion = conexion;
        }

        public void Insertar(Detallepedido detallepedido)
        {
            string sql = "INSERT INTO Detallepedido (Idpedido, Idproducto, Cantproducto, Subtotal) VALUES (@Idpedido, @Idproducto, @Cantproducto, @Subtotal)";
            _conexion.Execute(sql, detallepedido);
        }

        public Detallepedido ObtenerPorId(int id)
        {
            string sql = "SELECT * FROM Detallepedido WHERE Id = @Id";
            return _conexion.QuerySingleOrDefault<Detallepedido>(sql, new { Id = id });
        }

        public IEnumerable<Detallepedido> ObtenerTodos()
        {
            string sql = "SELECT * FROM Detallepedido";
            return _conexion.Query<Detallepedido>(sql);
        }

        public void Actualizar(Detallepedido detallepedido)
        {
            string sql = "UPDATE Detallepedido SET Idpedido = @Idpedido, Idproducto = @Idproducto, Cantproducto = @Cantproducto, Subtotal = @Subtotal WHERE Id = @Id";
            _conexion.Execute(sql, detallepedido);
        }

        public void Eliminar(int id)
        {
            string sql = "DELETE FROM Detallepedido WHERE Id = @Id";
            _conexion.Execute(sql, new { Id = id });
        }
    }
}

