/*using System;
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
        }*
    }

}*/
/*using System;
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
            var detallefacturaRepository = new DetallefacturaRepository(connection);
            var productoRepository = new ProductoRepository(connection);

            var clienteService = new ClienteService(clienteRepository);
            var facturaService = new FacturaService(facturaRepository);
            var sucursalService = new SucursalService(sucursalRepository);
            var detallefacturaService = new DetallefacturaService(detallefacturaRepository);
            var productoService = new ProductoService(productoRepository);

            // Ejemplo de operaciones con cliente
            var cliente = new Cliente
            {
                Id = 36,
                Idbanco = 4,
                Nombre = "andres",
                Apellido = "perez",
                Documento = "5050321",
                Direccion = "Av Lopez silva",
                Mail = "andrespe@hotmail.com",
                Celular = "0982666999",
                Estado = "Activo"
            };
            clienteService.InsertarCliente(cliente);
            var clienteLeido = clienteService.ObtenerClientePorId(cliente.Id);
            Console.WriteLine($"Cliente leído: {clienteLeido?.Nombre} {clienteLeido?.Apellido}");

            // Ejemplo de operaciones con sucursal
            var sucursal = new Sucursal
            {
                Id = 8,
                Descripcion = "Sucursal Max Center",
                Direccion = "Avenida brasil",
                Telefono = "0987222444",
                Whatsapp = "0987899123",
                Mail = "centermax1@gmail.com",
                Estado = "Activa"
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
                    Idfactura = 7,
                    Idcliente = clienteLeido.Id,
                    Nrofactura = "001-001-187221",
                    Fechahora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Total = 100.0m,
                    Total5 = 5.0m,
                    Total10 = 10.0m,
                    Totaliva = 15.0m,
                    Totalletras = "Cien mil ",
                    Sucursal = "Sucursal Max Center",
                    Idsucursal = sucursalLeida.Id
                };
                facturaService.InsertarFactura(factura);
                var facturaLeida = facturaService.ObtenerFacturaPorId(factura.Idfactura);
                Console.WriteLine($"Factura leída: {facturaLeida?.Nrofactura}");

                // Ejemplo de operaciones con detallefactura
                var detallefactura = new Detallefactura
                {
                    Id = 1,
                    Idfactura = facturaLeida.Idfactura,
                    Idproducto = 1,
                    Cantproducto = "5",
                    Subtotal = 50
                };
                detallefacturaService.InsertarDetallefactura(detallefactura);
                var detallefacturaLeida = detallefacturaService.ObtenerDetallefacturaPorId(detallefactura.Idfactura);
                Console.WriteLine($"Detalle factura leído: {detallefacturaLeida?.Cantproducto}");

                // Actualizar y eliminar ejemplo de operaciones con detallefactura
                detallefactura.Cantproducto = "10";
                detallefacturaService.ActualizarDetallefactura(detallefactura);
                var detallefacturaActualizada = detallefacturaService.ObtenerDetallefacturaPorId(detallefactura.Idfactura);
                Console.WriteLine($"Detalle factura actualizado: {detallefacturaActualizada?.Cantproducto}");

                detallefacturaService.EliminarDetallefactura(detallefactura.Idfactura);
                var detallefacturaEliminada = detallefacturaService.ObtenerDetallefacturaPorId(detallefactura.Idfactura);
                Console.WriteLine($"Detalle factura eliminada: {detallefacturaEliminada == null}");

                // Ejemplo de operaciones con producto
                var producto = new Producto
                {
                    Id = 1,
                    Nombre = " Samsung Buds",
                    Descripcion = " Auriculares Inalambricos",
                    Precio = 100.0m,
                    Stock = 50
                };
                productoService.InsertarProducto(producto);
                var productoLeido = productoService.ObtenerProductoPorId(producto.Id);
                Console.WriteLine($"Producto leído: {productoLeido?.Nombre}");

                producto.Nombre = "Producto 1 Actualizado";
                productoService.ActualizarProducto(producto);
                var productoActualizado = productoService.ObtenerProductoPorId(producto.Id);
                Console.WriteLine($"Producto actualizado: {productoActualizado?.Nombre}");

                productoService.EliminarProducto(producto.Id);
                var productoEliminado = productoService.ObtenerProductoPorId(producto.Id);
                Console.WriteLine($"Producto eliminado: {productoEliminado == null}");
            }
        }
    }
}*/
/*using System;
using System.Collections.Generic;
using Dapper;
using Npgsql;
using Opta3.Modelo;
using Opta3.Repositorio;
using Repositorio;
using Opta3.Modelos;
using Opta3;
using Servicios;
using System.Data;

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
            var detallefacturaRepository = new DetallefacturaRepository(connection);
            var productoRepository = new ProductoRepository(connection);

            var clienteService = new ClienteService(clienteRepository);
            var facturaService = new FacturaService(facturaRepository);
            var sucursalService = new SucursalService(sucursalRepository);
            var detallefacturaService = new DetallefacturaService(detallefacturaRepository);
            var productoService = new ProductoService(productoRepository);

            // Ejemplo de operaciones con cliente
            var cliente = new Cliente
            {
                Id = 38,
                Idbanco = 6,
                Nombre = "Jamin",
                Apellido = "perez",
                Documento = "5050321",
                Direccion = "Av Gral silva",
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
                Id = 9,
                Descripcion = "Sucursal HospiCenter",
                Direccion = "Avenida america",
                Telefono = "0987111333",
                Whatsapp = "0987222900",
                Mail = "centerhospi@gmail.com",
                Estado = "Activa"
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
                    Idfactura = 8,
                    Idcliente = clienteLeido.Id,
                    Nrofactura = "001-001-180078",
                    Fechahora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Total = 100.0m,
                    Total5 = 5.0m,
                    Total10 = 10.0m,
                    Totaliva = 15.0m,
                    Totalletras = "Cien mil guaranies ",
                    Sucursal = "Sucursal hospiCenter",
                    Idsucursal = sucursalLeida.Id
                };
                facturaService.InsertarFactura(factura);
                var facturaLeida = facturaService.ObtenerFacturaPorId(factura.Idfactura);
                Console.WriteLine($"Factura leída: {facturaLeida?.Nrofactura}");

                // Ejemplo de operaciones con detallefactura
                var detallefactura = new Detallefactura
                {
                    Id = 1,
                    Idfactura = facturaLeida.Idfactura,
                    Idproducto = 1,
                    Cantproducto = "5",
                    Subtotal = 50
                };
                detallefacturaService.InsertarDetallefactura(detallefactura);
                var detallefacturaLeida = detallefacturaService.ObtenerDetallefacturaPorId(detallefactura.Idfactura);
                Console.WriteLine($"Detalle factura leído: {detallefacturaLeida?.Cantproducto}");

                // Actualizar y eliminar ejemplo de operaciones con detallefactura
                detallefactura.Cantproducto = "10";
                detallefacturaService.ActualizarDetallefactura(detallefactura);
                var detallefacturaActualizada = detallefacturaService.ObtenerDetallefacturaPorId(detallefactura.Idfactura);
                Console.WriteLine($"Detalle factura actualizado: {detallefacturaActualizada?.Cantproducto}");

                detallefacturaService.EliminarDetallefactura(detallefactura.Idfactura);
                var detallefacturaEliminada = detallefacturaService.ObtenerDetallefacturaPorId(detallefactura.Idfactura);
                Console.WriteLine($"Detalle factura eliminada: {detallefacturaEliminada == null}");

                // Ejemplo de operaciones con producto
                var producto = new Producto
                {
                    Id = 1,
                    Nombre = " Samsung Buds",
                    Descripcion = " Auriculares Inalambricos",
                    Precio = 100.0m,
                    Stock = 50
                };
                productoService.InsertarProducto(producto);
                var productoLeido = productoService.ObtenerProductoPorId(producto.Id);
                Console.WriteLine($"Producto leído: {productoLeido?.Nombre}");

                producto.Nombre = "Producto 1 Actualizado";
                productoService.ActualizarProducto(producto);
                var productoActualizado = productoService.ObtenerProductoPorId(producto.Id);
                Console.WriteLine($"Producto actualizado: {productoActualizado?.Nombre}");

                productoService.EliminarProducto(producto.Id);
                var productoEliminado = productoService.ObtenerProductoPorId(producto.Id);
                Console.WriteLine($"Producto eliminado: {productoEliminado == null}");
            }

            // Listar todos los datos de las tablas
            ListarDatos(connection, "Cliente");
            ListarDatos(connection, "Sucursal");
            ListarDatos(connection, "Factura");
            ListarDatos(connection, "Productos");
            ListarDatos(connection, "Detalle_factura");
        }
    }

    static void ListarDatos(IDbConnection connection, string tableName)
    {
        string sql = $"SELECT * FROM {tableName}";
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
}*/
using System;
using System.Collections.Generic;
using Dapper;
using Npgsql;
using Opta3.Modelo;
using Opta3.Repositorio;
using Repositorio;
using Opta3.Modelos;
using Opta3;
using Servicios;
using System.Data;

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
            var detallefacturaRepository = new DetallefacturaRepository(connection);
            var productoRepository = new ProductoRepository(connection);

            var clienteService = new ClienteService(clienteRepository);
            var facturaService = new FacturaService(facturaRepository);
            var sucursalService = new SucursalService(sucursalRepository);
            var detallefacturaService = new DetallefacturaService(detallefacturaRepository);
            var productoService = new ProductoService(productoRepository);

            // Ejemplo de operaciones con cliente
            var cliente = new Cliente
            {
                Id = 4,
                Idbanco = 2,
                Nombre = "Sofia",
                Apellido = "gimenez",
                Documento = "5050321",
                Direccion = "Av Molas Perez",
                Mail = "sofiamenez01@hotmail.com",
                Celular = "0982111789",
                Estado = "Activo"
            };
            clienteService.InsertarCliente(cliente);
            var clienteLeido = clienteService.ObtenerClientePorId(cliente.Id);
            Console.WriteLine($"Cliente leído: {clienteLeido?.Nombre} {clienteLeido?.Apellido}");

            // Ejemplo de operaciones con sucursal
            var sucursal = new Sucursal
            {
                Id = 13,
                Descripcion = "Sucursal HospiCenter 3",
                Direccion = "Av uruguay",
                Telefono = "0987111333",
                Whatsapp = "0987222900",
                Mail = "centerhospi3@gmail.com",
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
                    Idfactura = 12,
                    Idcliente = clienteLeido.Id,
                    Nrofactura = "001-001-205578",
                    Fechahora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Total = 100.0m,
                    Total5 = 5.0m,
                    Total10 = 10.0m,
                    Totaliva = 15.0m,
                    Totalletras = "Cien mil guaranies ",
                    Sucursal = "Sucursal hospiCenter 3",
                    Idsucursal = sucursalLeida.Id
                };
                facturaService.InsertarFactura(factura);
                var facturaLeida = facturaService.ObtenerFacturaPorId(factura.Idfactura);
                Console.WriteLine($"Factura leída: {facturaLeida?.Nrofactura}");

                var producto = new Producto
                {
                    Id = 1,
                    Nombre = "Samsung Buds",
                    Descripcion = "Auriculares Inalámbricos",
                    CantMinima = 10,
                    PrecioCompra = 80.0m,
                    PrecioVenta = 120.0m,
                    Categoria = "Electrónica",
                    Marca = "Samsung",
                    Estado = "Disponible",
                    Precio = 100.0m,
                    Stock = 50
                };
                productoService.InsertarProducto(producto);
                var productoLeido = productoService.ObtenerProductoPorId(producto.Id);
                Console.WriteLine($"Producto leído: {productoLeido?.Nombre}");

                // Ejemplo de operaciones con detallefactura
                var detallefactura = new Detallefactura
                {
                    Id = 2,
                    Idfactura = facturaLeida.Idfactura,
                    Idproducto = 1,
                    Cantproducto = "5",
                    Subtotal = 50
                };
                detallefacturaService.InsertarDetallefactura(detallefactura);
                var detallefacturaLeida = detallefacturaService.ObtenerDetallefacturaPorId(detallefactura.Id);
                Console.WriteLine($"Detalle factura leído: {detallefacturaLeida?.Cantproducto}");

                // Ejemplo de operaciones con producto
                
                /*/ Actualizar producto
                producto.Precio = 110.0m;
                productoService.ActualizarProducto(producto);
                Console.WriteLine("Producto actualizado correctamente.");

                // Eliminar producto
                productoService.EliminarProducto(producto.Id);
                Console.WriteLine("Producto eliminado correctamente.");*/
            }

            // Listar todos los datos de las tablas
            ListarDatos(connection, "Cliente");
            ListarDatos(connection, "Sucursal");
            ListarDatos(connection, "Factura");
            ListarDatos(connection, "Productos");
            ListarDatos(connection, "Detalle_factura");
        }
    }

    static void ListarDatos(IDbConnection connection, string tableName)
    {
        string sql = $"SELECT * FROM {tableName}";
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



