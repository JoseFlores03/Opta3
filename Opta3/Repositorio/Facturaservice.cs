using Opta3.Modelo;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Servicios
{
    public class FacturaService
    {
        private readonly FacturaRepository _facturaRepository;

        public FacturaService(FacturaRepository facturaRepository)
        {
            _facturaRepository = facturaRepository;
        }

        public void InsertarFactura(Factura factura)
        {
            ValidarFactura(factura);
            _facturaRepository.InsertarFactura(factura);
        }

        public Factura ObtenerFacturaPorId(int id)
        {
            return _facturaRepository.ObtenerFacturaPorId(id);
        }

        public IEnumerable<Factura> ObtenerTodasLasFacturas()
        {
            return _facturaRepository.ObtenerTodasLasFacturas();
        }

        public void ActualizarFactura(Factura factura)
        {
            ValidarFactura(factura);
            _facturaRepository.ActualizarFactura(factura);
        }

        public void EliminarFactura(int id)
        {
            _facturaRepository.EliminarFactura(id);
        }

        private void ValidarFactura(Factura factura)
        {
            if (!Regex.IsMatch(factura.Nrofactura, @"^\d{3}-\d{3}-\d{6}$"))
            {
                throw new ArgumentException("El número de factura no cumple con el formato requerido.");
            }

            if (factura.Total <= 0 || factura.Total5 < 0 || factura.Total10 < 0 || factura.Totaliva < 0)
            {
                throw new ArgumentException("Los valores numéricos de la factura no son válidos.");
            }

            if (string.IsNullOrEmpty(factura.Totalletras) || factura.Totalletras.Length < 6)
            {
                throw new ArgumentException("El total en letras debe ser obligatorio y tener al menos 6 caracteres.");
            }
        }
    }
}

