using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using Opta3.Modelo;

namespace Repositorio
{
    public class FacturaRepository
    {
        private readonly IDbConnection _dbConnection;

        public FacturaRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void InsertarFactura(Factura factura)
        {
            var sql = @"
                INSERT INTO public.""Factura"" (""Idfactura"", ""Idcliente"", ""Nrofactura"", ""Fechahora"", ""Total"", ""Total5"", ""Total10"", ""totaliva"", ""Totalletras"", ""Sucursal"", ""Idsucursal"")
                VALUES (@Idfactura, @Idcliente, @Nrofactura, @Fechahora, @Total, @Total5, @Total10, @Totaliva, @Totalletras, @Sucursal, @Idsucursal)";
            _dbConnection.Execute(sql, factura);
        }

        public Factura ObtenerFacturaPorId(int id)
        {
            var sql = @"SELECT * FROM public.""Factura"" WHERE ""Idfactura"" = @Id";
            return _dbConnection.Query<Factura>(sql, new { Id = id }).FirstOrDefault();
        }

        public IEnumerable<Factura> ObtenerTodasLasFacturas()
        {
            var sql = @"SELECT * FROM public.""Factura""";
            return _dbConnection.Query<Factura>(sql);
        }

        public void ActualizarFactura(Factura factura)
        {
            var sql = @"
                UPDATE public.""Factura""
                SET ""Idcliente"" = @Idcliente,
                    ""Nrofactura"" = @Nrofactura,
                    ""Fechahora"" = @Fechahora,
                    ""Total"" = @Total,
                    ""Total5"" = @Total5,
                    ""Total10"" = @Total10,
                    ""totaliva"" = @Totaliva,
                    ""Totalletras"" = @Totalletras,
                    ""Sucursal"" = @Sucursal,
                    ""Idsucursal"" = @Idsucursal
                WHERE ""Idfactura"" = @Idfactura";
            _dbConnection.Execute(sql, factura);
        }

        public void EliminarFactura(int id)
        {
            var sql = @"DELETE FROM public.""Factura"" WHERE ""Idfactura"" = @Id";
            _dbConnection.Execute(sql, new { Id = id });
        }
    }
}

