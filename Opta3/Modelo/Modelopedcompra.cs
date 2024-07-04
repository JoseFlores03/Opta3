using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Opta3.Modelo
{
    public class Pedidocompra
    {
        public int Id { get; set; }
        public int Idproveedor { get; set; }
        public int Idsucursal { get; set; }
        public string Fechahora { get; set; } = string.Empty;
        public int Total { get; set; }

        public Pedidocompra() { }

        public Pedidocompra(int idproveedor, int idsucursal, string fechahora, int total)
        {
            Idproveedor = idproveedor;
            Idsucursal = idsucursal;
            Fechahora = fechahora;
            Total = total;
        }
    }
}
