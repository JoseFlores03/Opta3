/*using System;
using System.Data;
using Dapper;
using Npgsql;
using Opta3.Modelo;
using Opta3.Repositorio;
using Servicios;
using System.Collections.Generic;
using Opta3.Modelos;

public class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Host=localhost;Port=5432;Database=optativo3;Username=postgres;Password=0000;";
        var databaseConnection = new DatabaseConnection(connectionString);

        using (var connection = databaseConnection.CreateConnection())
        {
            var pedidoCompraRepository = new PedidoCompraRepository(connection);
            var sucursalRepository = new SucursalRepository(connection);
            var detallePedidoRepository = new DetallePedidoRepository(connection);
            var productoRepository = new ProductoRepository(connection);
            var proveedorRepository = new ProveedorRepository(connection);

            var pedidoCompraService = new PedidoCompraService(pedidoCompraRepository, detallePedidoRepository);
            var sucursalService = new SucursalService(sucursalRepository);
            var detallePedidoService = new DetallePedidoService(detallePedidoRepository);
            var productoService = new ProductoService(productoRepository);
            var proveedorService = new ProveedorService(proveedorRepository);

            // Ejemplo de operaciones con cliente
            var cliente = new Cliente
            {
                Id = 52,
                Idbanco = 2,
                Nombre = "Jamin",
                Apellido = "Perez",
                Documento = "5050321",
                Direccion = "Av Gral Silva",
                Mail = "jazperez@hotmail.com",
                Celular = "0982000000",
                Estado = "Activo"
            };
            clienteService.InsertarCliente(cliente);
            var clienteLeido = clienteService.ObtenerClientePorId(cliente.Id);
            Console.WriteLine($"Cliente leído: {clienteLeido?.Nombre} {clienteLeido?.Apellido}");

            // Ejemplo de operaciones con sucursal
            var sucursal = new Sucursal
            {
                Id = 21,
                Descripcion = "Sucursal HospiCenter",
                Direccion = "Avenida America",
                Telefono = "0987111333",
                Whatsapp = "0987222900",
                Mail = "centerhospi@gmail.com",
                Estado = "Activa"
            };
            sucursalService.InsertarSucursal(sucursal);
            var sucursalLeida = sucursalService.ObtenerSucursalPorId(sucursal.Id);
            Console.WriteLine($"Sucursal leída: {sucursalLeida?.Descripcion}");

            // Ejemplo de operaciones con producto
            var producto = new Producto
            {
                Id = 1,
                Descripcion = "Auriculares Inalambricos",
                Cantminima = 10,
                Preciocompra = 50,
                Precioventa = 75,
                Categoria = "Electrónica",
                Marca = "Samsung",
                Estado = "Activo"
            };

            try
            {
                productoService.InsertarProducto(producto);
                Console.WriteLine("Producto insertado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar producto: {ex.Message}");
            }

            // Asegúrate de obtener el producto insertado para usar su ID
            var productoLeido = productoService.ObtenerProductoPorId(producto.Id);
            if (productoLeido == null)
            {
                Console.WriteLine("No se pudo obtener el producto recién insertado.");
                return;
            }

            // Asegurarse de que existen las referencias necesarias antes de insertar el pedido
            if (clienteLeido != null && sucursalLeida != null)
            {
                // Ejemplo de operaciones con pedido
                var pedido = new Pedidocompra
                {
                    Id = 19,
                    IdCliente = clienteLeido.Id,
                    FechaHora = DateTime.Now,
                    Total = 100.0m,
                    IdSucursal = sucursalLeida.Id
                };
                pedidoCompraService.InsertarPedidoCompra(pedido);
                var pedidoLeido = pedidoCompraService.ObtenerPedidoCompraPorId(pedido.Id);
                Console.WriteLine($"Pedido leído: {pedidoLeido?.Id}");

                // Ejemplo de operaciones con detalle del pedido
                var detallePedido = new Detallepedido
                {
                    Id = 2,
                    IdPedidoCompra = pedidoLeido.Id,
                    IdProducto = productoLeido.Id,
                    Cantidad = 5,
                    PrecioCompra = 50
                };
                detallePedidoService.InsertarDetallePedido(detallePedido);
                var detallePedidoLeido = detallePedidoService.ObtenerDetallePedidoPorId(detallePedido.Id);
                Console.WriteLine($"Detalle pedido leído: {detallePedidoLeido?.Cantidad}");
            }

            // Listar todos los datos de las tablas
            ListarDatos(connection, "Cliente");
            ListarDatos(connection, "Sucursal");
            ListarDatos(connection, "PedidoCompra");
            ListarDatos(connection, "Producto");
            ListarDatos(connection, "DetallePedido");
        }
    }

    static void ListarDatos(IDbConnection connection, string tableName)
    {
        string sql = $"SELECT * FROM \"{tableName}\"";
        var results = connection.Query(sql);

        Console.WriteLine($"Datos de la tabla {tableName}:");
        foreach (var row in results)
        {
            foreach (var column in row)
            {
                Console.Write($"{column.Key}: {column.Value}\t");
            }
            Console.WriteLine();
        }
    }
}

public class DatabaseConnection
{
    private readonly string _connectionString;

    public DatabaseConnection(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection CreateConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}*/
/*using System;
using System.Data;
using Npgsql;
using Opta3.Modelo;
using Opta3.Modelos;
using Opta3.Repositorio;
using Opta3.Servicio;

namespace Opta3
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Host=localhost;Port=5432;Database=optativo3;Username=postgres;Password=0000;";
            IDbConnection connection = new NpgsqlConnection(connectionString);

            // Crear repositorios y servicios
            ProveedorRepositorio proveedorRepositorio = new ProveedorRepositorio(connection);
            ProveedorServicio proveedorServicio = new ProveedorServicio(proveedorRepositorio);

            PedidocompraRepositorio pedidocompraRepositorio = new PedidocompraRepositorio(connection);
            PedidocompraServicio pedidocompraServicio = new PedidocompraServicio(pedidocompraRepositorio);

            ProductoRepositorio productoRepositorio = new ProductoRepositorio(connection);
            ProductoServicio productoServicio = new ProductoServicio(productoRepositorio);

            SucursalRepositorio sucursalRepositorio = new SucursalRepositorio(connection);
            SucursalServicio sucursalServicio = new SucursalServicio(sucursalRepositorio);

            DetallepedidoRepositorio detallepedidoRepositorio = new DetallepedidoRepositorio(connection);
            DetallepedidoServicio detallepedidoServicio = new DetallepedidoServicio(detallepedidoRepositorio);

            // Ejemplo de uso de servicios
            try
            {
                // Insertar Proveedor
                Proveedor nuevoProveedor = new Proveedor
                {
                    Razonsocial = "Proveedor 1",
                    Tipodocumento = "RUC",
                    Documento = "123456789",
                    Direccion = "Calle Falsa 123",
                    Mail = "proveedor1@example.com",
                    Celular = "0981123456",
                    Estado = "Activo"
                };
                proveedorServicio.Insertar(nuevoProveedor);
                Console.WriteLine("Proveedor insertado exitosamente.");

                // Insertar Sucursal
                Sucursal nuevaSucursal = new Sucursal
                {
                    Descripcion = "Sucursal Central",
                    Direccion = "Avenida Principal 456",
                    Telefono = "0211234567",
                    Whatsapp = "0987654321",
                    Mail = "sucursal1@example.com",
                    Estado = "Activo"
                };
                sucursalServicio.Insertar(nuevaSucursal);
                Console.WriteLine("Sucursal insertada exitosamente.");

                // Insertar Producto
                Producto nuevoProducto = new Producto
                {
                    Descripcion = "Producto A",
                    Cantminima = "10",
                    Preciocompra = 50,
                    Precioventa = "75",
                    Categoria = "Categoria 1",
                    Marca = "Marca X",
                    Estado = "Disponible",
                    Cantstock = "100"
                };
                productoServicio.Insertar(nuevoProducto);
                Console.WriteLine("Producto insertado exitosamente.");

                // Insertar Pedido de Compra
                Pedidocompra nuevoPedidocompra = new Pedidocompra
                {
                    Idproveedor = 1, // Asumiendo que el proveedor con Id = 1 existe
                    Idsucursal = 1, // Asumiendo que la sucursal con Id = 1 existe
                    Fechahora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Total = 500
                };
                pedidocompraServicio.Insertar(nuevoPedidocompra);
                Console.WriteLine("Pedido de compra insertado exitosamente.");

                // Insertar Detalle de Pedido
                Detallepedido nuevoDetallepedido = new Detallepedido
                {
                    Idpedido = 1, // Asumiendo que el pedido con Id = 1 existe
                    Idproducto = 1, // Asumiendo que el producto con Id = 1 existe
                    Cantproducto = 5,
                    Subtotal = 250
                };
                detallepedidoServicio.Insertar(nuevoDetallepedido);
                Console.WriteLine("Detalle de pedido insertado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}*/

using System;
using System.Data;
using Npgsql;
using Opta3.Modelo;
using Opta3.Modelos;
using Opta3.Repositorio;
using Opta3.Servicio;

namespace Opta3
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Host=localhost;Port=5432;Database=optativo3;Username=postgres;Password=0000;";
            IDbConnection connection = new NpgsqlConnection(connectionString);

            // Crear repositorios y servicios
            ProveedorRepositorio proveedorRepositorio = new ProveedorRepositorio(connection);
            ProveedorServicio proveedorServicio = new ProveedorServicio(proveedorRepositorio);

            PedidocompraRepositorio pedidocompraRepositorio = new PedidocompraRepositorio(connection);
            PedidocompraServicio pedidocompraServicio = new PedidocompraServicio(pedidocompraRepositorio);

            ProductoRepository productoRepositorio = new ProductoRepository(connection);
            ProductoServicio productoServicio = new ProductoServicio(productoRepositorio);

            SucursalRepositorio sucursalRepositorio = new SucursalRepositorio(connection);
            SucursalServicio sucursalServicio = new SucursalServicio(sucursalRepositorio);

            DetallepedidoRepositorio detallepedidoRepositorio = new DetallepedidoRepositorio(connection);
            DetallepedidoServicio detallepedidoServicio = new DetallepedidoServicio(detallepedidoRepositorio);

            // Ejemplo de uso de servicios
            try
            {
                // Insertar Proveedor
                Proveedor nuevoProveedor = new Proveedor
                {
                    Razonsocial = "Proveedor 2",
                    Tipodocumento = "RUC",
                    Documento = "999666112",
                    Direccion = "Av Uruguay",
                    Mail = "proveedor2exp@example.com",
                    Celular = "0981123456",
                    Estado = "Inactivo"
                };
                proveedorServicio.Insertar(nuevoProveedor);
                Console.WriteLine("Proveedor insertado exitosamente.");

                // Insertar Sucursal
                Sucursal nuevaSucursal = new Sucursal
                {
                    Id = 24, // Asigna manualmente el Id
                    Descripcion = "Sucursal Galeria 3",
                    Direccion = "Avenida Aviadores norte",
                    Telefono = "0211234567",
                    Whatsapp = "0987654321",
                    Mail = "sucursalgale@example.com",
                    Estado = "Inactivo"
                };
                sucursalServicio.Insertar(nuevaSucursal);
                Console.WriteLine($"Sucursal insertada exitosamente con Id {nuevaSucursal.Id}.");

                // Insertar Producto
                Producto nuevoProducto = new Producto
                {
                    Id=1,
                    Descripcion = "Botines",
                    Cantminima = "10",
                    Preciocompra = 50,
                    Precioventa = "75",
                    Categoria = "Deportes",
                    Marca = "Marca Nike",
                    Estado = "Disponible",
                    Cantstock = "100"
                };
                productoServicio.Insertar(nuevoProducto);
                Console.WriteLine("Producto insertado exitosamente.");

                // Insertar Pedido de Compra
                Pedidocompra nuevoPedidocompra = new Pedidocompra
                {
                    Idproveedor = 1, // Asumiendo que el proveedor con Id = 1 existe
                    Idsucursal = 1, // Asumiendo que la sucursal con Id = 1 existe
                    Fechahora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Total = 500
                };
                pedidocompraServicio.Insertar(nuevoPedidocompra);
                Console.WriteLine("Pedido de compra insertado exitosamente.");

                // Insertar Detalle de Pedido
                Detallepedido nuevoDetallepedido = new Detallepedido
                {
                    Idpedido = 1, // Asumiendo que el pedido con Id = 1 existe
                    Idproducto = 1, // Asumiendo que el producto con Id = 1 existe
                    Cantproducto = 5,
                    Subtotal = 250
                };
                detallepedidoServicio.Insertar(nuevoDetallepedido);
                Console.WriteLine("Detalle de pedido insertado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
