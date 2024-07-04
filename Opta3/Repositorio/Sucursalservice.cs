/*using Opta3.Modelos;
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
}*/
using System;
using Opta3.Modelos;
using Opta3.Repositorio;

namespace Opta3.Servicio
{
    public class SucursalServicio
    {
        private readonly SucursalRepositorio _repositorio;

        public SucursalServicio(SucursalRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public void Insertar(Sucursal sucursal)
        {
            ValidarSucursal(sucursal);
            _repositorio.Insertar(sucursal);
        }

        public Sucursal ObtenerPorId(int id)
        {
            return _repositorio.ObtenerPorId(id);
        }

        public IEnumerable<Sucursal> ObtenerTodos()
        {
            return _repositorio.ObtenerTodos();
        }

        public void Actualizar(Sucursal sucursal)
        {
            ValidarSucursal(sucursal);
            _repositorio.Actualizar(sucursal);
        }

        public void Eliminar(int id)
        {
            _repositorio.Eliminar(id);
        }

        private void ValidarSucursal(Sucursal sucursal)
        {
            if (string.IsNullOrEmpty(sucursal.Descripcion) || sucursal.Descripcion.Length < 3)
                throw new ArgumentException("Descripcion es obligatorio y debe tener al menos 3 caracteres.");
            if (string.IsNullOrEmpty(sucursal.Direccion) || sucursal.Direccion.Length < 3)
                throw new ArgumentException("Direccion es obligatorio y debe tener al menos 3 caracteres.");
            if (string.IsNullOrEmpty(sucursal.Telefono) || sucursal.Telefono.Length != 10 || !int.TryParse(sucursal.Telefono, out _))
                throw new ArgumentException("Telefono es obligatorio y debe tener 10 caracteres numéricos.");
            if (string.IsNullOrEmpty(sucursal.Estado) || sucursal.Estado.Length < 3)
                throw new ArgumentException("Estado es obligatorio y debe tener al menos 3 caracteres.");
        }
    }
}

