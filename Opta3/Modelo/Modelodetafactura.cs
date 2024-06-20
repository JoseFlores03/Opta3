using System;

namespace Opta3.Modelo
{
    public class Detallefactura
    {
        public int Id { get; set; }
        public int Idfactura { get; set; }
        public int Idproducto { get; set; }
        public string Cantproducto { get; set; } = string.Empty;
        public int Subtotal { get; set; }

        public Detallefactura() { }

        public Detallefactura(int idfactura, int idproducto, string cantproducto, int subtotal)
        {
            Idfactura = idfactura;
            Idproducto = idproducto;
            Cantproducto = cantproducto;
            Subtotal = subtotal;
        }
    }
}
