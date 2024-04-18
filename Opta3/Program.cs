using System;
using Opta3.Repositorio;

    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Host=localhost;port=5432;Database=optativo3;Username=postgres;Password=0000;";

            // Crear instancias de los servicios de cliente y factura
            Clienterepositorio Clienterepositorio = new Clienterepositorio(connectionString);
            Facturarepositorio Facturarepositorio = new Facturarepositorio(connectionString);

            // Ejemplo de uso
            Cliente nuevoCliente = new Cliente("Juan", "Perez", "1234567890", "Dirección", "correo@ejemplo.com", "1234567890", "activo");
            Clienterepositorio.Add(nuevoCliente);

            // Obtener todas las facturas y mostrarlas en la consola
            Console.WriteLine("Lista de facturas:");
            foreach (var factura in Facturarepositorio.ObtenerFactura())
            {
                Console.WriteLine($"ID: {factura.id}, Número: {factura.nro_factura}, Total: {factura.total}");
            }
            // servicioCliente.AgregarCliente(new ClienteModelo(...));
            // servicioFactura.AgregarFactura(new FacturaModelo(...));



            Console.WriteLine("Operaciones completada");
        }
    }