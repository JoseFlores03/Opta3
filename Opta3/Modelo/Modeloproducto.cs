using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opta3.Modelo
{
    public class Producto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public string Cantminima { get; set; } = string.Empty;
        public int Preciocompra { get; set; }
        public string Precioventa { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string Cantstock { get; set; } = string.Empty;

        public Producto() { }

        public Producto(string descripcion, string cantminima, int preciocompra, string precioventa, string categoria, string marca, string estado, string cantstock)
        {
            Descripcion = descripcion;
            Cantminima = cantminima;
            Preciocompra = preciocompra;
            Precioventa = precioventa;
            Categoria = categoria;
            Marca = marca;
            Estado = estado;
            Cantstock = cantstock;
        }
    }
}


