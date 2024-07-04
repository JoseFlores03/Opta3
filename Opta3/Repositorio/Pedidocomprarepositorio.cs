/*using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Opta3.Modelo;

namespace Opta3.Repositorio
{
    public class PedidoCompraRepository
    {
        private readonly IDbConnection _dbConnection;

        public PedidoCompraRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void InsertarPedidoCompra(Pedidocompra pedidoCompra)
        {
            var sql = @"
                INSERT INTO ""Pedidocompra"" (""Idproveedor"", ""Idsucursal"", ""Fechahora"", ""Total"")
                VALUES (@Idproveedor, @Idsucursal, @Fechahora, @Total)";
            _dbConnection.Execute(sql, pedidoCompra);
        }

        public Pedidocompra ObtenerPedidoCompraPorId(int id)
        {
            var sql = @"SELECT * FROM ""Pedidocompra"" WHERE ""Id"" = @Id";
            return _dbConnection.Query<Pedidocompra>(sql, new { Id = id }).FirstOrDefault();
        }

        public IEnumerable<Pedidocompra> ObtenerTodosLosPedidosCompra()
        {
            var sql = @"SELECT * FROM ""Pedidocompra""";
            return _dbConnection.Query<Pedidocompra>(sql);
        }

        public void ActualizarPedidoCompra(Pedidocompra pedidoCompra)
        {
            var sql = @"
                UPDATE ""Pedidocompra""
                SET ""Idproveedor"" = @Idproveedor,
                    ""Idsucursal"" = @Idsucursal,
                    ""Fechahora"" = @Fechahora,
                    ""Total"" = @Total
                WHERE ""Id"" = @Id";
            _dbConnection.Execute(sql, pedidoCompra);
        }

        public void EliminarPedidoCompra(int id)
        {
            var sql = @"DELETE FROM ""Pedidocompra"" WHERE ""Id"" = @Id";
            _dbConnection.Execute(sql, new { Id = id });
        }
    }
}*/
/*using System.Data;
using Dapper;
using Opta3.Modelo;

namespace Opta3.Repositorio
{
    public class PedidoCompraRepository
    {
        private readonly IDbConnection _connection;

        public PedidoCompraRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public void InsertarPedidoCompra(Pedidocompra pedidoCompra)
        {
            string sql = "INSERT INTO PedidoCompra (Id, Idcliente, Nropedido, Fechahora, Total, Idsucursal) VALUES (@Id, @Idcliente, @Nropedido, @Fechahora, @Total, @Idsucursal)";
            _connection.Execute(sql, pedidoCompra);
        }

        public Pedidocompra ObtenerPedidoCompraPorId(int id)
        {
            string sql = "SELECT * FROM PedidoCompra WHERE Id = @Id";
            return _connection.QuerySingleOrDefault<Pedidocompra>(sql, new { Id = id });
        }

        public IEnumerable<Pedidocompra> ObtenerTodosLosPedidos()
        {
            string sql = "SELECT * FROM PedidoCompra";
            return _connection.Query<Pedidocompra>(sql);
        }

        public void ActualizarPedidoCompra(Pedidocompra pedidoCompra)
        {
            string sql = "UPDATE PedidoCompra SET Idcliente = @Idcliente, Nropedido = @Nropedido, Fechahora = @Fechahora, Total = @Total, Idsucursal = @Idsucursal WHERE Id = @Id";
            _connection.Execute(sql, pedidoCompra);
        }

        public void EliminarPedidoCompra(int id)
        {
            string sql = "DELETE FROM PedidoCompra WHERE Id = @Id";
            _connection.Execute(sql, new { Id = id });
        }
    }
}*/
using System.Collections.Generic;
using Dapper;
using System.Data;
using Opta3.Modelo;

namespace Opta3.Repositorio
{
    public class PedidocompraRepositorio
    {
        private readonly IDbConnection _connection;

        public PedidocompraRepositorio(IDbConnection connection)
        {
            _connection = connection;
        }

        public void Insertar(Pedidocompra pedidocompra)
        {
            string sql = "INSERT INTO Pedidocompra (Idproveedor, Idsucursal, Fechahora, Total) VALUES (@Idproveedor, @Idsucursal, @Fechahora, @Total)";
            _connection.Execute(sql, pedidocompra);
        }

        public Pedidocompra ObtenerPorId(int id)
        {
            string sql = "SELECT * FROM Pedidocompra WHERE Id = @Id";
            return _connection.QuerySingleOrDefault<Pedidocompra>(sql, new { Id = id });
        }

        public IEnumerable<Pedidocompra> ObtenerTodos()
        {
            string sql = "SELECT * FROM Pedidocompra";
            return _connection.Query<Pedidocompra>(sql);
        }

        public void Actualizar(Pedidocompra pedidocompra)
        {
            string sql = "UPDATE Pedidocompra SET Idproveedor = @Idproveedor, Idsucursal = @Idsucursal, Fechahora = @Fechahora, Total = @Total WHERE Id = @Id";
            _connection.Execute(sql, pedidocompra);
        }

        public void Eliminar(int id)
        {
            string sql = "DELETE FROM Pedidocompra WHERE Id = @Id";
            _connection.Execute(sql, new { Id = id });
        }
    }
}
