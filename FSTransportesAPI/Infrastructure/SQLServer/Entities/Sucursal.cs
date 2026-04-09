namespace FSTransportesAPI.Infrastructure.SQLServer.Entities
{
    public class Sucursal
    {
        public int IdSucursal { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Ubicacion { get; set; } = string.Empty; 

        public bool Activo { get; set; } = true;

        public int UsuarioAgrega { get; set; }

        public DateTime FechaAgrega { get; set; }

        public int? UsuarioModifica { get; set; }

        public DateTime? FechaModifica { get; set; }
    }
}