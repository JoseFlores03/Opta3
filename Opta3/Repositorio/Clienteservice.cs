/*using Opta3.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opta3.Repositorio
{
    /*public class Clienteservice
    {
        public Clienterepositorio RepositorioCliente;

        public Clienteservice(string connection)
        {
            Clienterepositorio clienterepositorio = new Clienterepositorio(connection);
        }

        public void insertar(Cliente cliente)
        {
            if (validacionDatos(cliente))
                RepositorioCliente.Add(cliente);
            else
                throw new Exception("Error en la validacion de dato, favor corroborar");
        }

        private bool validacionDatos(Cliente cliente)
        {
            if (cliente == null)
                return false;
            if (string.IsNullOrEmpty(cliente.Nombre))
                return false;
            if (string.IsNullOrEmpty(cliente.Apellido))
                return false;
            if (string.IsNullOrEmpty(cliente.Documento))
                return false;
            if (string.IsNullOrEmpty(cliente.Direccion))
                return false;
            if (string.IsNullOrEmpty(cliente.Mail))
                return false;
            if (string.IsNullOrEmpty(cliente.Celular))
                return false;
            if (string.IsNullOrEmpty(cliente.Estado))
                return false;

            return true;
        }
    }*/

/*using Opta3.Modelo;

public class ClienteService
{
    private readonly ClienteRepository _clienteRepository;

    public ClienteService(ClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public void InsertarCliente(Cliente cliente)
    {
        if (!ValidarCorreo(cliente.Mail))
        {
            Console.WriteLine("Correo electrónico inválido");
            return;
        }

        if (!ValidarDocumento(cliente.Documento))
        {
            Console.WriteLine("Documento inválido");
            return;
        }

        _clienteRepository.InsertarCliente(cliente);
    }

    public Cliente ObtenerClientePorId(int id)
    {
        return _clienteRepository.ObtenerClientePorId(id);
    }

    public List<Cliente> ObtenerTodosLosClientes()
    {
        return _clienteRepository.ObtenerTodosLosClientes();
    }

    public void ActualizarCliente(Cliente cliente)
    {
        _clienteRepository.ActualizarCliente(cliente);
    }

    public void EliminarCliente(int id)
    {
        _clienteRepository.EliminarCliente(id);
    }

    private bool ValidarCorreo(string correo)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(correo);
            return addr.Address == correo;
        }
        catch
        {
            return false;
        }
    }

    private bool ValidarDocumento(string documento)
    {
        return !string.IsNullOrWhiteSpace(documento) && documento.Length > 5;
    }
}*/
using Opta3.Modelo;
using Opta3.Repositorio;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class ClienteService
{
    private readonly ClienteRepository _clienteRepository;

    public ClienteService(ClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public void InsertarCliente(Cliente cliente)
    {
        if (!ValidarCliente(cliente)) return;
        _clienteRepository.InsertarCliente(cliente);
    }

    public Cliente ObtenerClientePorId(int id)
    {
        return _clienteRepository.ObtenerClientePorId(id);
    }

    public IEnumerable<Cliente> ObtenerTodosLosClientes()
    {
        return _clienteRepository.ObtenerTodosLosClientes();
    }

    public void ActualizarCliente(Cliente cliente)
    {
        if (!ValidarCliente(cliente)) return;
        _clienteRepository.ActualizarCliente(cliente);
    }

    public void EliminarCliente(int id)
    {
        _clienteRepository.EliminarCliente(id);
    }

    private bool ValidarCliente(Cliente cliente)
    {
        if (string.IsNullOrEmpty(cliente.Nombre) || cliente.Nombre.Length < 3 ||
            string.IsNullOrEmpty(cliente.Apellido) || cliente.Apellido.Length < 3 ||
            string.IsNullOrEmpty(cliente.Documento) || cliente.Documento.Length < 3)
        {
            Console.WriteLine("Nombre, Apellido y Cedula son obligatorios y deben tener al menos 3 caracteres.");
            return false;
        }

        if (!Regex.IsMatch(cliente.Celular, @"^\d{10}$"))
        {
            Console.WriteLine("Celular debe ser numérico y tener 10 dígitos.");
            return false;
        }

        return true;
    }
}

