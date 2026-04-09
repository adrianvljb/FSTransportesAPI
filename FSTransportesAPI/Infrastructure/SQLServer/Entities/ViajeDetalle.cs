using System;

namespace FSTransportesAPI.Infrastructure.SQLServer.Entities
{
    public class ViajeDetalle
    {
        
        public int IdViajeDetalle { get; set; }

        public int IdViaje { get; set; }

        public int IdColaborador { get; set; }

        public decimal DistanciaKilometros { get; set; }

        public decimal TarifaSugerida { get; set; }

        public int UsuarioAgrega { get; set; }
        public DateTime FechaAgrega { get; set; }

        
        public int? UsuarioModifica { get; set; }
        public DateTime? FechaModifica { get; set; }

        
        public virtual Viaje? Viaje { get; set; }
        public virtual Colaborador? Colaborador { get; set; }
    }
}