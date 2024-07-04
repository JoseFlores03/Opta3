using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opta3.Modelo
{
    public class Detallepedido
    {
        public int Id { get; set; }
        public int Idpedido { get; set; }
        public int Idproducto { get; set; }
        public int Cantproducto { get; set; }
        public int Subtotal { get; set; }

        public Detallepedido() { }

        public Detallepedido(int idpedido, int idproducto, int cantproducto, int subtotal)
        {
            Idpedido = idpedido;
            Idproducto = idproducto;
            Cantproducto = cantproducto;
            Subtotal = subtotal;
        }
    }
}
