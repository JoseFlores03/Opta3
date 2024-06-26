﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opta3.Modelo
{
    public class Cliente
    {
        public int Id { get; set; }
        public int Idbanco { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Documento { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Mail { get; set; } = string.Empty;
        public string Celular { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;

        public Cliente() { }

        public Cliente(string nombre, string apellido, string documento, string direccion, string mail, string celular, string estado)
        {
            Nombre = nombre;
            Apellido = apellido;
            Documento = documento;
            Direccion = direccion;
            Mail = mail;
            Celular = celular;
            Estado = estado;
        }
    }
}
