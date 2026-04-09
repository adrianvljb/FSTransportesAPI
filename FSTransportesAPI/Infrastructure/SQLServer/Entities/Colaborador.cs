using System;

namespace FSTransportesAPI.Infrastructure.SQLServer.Entities
{
    public class Colaborador
    {
        public int IdColaborador { get; set; }

        // CORRECCIÓN: Asegúrate de que el nombre sea "Nombre" (singular) 
        // para que coincida con el ColaboradorMap.cs
        public string Nombre { get; set; } = string.Empty;

        public bool Activo { get; set; }

        // Propiedades de auditoría que requiere el Map
        public int UsuarioAgrega { get; set; }
        public DateTime FechaAgrega { get; set; }
        public int? UsuarioModifica { get; set; }
        public DateTime? FechaModifica { get; set; }
    }
}