/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using NpgsqlTypes;

namespace Opta3.Repositorio
{
    public class Clienterepositorio
    {
        NpgsqlConnection connection;

        public Clienterepositorio(string connectionString)
        {
            connection = new NpgsqlConnection(connectionString);
            connection.Open();
        }

        public bool Add(Cliente cliente)
        {
            try
            {
                using var cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO public.cliente (Nombre, Apellido, Documento, Mail, Celular, Estado) " +
                                  "VALUES (@Nombre, @Apellido, @Documento, @Mail, @Celular, @Estado)";
                cmd.Parameters.AddWithValue("@Nombre", NpgsqlDbType.Varchar, cliente.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", NpgsqlDbType.Varchar, cliente.Apellido);
                cmd.Parameters.AddWithValue("@Documento", NpgsqlDbType.Varchar, cliente.Documento);
                cmd.Parameters.AddWithValue("@Mail", NpgsqlDbType.Varchar, cliente.Mail);
                cmd.Parameters.AddWithValue("@Celular", NpgsqlDbType.Varchar, cliente.Celular);
                cmd.Parameters.AddWithValue("@Estado", NpgsqlDbType.Varchar, cliente.Estado);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Cliente cliente)
        {
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Cliente SET Nombre = @Nombre, Apellido = @Apellido, " +
                                      "Documento = @Documento, Mail = @Mail, Celular = @Celular, Estado = @Estado " +
                                      "WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("Nombre", cliente.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", cliente.Apellido);
                    cmd.Parameters.AddWithValue("Documento", cliente.Documento);
                    cmd.Parameters.AddWithValue("Mail", cliente.Mail);
                    cmd.Parameters.AddWithValue("Celular", cliente.Celular);
                    cmd.Parameters.AddWithValue("Estado", cliente.Estado);
                    cmd.Parameters.AddWithValue("Id", cliente.Id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Cliente WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Cliente Get(int id)
        {
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Cliente WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("Id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Cliente(
                             
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetString(3),
                                reader.GetString(4),
                                reader.GetString(5),
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

        public List<Cliente> List()
        {
            List<Cliente> cliente = new List<Cliente>();

            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Cliente";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cliente Cliente = new Cliente(
                           
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetString(3),
                                reader.GetString(4),
                                reader.GetString(5),
                                reader.GetString(6),
                                reader.GetString(7)
                            );
                            cliente.Add(Cliente);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return cliente;
        }
    }
}*/
/*using Npgsql;
using Opta3.Modelo;
using System;
using System.Collections.Generic;

public class ClienteRepository
{
    private readonly NpgsqlConnection _connection;

    public ClienteRepository(NpgsqlConnection connection)
    {
        _connection = connection;
    }

    public void InsertarCliente(Cliente cliente)
    {
        try
        {
            string query = "INSERT INTO \"Cliente\" (\"Idbanco\", \"Nombre\", \"Apellido\", \"Documento\", \"Direccion\", \"Mail\", \"Celular\", \"Estado\") VALUES (@Idbanco, @Nombre, @Apellido, @Documento, @Direccion, @Mail, @Celular, @Estado)";
            using (var command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@Idbanco", cliente.Idbanco);
                command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                command.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                command.Parameters.AddWithValue("@Documento", cliente.Documento);
                command.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                command.Parameters.AddWithValue("@Mail", cliente.Mail);
                command.Parameters.AddWithValue("@Celular", cliente.Celular);
                command.Parameters.AddWithValue("@Estado", cliente.Estado);
                command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al insertar cliente: " + ex.Message);
        }
    }

    public Cliente ObtenerClientePorId(int id)
    {
        try
        {
            string query = "SELECT * FROM \"Cliente\" WHERE id = @Id";
            using (var command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Cliente
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            Idbanco = reader.GetInt32(reader.GetOrdinal("Idbanco")),
                            Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                            Apellido = reader.GetString(reader.GetOrdinal("Apellido")),
                            Documento = reader.GetString(reader.GetOrdinal("Documento")),
                            Direccion = reader.GetString(reader.GetOrdinal("Direccion")),
                            Mail = reader.GetString(reader.GetOrdinal("Mail")),
                            Celular = reader.GetString(reader.GetOrdinal("Celular")),
                            Estado = reader.GetString(reader.GetOrdinal("Estado"))
                        };
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al obtener cliente: " + ex.Message);
        }
        return null;
    }

    public List<Cliente> ObtenerTodosLosClientes()
    {
        var clientes = new List<Cliente>();
        try
        {
            string query = "SELECT * FROM \"Cliente\"";
            using (var command = new NpgsqlCommand(query, _connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clientes.Add(new Cliente
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            Idbanco = reader.GetInt32(reader.GetOrdinal("Idbanco")),
                            Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                            Apellido = reader.GetString(reader.GetOrdinal("Apellido")),
                            Documento = reader.GetString(reader.GetOrdinal("Documento")),
                            Direccion = reader.GetString(reader.GetOrdinal("Direccion")),
                            Mail = reader.GetString(reader.GetOrdinal("Mail")),
                            Celular = reader.GetString(reader.GetOrdinal("Celular")),
                            Estado = reader.GetString(reader.GetOrdinal("Estado"))
                        });
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al obtener clientes: " + ex.Message);
        }
        return clientes;
    }

    public void ActualizarCliente(Cliente cliente)
    {
        try
        {
            string query = "UPDATE \"Cliente\" SET \"Idbanco\" = @Idbanco, \"Nombre\" = @Nombre, \"Apellido\" = @Apellido, \"Documento\" = @Documento, \"Direccion\" = @Direccion, \"Mail\" = @Mail, \"Celular\" = @Celular, \"Estado\" = @Estado WHERE id = @Id";
            using (var command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@Id", cliente.Id);
                command.Parameters.AddWithValue("@Idbanco", cliente.Idbanco);
                command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                command.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                command.Parameters.AddWithValue("@Documento", cliente.Documento);
                command.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                command.Parameters.AddWithValue("@Mail", cliente.Mail);
                command.Parameters.AddWithValue("@Celular", cliente.Celular);
                command.Parameters.AddWithValue("@Estado", cliente.Estado);
                command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al actualizar cliente: " + ex.Message);
        }
    }

    public void EliminarCliente(int id)
    {
        try
        {
            string query = "DELETE FROM \"Cliente\" WHERE id = @Id";
            using (var command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al eliminar cliente: " + ex.Message);
        }
    }
}*/
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
