using Opta3.Modelos;
using Opta3.Modelo;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class SucursalService
{
    private readonly SucursalRepository _sucursalRepository;

    public SucursalService(SucursalRepository sucursalRepository)
    {
        _sucursalRepository = sucursalRepository;
    }

    public void InsertarSucursal(Sucursal sucursal)
    {
        if (!ValidarSucursal(sucursal)) return;
        _sucursalRepository.InsertarSucursal(sucursal);
    }

    public Sucursal ObtenerSucursalPorId(int id)
    {
        return _sucursalRepository.ObtenerSucursalPorId(id);
    }

    public IEnumerable<Sucursal> ObtenerTodasLasSucursales()
    {
        return _sucursalRepository.ObtenerTodasLasSucursales();
    }

    public void ActualizarSucursal(Sucursal sucursal)
    {
        if (!ValidarSucursal(sucursal)) return;
        _sucursalRepository.ActualizarSucursal(sucursal);
    }

    public void EliminarSucursal(int id)
    {
        _sucursalRepository.EliminarSucursal(id);
    }

    private bool ValidarSucursal(Sucursal sucursal)
    {
        if (string.IsNullOrEmpty(sucursal.Direccion) || sucursal.Direccion.Length < 10)
        {
            Console.WriteLine("La dirección debe tener al menos 10 caracteres.");
            return false;
        }

        if (!Regex.IsMatch(sucursal.Mail, @"^[^@]+@[^@]+\.[^@]+$"))
        {
            Console.WriteLine("El correo electrónico no es válido.");
            return false;
        }

        return true;
    }
}

