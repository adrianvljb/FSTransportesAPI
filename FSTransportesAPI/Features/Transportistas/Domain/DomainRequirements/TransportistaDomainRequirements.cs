namespace FSTransportesAPI.Features.Transportistas.Domain.DomainRequirements
{
    public class TransportistaDomainRequirements
    {
        public bool NombreYaExiste { get; set; }
        public decimal TarifaPorKilometro { get; set; }

        public static TransportistaDomainRequirements Fill(bool nombreYaExiste, decimal tarifaPorKilometro)
        {
            return new TransportistaDomainRequirements
            {
                NombreYaExiste = nombreYaExiste,
                TarifaPorKilometro = tarifaPorKilometro
            };
        }
    }
}