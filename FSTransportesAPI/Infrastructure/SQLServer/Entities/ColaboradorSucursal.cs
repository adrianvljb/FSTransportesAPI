namespace FSTransportesAPI.Infrastructure.SQLServer.Entities
{
    public class ColaboradorSucursal
    {
        public int IdColaboradorSucursal { get; set; }

        public int IdColaborador { get; set; }

        public int IdSucursal { get; set; }

        public decimal DistanciaKilometros { get; set; }

        public int UsuarioAgrega { get; set; }

        public DateTime FechaAgrega { get; set; }

        public int? UsuarioModifica { get; set; }

        public DateTime? FechaModifica { get; set; }

        public virtual Colaborador Colaborador { get; set; } = null!;

        public virtual Sucursal Sucursal { get; set; } = null!;
    }
}