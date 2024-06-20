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
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int CantMinima { get; set; }  
        public decimal PrecioCompra { get; set; }  
        public decimal PrecioVenta { get; set; }  
        public string Categoria { get; set; }  
        public string Marca { get; set; }  
        public string Estado { get; set; }  

        public Producto() { }

        public Producto(string nombre, string descripcion, decimal precio, int stock,
                        int cantMinima, decimal precioCompra, decimal precioVenta,
                        string categoria, string marca, string estado)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            Stock = stock;
            CantMinima = cantMinima;
            PrecioCompra = precioCompra;
            PrecioVenta = precioVenta;
            Categoria = categoria;
            Marca = marca;
            Estado = estado;
        }
    }
}


