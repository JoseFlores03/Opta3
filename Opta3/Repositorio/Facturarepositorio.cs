/*using System;
using System.Collections.Generic;
using Npgsql;
using Opta3.Repositorio;

namespace opta3.Repositorio
{
    public class Facturarepositorio
    {
        private NpgsqlConnection connection;

        public Facturarepositorio(string connectionString)
        {
            connection = new NpgsqlConnection(connectionString);
            connection.Open();
        }

        public void AggFactura(Factura factura)
        {
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Factura (Idcliente, Nrofactura, Fechahora, Total, " +
                                      "Total5, Total10, Totaliva, Totalletras, Sucursal) " +
                                      "VALUES (@Idcliente, @Nrofactura, @Fechahora, @Total, @Total5, " +
                                      "@Total10, @Totaliva, @Totalletras, @Sucursal)";
                    cmd.Parameters.AddWithValue("Idcliente", factura.Idcliente);
                    cmd.Parameters.AddWithValue("Nrofactura", factura.Nrofactura);
                    cmd.Parameters.AddWithValue("Fechahora", factura.Fechahora);
                    cmd.Parameters.AddWithValue("Total", factura.Total);
                    cmd.Parameters.AddWithValue("Total5", factura.Total5);
                    cmd.Parameters.AddWithValue("Total10", factura.Total10);
                    cmd.Parameters.AddWithValue("Totaliva", factura.Totaliva);
                    cmd.Parameters.AddWithValue("Totalletras", factura.Totalletras);
                    cmd.Parameters.AddWithValue("Sucursal", factura.Sucursal);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActualizarFactura(Factura factura)
        {
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Factura SET Idcliente = @Idcliente, Nrofactura = @NroFactura, " +
                                      "Fechahora = @Fechahora, Total = @Total, Total5 = @Total5, " +
                                      "Total10 = @Total10, Totaliva = @Totaliva, Totalletras = @Totalletras, " +
                                      "Sucursal = @Sucursal WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("IdCliente", factura.Idcliente);
                    cmd.Parameters.AddWithValue("NroFactura", factura.Nrofactura);
                    cmd.Parameters.AddWithValue("FechaHora", factura.Fechahora);
                    cmd.Parameters.AddWithValue("Total", factura.Total);
                    cmd.Parameters.AddWithValue("TotalIva5", factura.Total5);
                    cmd.Parameters.AddWithValue("TotalIva10", factura.Total10);
                    cmd.Parameters.AddWithValue("TotalIva", factura.Totaliva);
                    cmd.Parameters.AddWithValue("TotalLetras", factura.Totalletras);
                    cmd.Parameters.AddWithValue("Sucursal", factura.Sucursal);
                    cmd.Parameters.AddWithValue("Id", factura.Id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarFactura(int Id)
        {
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Factura WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("Id", Id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Factura ObtenerFactura(int Id)
        {
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Factura WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("Id", Id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Factura(
                            
                              
                                reader.GetString(0),
                                reader.GetDateTime(1),
                                reader.GetDecimal(2),
                                reader.GetDecimal(3),
                                reader.GetDecimal(4),
                                reader.GetDecimal(5),
                                reader.GetString(6),
                                reader.GetString(7)
                            );
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Factura> ObtenerFacturas()
        {
            List<Factura> facturas = new List<Factura>();

            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Factura";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Factura factura = new Factura(
                       
                                reader.GetString(0),
                                reader.GetDateTime(1),
                                reader.GetDecimal(2),
                                reader.GetDecimal(3),
                                reader.GetDecimal(4),
                                reader.GetDecimal(5),
                                reader.GetString(6),
                                reader.GetString(7)
                            );
                            facturas.Add(factura);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return facturas;
        }
    }
}*/
/*using Npgsql;
using Opta3.Modelo;
using System;
using System.Collections.Generic;

public class FacturaRepository
{
    private readonly NpgsqlConnection _connection;

    public FacturaRepository(NpgsqlConnection connection)
    {
        _connection = connection;
    }

    public void InsertarFactura(Factura factura)
    {
        try
        {
            string query = "INSERT INTO \"Factura\" (\"Idfactura\", \"Idcliente\", \"Nrofactura\", \"Fechahora\", \"Total\", \"Total5\", \"Total10\", totaliva, \"Totalletras\", \"Sucursal\") VALUES (@Idfactura, @Idcliente, @Nrofactura, @Fechahora, @Total, @Total5, @Total10, @Totaliva, @Totalletras, @Sucursal)";
            using (var command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@Idfactura", factura.Idfactura);
                command.Parameters.AddWithValue("@Idcliente", factura.Idcliente);
                command.Parameters.AddWithValue("@Nrofactura", factura.Nrofactura);
                command.Parameters.AddWithValue("@Fechahora", factura.Fechahora);
                command.Parameters.AddWithValue("@Total", factura.Total);
                command.Parameters.AddWithValue("@Total5", factura.Total5);
                command.Parameters.AddWithValue("@Total10", factura.Total10);
                command.Parameters.AddWithValue("@Totaliva", factura.Totaliva);
                command.Parameters.AddWithValue("@Totalletras", factura.Totalletras);
                command.Parameters.AddWithValue("@Sucursal", factura.Sucursal);
                command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al insertar factura: " + ex.Message);
        }
    }

    public Factura ObtenerFacturaPorId(int id)
    {
        try
        {
            string query = "SELECT * FROM \"Factura\" WHERE \"Idfactura\" = @Id";
            using (var command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Factura
                        {
                            Idfactura = reader.GetInt32(reader.GetOrdinal("Idfactura")),
                            Idcliente = reader.GetInt32(reader.GetOrdinal("Idcliente")),
                            Nrofactura = reader.GetString(reader.GetOrdinal("Nrofactura")),
                            Fechahora = reader.GetString(reader.GetOrdinal("Fechahora")),
                            Total = reader.GetDecimal(reader.GetOrdinal("Total")),
                            Total5 = reader.GetDecimal(reader.GetOrdinal("Total5")),
                            Total10 = reader.GetDecimal(reader.GetOrdinal("Total10")),
                            Totaliva = reader.GetDecimal(reader.GetOrdinal("totaliva")),
                            Totalletras = reader.GetString(reader.GetOrdinal("Totalletras")),
                            Sucursal = reader.GetString(reader.GetOrdinal("Sucursal"))
                        };
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al obtener factura: " + ex.Message);
        }
        return null;
    }

    public List<Factura> ObtenerTodasLasFacturas()
    {
        var facturas = new List<Factura>();
        try
        {
            string query = "SELECT * FROM \"Factura\"";
            using (var command = new NpgsqlCommand(query, _connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        facturas.Add(new Factura
                        {
                            Idfactura = reader.GetInt32(reader.GetOrdinal("Idfactura")),
                            Idcliente = reader.GetInt32(reader.GetOrdinal("Idcliente")),
                            Nrofactura = reader.GetString(reader.GetOrdinal("Nrofactura")),
                            Fechahora = reader.GetString(reader.GetOrdinal("Fechahora")),
                            Total = reader.GetDecimal(reader.GetOrdinal("Total")),
                            Total5 = reader.GetDecimal(reader.GetOrdinal("Total5")),
                            Total10 = reader.GetDecimal(reader.GetOrdinal("Total10")),
                            Totaliva = reader.GetDecimal(reader.GetOrdinal("totaliva")),
                            Totalletras = reader.GetString(reader.GetOrdinal("Totalletras")),
                            Sucursal = reader.GetString(reader.GetOrdinal("Sucursal"))
                        });
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al obtener facturas: " + ex.Message);
        }
        return facturas;
    }

    public void ActualizarFactura(Factura factura)
    {
        try
        {
            string query = "UPDATE \"Factura\" SET \"Idcliente\" = @Idcliente, \"Nrofactura\" = @Nrofactura, \"Fechahora\" = @Fechahora, \"Total\" = @Total, \"Total5\" = @Total5, \"Total10\" = @Total10, totaliva = @Totaliva, \"Totalletras\" = @Totalletras, \"Sucursal\" = @Sucursal WHERE \"Idfactura\" = @Idfactura";
            using (var command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@Idfactura", factura.Idfactura);
                command.Parameters.AddWithValue("@Idcliente", factura.Idcliente);
                command.Parameters.AddWithValue("@Nrofactura", factura.Nrofactura);
                command.Parameters.AddWithValue("@Fechahora", factura.Fechahora);
                command.Parameters.AddWithValue("@Total", factura.Total);
                command.Parameters.AddWithValue("@Total5", factura.Total5);
                command.Parameters.AddWithValue("@Total10", factura.Total10);
                command.Parameters.AddWithValue("@Totaliva", factura.Totaliva);
                command.Parameters.AddWithValue("@Totalletras", factura.Totalletras);
                command.Parameters.AddWithValue("@Sucursal", factura.Sucursal);
                command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al actualizar factura: " + ex.Message);
        }
    }

    public void EliminarFactura(int id)
    {
        try
        {
            string query = "DELETE FROM \"Factura\" WHERE \"Idfactura\" = @Id";
            using (var command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al eliminar factura: " + ex.Message);
        }
    }
}*/
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

