using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opta3.Modelo
{
    public class Proveedor
    {
        public int Id { get; set; }
        public string Razonsocial { get; set; } = string.Empty;
        public string Tipodocumento { get; set; } = string.Empty;
        public string Documento { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Mail { get; set; } = string.Empty;
        public string Celular { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;

        public Proveedor() { }

        public Proveedor(string razonsocial, string tipodocumento, string documento, string direccion, string mail, string celular, string estado)
        {
            Razonsocial = razonsocial;
            Tipodocumento = tipodocumento;
            Documento = documento;
            Direccion = direccion;
            Mail = mail;
            Celular = celular;
            Estado = estado;
        }
    }
}
