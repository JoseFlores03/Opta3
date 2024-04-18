using Opta3.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opta3.Repositorio
{
    public class Clienteservice
    {
        public Clienterepositorio RepositorioCliente;

        public Clienteservice(string connection)
        {
            Clienterepositorio = new Clienterepositorio(connection);
        }

        public void insertar(Cliente cliente)
        {
            if (validacionDatos(cliente))
                Clienterepositorio.Add(cliente);
            else
                throw new Exception("Error en la validacion de dato, favor corroborar");
        }

        private bool validacionDatos(Cliente cliente)
        {
            if (cliente == null)
                return false;
            if (string.IsNullOrEmpty(cliente.Nombre))
                return false;
            if (string.IsNullOrEmpty(cliente.Apellido))
                return false;
            if (string.IsNullOrEmpty(cliente.Documento))
                return false;
            if (string.IsNullOrEmpty(cliente.Direccion))
                return false;
            if (string.IsNullOrEmpty(cliente.Mail))
                return false;
            if (string.IsNullOrEmpty(cliente.Celular))
                return false;
            if (string.IsNullOrEmpty(cliente.Estado))
                return false;

            return true;
        }
    }
}