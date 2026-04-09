namespace FSTransportesAPI.Infrastructure.SQLServer.Entities
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;
        public int IdRol { get; set; }
        public bool Activo { get; set; } = true;

        public int UsuarioAgrega { get; set; }
        public DateTime FechaAgrega { get; set; }
        public int? UsuarioModifica { get; set; }
        public DateTime? FechaModifica { get; set; }
    }
}

