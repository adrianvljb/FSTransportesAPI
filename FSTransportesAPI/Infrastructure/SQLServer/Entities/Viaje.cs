namespace FSTransportesAPI.Infrastructure.SQLServer.Entities
{
    public class Viaje
    {
        public int IdViaje { get; set; }
        public DateTime FechaViaje { get; set; }
        public int IdSucursal { get; set; }
        public int IdTransportista { get; set; }
        public int IdUsuarioRegistro { get; set; }

        
        public int UsuarioAgrega { get; set; }
        public DateTime FechaAgrega { get; set; }
        public int? UsuarioModifica { get; set; }
        public DateTime? FechaModifica { get; set; }

       
        public virtual Sucursal Sucursal { get; set; } = null!;
        public virtual Usuario UsuarioRegistro { get; set; } = null!;
        public virtual Transportista Transportista { get; set; } = null!;
        public virtual ICollection<ViajeDetalle> Detalles { get; set; } = new List<ViajeDetalle>();
    }
}