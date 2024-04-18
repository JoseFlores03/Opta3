using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opta3.Repositorio
{
    public class Factura
    {
        public int Id { get; set; }
        public int Idcliente { get; set; }
        public string Nrofactura{ get; set; }
        public DateTime Fechahora { get; set; }
        public Decimal Total { get; set; }
        public Decimal Total5 { get; set; }
        public Decimal Total10 { get; set; }
        public Decimal Totaliva { get; set; }
        public string Totalletras { get; set; }
        public string Sucursal { get; set; }

        public Factura(string Nrofactura,DateTime Fechahora, decimal Total, decimal Total5, decimal Total10, decimal Totaliva, string Totalletras, string Sucursal)
        {
            Nrofactura = Nrofactura;
            Fechahora = Fechahora;
            Total = Total;
            Total5 = Total5;
            Total10 = Total10;
            Totaliva = Totaliva;
            Totalletras = Totalletras;
            Sucursal = Sucursal;
        }
    }
}
