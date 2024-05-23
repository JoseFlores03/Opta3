/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Examenp1.Reposiroty
{
    public class Facturaservice
    {
        public int Idfactura { get; set; }
        public int Idcliente { get; set; }
        public string Nrofactura { get; set; }
        public DateTime Fechahora { get; set; }
        public decimal Total { get; set; }
        public decimal Total5 { get; set; }
        public decimal Total10 { get; set; }
        public decimal Totaliva { get; set; }
        public string Totalletras { get; set; }
        public string Sucursal { get; set; }

        public bool ValidarFactura()
        {
            Regex regexNumeroFactura = new Regex(@"^\d{3}-\d{3}-\d{6}$");
            if (!regexNumeroFactura.IsMatch(Nrofactura))
            {
                Console.WriteLine("El numero de factura no cumple con el formato.");
                return false;
            }

            if (Total <= 0 || Total5 < 0 || Total10 < 0)
            {
                Console.WriteLine(" Los totales deben ser solamente numeros positivos.");
                return false;
            }
            if (string.IsNullOrEmpty(Totalletras) || Totalletras.Length < 6)
            {
                Console.WriteLine(" El total en letras debe tener por lo menos 6 caracteres");
                return false;
            }

            return true;
        }

    }
}*/
/*using Opta3.Modelo;

public class FacturaService
{
    private readonly FacturaRepository _facturaRepository;

    public FacturaService(FacturaRepository facturaRepository)
    {
        _facturaRepository = facturaRepository;
    }

    public void InsertarFactura(Factura factura)
    {
        if (!ValidarFechaHora(factura.Fechahora))
        {
            Console.WriteLine("Fecha y hora inválidas");
            return;
        }

        _facturaRepository.InsertarFactura(factura);
    }

    public Factura ObtenerFacturaPorId(int id)
    {
        return _facturaRepository.ObtenerFacturaPorId(id);
    }

    public List<Factura> ObtenerTodasLasFacturas()
    {
        return _facturaRepository.ObtenerTodasLasFacturas();
    }

    public void ActualizarFactura(Factura factura)
    {
        _facturaRepository.ActualizarFactura(factura);
    }

    public void EliminarFactura(int id)
    {
        _facturaRepository.EliminarFactura(id);
    }

    private bool ValidarFechaHora(string fechahora)
    {
        return DateTime.TryParse(fechahora, out _);
    }
}*/
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

