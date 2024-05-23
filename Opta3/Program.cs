/*using System;
using opta3.Repositorio;
using Opta3.Repositorio;

    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Host=localhost;port=5432;Database=optativo3;Username=postgres;Password=0000;";

            // Crear instancias de los servicios de cliente y factura
            Clienterepositorio clienterepositorio = new Clienterepositorio(connectionString);
            Facturarepositorio facturarepositorio = new Facturarepositorio(connectionString);

            // Ejemplo de uso
            Cliente nuevoCliente = new Cliente("Juan", "Perez", "1234567890", "Dirección", "correo@ejemplo.com", "1234567890", "activo");
            clienterepositorio.Add(nuevoCliente);

            // Obtener todas las facturas y mostrarlas en la consola
            Console.WriteLine("Lista de facturas:");
            foreach (var factura in facturarepositorio.ObtenerFacturas())
            {
                Console.WriteLine($"ID: {factura.Id}, Número: {factura.Nrofactura}, Total: {factura.Total}");
            }
            servicioCliente.AgregarCliente(new ClienteModelo(...));
            // servicioFactura.AgregarFactura(new FacturaModelo(...));



            Console.WriteLine("Operaciones completada");
        }
    }*/
/*using System;
using Npgsql;
using System.Collections.Generic;
using Opta3.Modelo;

namespace Opta3
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Host=localhost;port=5432;Database=optativo3;Username=postgres;Password=0000;";
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                var clienteRepository = new ClienteRepository(connection);
                var facturaRepository = new FacturaRepository(connection);

                var clienteService = new ClienteService(clienteRepository);
                var facturaService = new FacturaService(facturaRepository);

                // Crear cliente de ejemplo
                var cliente = new Cliente(1, "Jose", "gimenez", "4567333", "Mcal Lopez", "juan@example.com", "123456789", "Inactivo");
                clienteService.InsertarCliente(cliente);

                // Crear factura de ejemplo
                var factura = new Factura(2, 1, "0001-000001", "2023-07-22 10:00:00", 100.0m, 5.0m, 10.0m, 15.0m, "Cien", "Sucursal 2");
                facturaService.InsertarFactura(factura);

                /* Leer cliente por Id leído: {clienteLeido?.Nombre} {clienteLeido?.Apellido}");

                // Leer todos los clientes
                var clienteLeido = clienteService.ObtenerClientePorId(1);
                Console.WriteLine($"Cliente error {clienteLeido}");
                var todosLosClientes = clienteService.ObtenerTodosLosClientes();
                Console.WriteLine("Todos los clientes:");
                foreach (var c in todosLosClientes)
                {
                    Console.WriteLine($"{c.Nombre} {c.Apellido}");
                }

                // Leer factura por Id
                var facturaLeida = facturaService.ObtenerFacturaPorId(factura.Idfactura);
                Console.WriteLine($"Factura leída: {facturaLeida?.Nrofactura}");

                // Leer todas las facturas
                var todasLasFacturas = facturaService.ObtenerTodasLasFacturas();
                Console.WriteLine("Todas las facturas:");
                foreach (var f in todasLasFacturas)
                {
                    Console.WriteLine($"{f.Nrofactura}");
                }

                // Actualizar cliente
                cliente.Nombre = "Juan Actualizado";
                clienteService.ActualizarCliente(cliente);
                Console.WriteLine("Cliente actualizado");

                // Actualizar factura
                factura.Nrofactura = "0001-000002";
                facturaService.ActualizarFactura(factura);
                Console.WriteLine("Factura actualizada");

                // Eliminar cliente
                clienteService.EliminarCliente(cliente.Id);
                Console.WriteLine("Cliente eliminado");

                // Eliminar factura
                facturaService.EliminarFactura(factura.Idfactura);
                Console.WriteLine("Factura eliminada");

                Console.WriteLine("Operaciones completadas");
            }
        }
    }

}*/
/*using System;
using Repositorio;
using Servicios;
using Npgsql;
using Opta3.Modelo;
using Modelos;
using Opta3;
using Opta3.Repositorio;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Host=localhost;Port=5432;Database=optativo3;Username=postgres;Password=0000;";
        var databaseConnection = new DatabaseConnection(connectionString);

        using (var connection = databaseConnection.CreateConnection())
        {
            var clienteRepository = new ClienteRepository(connection);
            var facturaRepository = new FacturaRepository(connection);
            var sucursalRepository = new SucursalRepository(connection);

            var clienteService = new ClienteService(clienteRepository);
            var facturaService = new FacturaService(facturaRepository);
            var sucursalService = new SucursalService(sucursalRepository);

            // Ejemplo de operaciones con cliente
            var cliente = new Cliente
            {
                Idbanco = 3,
                Nombre = "Juan",
                Apellido = "Pérez",
                Documento = "12345678",
                Direccion = "Calle Falsa 123",
                Mail = "juan@example.com",
                Celular = "1234567890",
                Estado = "Activo"
            };
            clienteService.InsertarCliente(cliente);
            var clienteLeido = clienteService.ObtenerClientePorId(cliente.Id);
            Console.WriteLine($"Cliente leído: {clienteLeido?.Nombre} {clienteLeido?.Apellido}");

            // Ejemplo de operaciones con factura
            var factura = new Factura
            {
                Idcliente = 4,
                Nrofactura = "001-001-000001",
                Fechahora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                Total = 100.0m,
                Total5 = 5.0m,
                Total10 = 10.0m,
                Totaliva = 15.0m,
                Totalletras = "Cien mil trescientos",
                Sucursal = "Sucursal 1",
                Idsucursal = 1
            };
            facturaService.InsertarFactura(factura);
            var facturaLeida = facturaService.ObtenerFacturaPorId(factura.Idfactura);
            Console.WriteLine($"Factura leída: {facturaLeida?.Nrofactura}");

            // Ejemplo de operaciones con sucursal
            var sucursal = new Sucursal
            {
               
                Descripcion = "Sucursal Mcal lopez",
                Direccion = "Avenida Principal 1234",
                Telefono = "0987654321",
                Whatsapp = "0987654321",
                Mail = "contacto@sucursal.com",
                Estado = "Activa"
            };
            sucursalService.InsertarSucursal(sucursal);
            var sucursalLeida = sucursalService.ObtenerSucursalPorId(sucursal.Id);
            Console.WriteLine($"Sucursal leída: {sucursalLeida?.Descripcion}");

            Console.WriteLine("Operaciones completadas");
        }
    }
}*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Dapper;
using Npgsql;
using System.Data;
using Opta3.Modelo;
using Opta3.Repositorio;
using Repositorio;
using Opta3.Modelos;
using Opta3;
using Servicios;

public class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Host=localhost;Port=5432;Database=optativo3;Username=postgres;Password=0000;";
        var databaseConnection = new DatabaseConnection(connectionString);

        using (var connection = databaseConnection.CreateConnection())
        {
            var clienteRepository = new ClienteRepository(connection);
            var facturaRepository = new FacturaRepository(connection);
            var sucursalRepository = new SucursalRepository(connection);

            var clienteService = new ClienteService(clienteRepository);
            var facturaService = new FacturaService(facturaRepository);
            var sucursalService = new SucursalService(sucursalRepository);

            // Ejemplo de operaciones con cliente
            var cliente = new Cliente
            {
                Id = 24,
                Idbanco = 2,
                Nombre = "andres",
                Apellido = "ugarte",
                Documento = "5050321",
                Direccion = "Av moreira Lopez",
                Mail = "gonzape@gmail.com",
                Celular = "0982347112",
                Estado = "inactivo"
            };
            clienteService.InsertarCliente(cliente);
            var clienteLeido = clienteService.ObtenerClientePorId(cliente.Id);
            Console.WriteLine($"Cliente leído: {clienteLeido?.Nombre} {clienteLeido?.Apellido}");

            // Ejemplo de operaciones con sucursal
            var sucursal = new Sucursal
            {
                Id = 7,  
                Descripcion = "Sucursal S10",
                Direccion = "Avenida peru",
                Telefono = "09876543212",
                Whatsapp = "09876543212",
                Mail = "contactosucperez@gmail.com",
                Estado = "Inactiva"
            };
            sucursalService.InsertarSucursal(sucursal);
            var sucursalLeida = sucursalService.ObtenerSucursalPorId(sucursal.Id);
            Console.WriteLine($"Sucursal leída: {sucursalLeida?.Descripcion}");

            // Asegurarse de que existen las referencias necesarias antes de insertar la factura
            if (clienteLeido != null && sucursalLeida != null)
            {
                // Ejemplo de operaciones con factura
                var factura = new Factura
                {
                    Idfactura = 6,
                    Idcliente = clienteLeido.Id,
                    Nrofactura = "001-001-187221",
                    Fechahora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Total = 100.0m,
                    Total5 = 5.0m,
                    Total10 = 10.0m,
                    Totaliva = 15.0m,
                    Totalletras = "Cien mil trescientos",
                    Sucursal = "Sucursal 1",
                    Idsucursal = sucursalLeida.Id
                };
                facturaService.InsertarFactura(factura);
                var facturaLeida = facturaService.ObtenerFacturaPorId(factura.Idfactura);
                Console.WriteLine($"Factura leída: {facturaLeida?.Nrofactura}");
            }
            else
            {
                Console.WriteLine("No se puede insertar la factura debido a referencias inválidas.");
            }

            Console.WriteLine("Operaciones completadas");
        }
        /*static void Main(string[] args)
        {
            string connectionString = "Host=localhost;Port=5432;Database=optativo3;Username=postgres;Password=0000;";
            var databaseConnection = new DatabaseConnection(connectionString);

            using (var connection = databaseConnection.CreateConnection())
            {
                var clienteRepository = new ClienteRepository(connection);
                var facturaRepository = new FacturaRepository(connection);
                var sucursalRepository = new SucursalRepository(connection);

                var clienteService = new ClienteService(clienteRepository);
                var facturaService = new FacturaService(facturaRepository);
                var sucursalService = new SucursalService(sucursalRepository);

                // Pruebas de CRUD para Cliente
                var nuevoCliente = new Cliente
                {
                    Id = 32,
                    Idbanco = 6,
                    Nombre = "Gatito Fernandez",
                    Apellido = "Perez",
                    Documento = "12345678",
                    Direccion = "Aviadores 321",
                    Mail = "juan.perez@example.com",
                    Celular = "5551234567",
                    Estado = "Activo"
                };
                clienteService.InsertarCliente(nuevoCliente);
                var clienteLeido = clienteService.ObtenerClientePorId(nuevoCliente.Id);
                Console.WriteLine($"Cliente leído: {clienteLeido?.Nombre} {clienteLeido?.Apellido}");

                nuevoCliente.Nombre = "Juan Carlos";
                clienteService.ActualizarCliente(nuevoCliente);
                var clienteActualizado = clienteService.ObtenerClientePorId(nuevoCliente.Id);
                Console.WriteLine($"Cliente actualizado: {clienteActualizado?.Nombre} {clienteActualizado?.Apellido}");

                clienteService.EliminarCliente(nuevoCliente.Id);
                var clienteEliminado = clienteService.ObtenerClientePorId(nuevoCliente.Id);
                Console.WriteLine($"Cliente eliminado: {clienteEliminado == null}");

                // Pruebas de CRUD para Sucursal
                var nuevaSucursal = new Sucursal
                {
                    Id = 7,
                    Descripcion = "Sucursal Central",
                    Direccion = "Av. Principal 123",
                    Telefono = "55598765430",
                    Whatsapp = "55598765430",
                    Mail = "contactosporote@sucursal.com",
                    Estado = "Activa"
                };
                sucursalService.InsertarSucursal(nuevaSucursal);
                var sucursalLeida = sucursalService.ObtenerSucursalPorId(nuevaSucursal.Id);
                Console.WriteLine($"Sucursal leída: {sucursalLeida?.Descripcion}");

                nuevaSucursal.Descripcion = "Sucursal carapegua";
                sucursalService.ActualizarSucursal(nuevaSucursal);
                var sucursalActualizada = sucursalService.ObtenerSucursalPorId(nuevaSucursal.Id);
                Console.WriteLine($"Sucursal actualizada: {sucursalActualizada?.Descripcion}");

                sucursalService.EliminarSucursal(nuevaSucursal.Id);
                var sucursalEliminada = sucursalService.ObtenerSucursalPorId(nuevaSucursal.Id);
                Console.WriteLine($"Sucursal eliminada: {sucursalEliminada == null}");

                // Pruebas de CRUD para Factura
                var nuevaFactura = new Factura
                {
                    Idfactura = 5,
                    Idcliente = nuevoCliente.Id,
                    Nrofactura = "001-001-000001",
                    Fechahora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Total = 200.0m,
                    Total5 = 10.0m,
                    Total10 = 20.0m,
                    Totaliva = 30.0m,
                    Totalletras = "Doscientos quince",
                    Sucursal = "Sucursal oriente",
                    Idsucursal = nuevaSucursal.Id
                };
                facturaService.InsertarFactura(nuevaFactura);
                var facturaLeida = facturaService.ObtenerFacturaPorId(nuevaFactura.Idfactura);
                Console.WriteLine($"Factura leída: {facturaLeida?.Nrofactura}");

                nuevaFactura.Nrofactura = "231-991-000002024";
                facturaService.ActualizarFactura(nuevaFactura);
                var facturaActualizada = facturaService.ObtenerFacturaPorId(nuevaFactura.Idfactura);
                Console.WriteLine($"Factura actualizada: {facturaActualizada?.Nrofactura}");

                facturaService.EliminarFactura(nuevaFactura.Idfactura);
                var facturaEliminada = facturaService.ObtenerFacturaPorId(nuevaFactura.Idfactura);
                Console.WriteLine($"Factura eliminada: {facturaEliminada == null}");

                Console.WriteLine("Pruebas de CRUD completadas");
            }
        }*/
    }

}
