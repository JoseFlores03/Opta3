    public class Cliente
    {
        public int Id { get; set; }
        public int Idbanco { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }
        public string Direccion { get; set; }
        public string Mail { get; set; }
        public string Celular { get; set; }
        public string Estado { get; set; }

        public Cliente(string Nombre, string Apellido, string Documento, string Direccion, string Mail,
          string Celular, string Estado)
        {
            Nombre = Nombre;
            Apellido = Apellido;
            Documento = Documento;
            Direccion = Direccion;
            Mail = Mail;
            Celular = Celular;
            Estado = Estado;
        }
    }
}
