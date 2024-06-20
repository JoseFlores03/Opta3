using Dapper;
using Opta3.Modelo;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Opta3.Repositorio
{
    public class DetallefacturaRepository
    {
        private readonly IDbConnection _dbConnection;

        public DetallefacturaRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void InsertarDetallefactura(Detallefactura detallefactura)
        {
            var query = @"INSERT INTO ""Detallefactura"" (""Id"", ""Idfactura"", ""Idproducto"", ""Cantproducto"", ""Subtotal"")
                          VALUES (@Id, @Idfactura, @Idproducto, @Cantproducto, @Subtotal)";
            _dbConnection.Execute(query, detallefactura);
        }

        public Detallefactura ObtenerDetallefacturaPorId(int id)
        {
            var query = @"SELECT * FROM ""Detallefactura"" WHERE ""Idfactura"" = @Id";
            return _dbConnection.Query<Detallefactura>(query, new { Id = id }).FirstOrDefault();
        }

        public IEnumerable<Detallefactura> ObtenerTodosLosDetallefacturas()
        {
            var query = @"SELECT * FROM ""Detallefactura""";
            return _dbConnection.Query<Detallefactura>(query);
        }

        public void ActualizarDetallefactura(Detallefactura detallefactura)
        {
            var query = @"UPDATE ""Detallefactura"" SET ""Idproducto"" = @Idproducto, ""Cantproducto"" = @Cantproducto, ""Subtotal"" = @Subtotal 
                          WHERE ""Idfactura"" = @Idfactura";
            _dbConnection.Execute(query, detallefactura);
        }

        public void EliminarDetallefactura(int id)
        {
            var query = @"DELETE FROM ""Detallefactura"" WHERE ""Idfactura"" = @Id";
            _dbConnection.Execute(query, new { Id = id });
        }
    }
}
