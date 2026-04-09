namespace FSTransportesAPI.Infrastructure.SQLServer.Entities
{
    public class Transportista
    {
        public int IdTransportista { get; set; }

        public string Nombre { get; set; } = string.Empty;

     
        public decimal TarifaPorKilometro { get; set; }

        public bool Activo { get; set; } = true;

       
        public int UsuarioAgrega { get; set; }
        public DateTime FechaAgrega { get; set; }
        public int? UsuarioModifica { get; set; }
        public DateTime? FechaModifica { get; set; }

        
        public virtual ICollection<Viaje> Viajes { get; set; } = new List<Viaje>();
    }
}