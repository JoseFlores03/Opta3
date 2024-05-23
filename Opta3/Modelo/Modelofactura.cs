using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opta3.Modelo
{
    /*public class Factura
    {
        public int Idfactura { get; set; }
        public int Idcliente { get; set; }
        public string Nrofactura { get; set; }
        public string Fechahora { get; set; }
        public decimal Total { get; set; }
        public decimal Total5 { get; set; }
        public decimal Total10 { get; set; }
        public decimal Totaliva { get; set; }
        public string Totalletras { get; set; }
        public string Sucursal { get; set; }

        public Factura() { }

        public Factura(int idfactura, int idcliente, string nrofactura, string fechahora, decimal total, decimal total5, decimal total10, decimal totaliva, string totalletras, string sucursal)
        {
            Idfactura = idfactura;
            Idcliente = idcliente;
            Nrofactura = nrofactura;
            Fechahora = fechahora;
            Total = total;
            Total5 = total5;
            Total10 = total10;
            Totaliva = totaliva;
            Totalletras = totalletras;
            Sucursal = sucursal;
        }
    }*/
    public class Factura
    {
        public int Idfactura { get; set; }
        public int Idcliente { get; set; }
        public string Nrofactura { get; set; } = string.Empty;
        public string Fechahora { get; set; } = string.Empty;
        public decimal Total { get; set; }
        public decimal Total5 { get; set; }
        public decimal Total10 { get; set; }
        public decimal Totaliva { get; set; }
        public string Totalletras { get; set; } = string.Empty;
        public string Sucursal { get; set; } = string.Empty;
        public int Idsucursal { get; set; }

        public Factura() { }

        public Factura(int idcliente, string nrofactura, string fechahora, decimal total, decimal total5, decimal total10, decimal totaliva, string totalletras, string sucursal, int idsucursal)
        {
            Idcliente = idcliente;
            Nrofactura = nrofactura;
            Fechahora = fechahora;
            Total = total;
            Total5 = total5;
            Total10 = total10;
            Totaliva = totaliva;
            Totalletras = totalletras;
            Sucursal = sucursal;
            Idsucursal = idsucursal;
        }
    }
}
