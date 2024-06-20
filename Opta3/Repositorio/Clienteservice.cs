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

