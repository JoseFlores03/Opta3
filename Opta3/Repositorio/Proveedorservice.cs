/*using Opta3.Modelo;
using Opta3.Repositorio;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class ProveedorService
{
    private readonly ProveedorRepository _proveedorRepository;

    public ProveedorService(ProveedorRepository proveedorRepository)
    {
        _proveedorRepository = proveedorRepository;
    }

    public void InsertarProveedor(Proveedor proveedor)
    {
        if (!ValidarProveedor(proveedor)) return;
        _proveedorRepository.InsertarProveedor(proveedor);
    }

    public Proveedor ObtenerProveedorPorId(int id)
    {
        return _proveedorRepository.ObtenerProveedorPorId(id);
    }

    public IEnumerable<Proveedor> ObtenerTodosLosProveedores()
    {
        return _proveedorRepository.ObtenerTodosLosProveedores();
    }

    public void ActualizarProveedor(Proveedor proveedor)
    {
        if (!ValidarProveedor(proveedor)) return;
        _proveedorRepository.ActualizarProveedor(proveedor);
    }

    public void EliminarProveedor(int id)
    {
        _proveedorRepository.EliminarProveedor(id);
    }

    private bool ValidarProveedor(Proveedor proveedor)
    {
        if (string.IsNullOrEmpty(proveedor.Razonsocial) || proveedor.Razonsocial.Length < 3 ||
            string.IsNullOrEmpty(proveedor.Tipodocumento) || proveedor.Tipodocumento.Length < 3 ||
            string.IsNullOrEmpty(proveedor.Documento) || proveedor.Documento.Length < 3)
        {
            Console.WriteLine("Razón social, Tipo de Documento y Número de Documento son obligatorios y deben tener al menos 3 caracteres.");
            return false;
        }

        if (!Regex.IsMatch(proveedor.Celular, @"^\d{10}$"))
        {
            Console.WriteLine("Celular debe ser numérico y tener 10 dígitos.");
            return false;
        }

        return true;
    }
}*/
using System;
using Opta3.Modelo;
using Opta3.Repositorio;

namespace Opta3.Servicio
{
    public class ProveedorServicio
    {
        private readonly ProveedorRepositorio _repositorio;

        public ProveedorServicio(ProveedorRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public void Insertar(Proveedor proveedor)
        {
            ValidarProveedor(proveedor);
            _repositorio.Insertar(proveedor);
        }

        public Proveedor ObtenerPorId(int id)
        {
            return _repositorio.ObtenerPorId(id);
        }

        public IEnumerable<Proveedor> ObtenerTodos()
        {
            return _repositorio.ObtenerTodos();
        }

        public void Actualizar(Proveedor proveedor)
        {
            ValidarProveedor(proveedor);
            _repositorio.Actualizar(proveedor);
        }

        public void Eliminar(int id)
        {
            _repositorio.Eliminar(id);
        }

        private void ValidarProveedor(Proveedor proveedor)
        {
            if (string.IsNullOrEmpty(proveedor.Razonsocial) || proveedor.Razonsocial.Length < 3)
                throw new ArgumentException("Razonsocial es obligatorio y debe tener al menos 3 caracteres.");
            if (string.IsNullOrEmpty(proveedor.Tipodocumento) || proveedor.Tipodocumento.Length < 3)
                throw new ArgumentException("Tipodocumento es obligatorio y debe tener al menos 3 caracteres.");
            if (string.IsNullOrEmpty(proveedor.Documento) || proveedor.Documento.Length < 3)
                throw new ArgumentException("Documento es obligatorio y debe tener al menos 3 caracteres.");
            if (string.IsNullOrEmpty(proveedor.Celular) || proveedor.Celular.Length != 10 || !int.TryParse(proveedor.Celular, out _))
                throw new ArgumentException("Celular es obligatorio y debe tener 10 caracteres numéricos.");
        }
    }
}
