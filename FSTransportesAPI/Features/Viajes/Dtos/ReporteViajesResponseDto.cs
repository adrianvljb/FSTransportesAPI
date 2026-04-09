using System;
using System.Collections.Generic;

namespace FSTransportesAPI.Features.Viajes.Dtos
{
    public class ReporteViajesResponseDto
    {
        public int TotalViajesRealizados { get; set; }
        public decimal TotalKilometrosRecorridos { get; set; }
        public decimal TotalTarifasPagadas { get; set; }
        public List<ViajeResumenDto> DetalleViajes { get; set; } = new List<ViajeResumenDto>();
    }

    public class ViajeResumenDto
    {
        public int IdViaje { get; set; }
        public DateTime FechaViaje { get; set; }
        public string NombreSucursal { get; set; } = string.Empty;
        public string NombreTransportista { get; set; } = string.Empty;
        public decimal DistanciaTotal { get; set; }
        public decimal TarifaTotal { get; set; }
        public int CantidadColaboradores { get; set; }
    }
}