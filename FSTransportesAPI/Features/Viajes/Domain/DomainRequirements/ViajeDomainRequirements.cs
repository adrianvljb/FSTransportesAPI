using FSTransportesAPI.Common;

namespace FSTransportesAPI.Features.Viajes.Domain.DomainRequirements
{
    public class ViajeDomainRequirements
    {
        // 1. Extraemos el número mágico a una constante
        private const decimal LIMITE_DISTANCIA_KILOMETROS = 100m;

        public bool UsuarioExiste { get; set; }
        public bool UsuarioActivo { get; set; }
        public bool EsGerente { get; set; }
        public decimal DistanciaTotal { get; set; }

        public static ViajeDomainRequirements Fill(
            bool existeUsuario,
            bool usuarioActivo,
            bool esGerente,
            decimal distanciaTotal)
        {
            return new ViajeDomainRequirements
            {
                UsuarioExiste = existeUsuario,
                UsuarioActivo = usuarioActivo,
                EsGerente = esGerente,
                DistanciaTotal = distanciaTotal
            };
        }

        public bool EsValido()
        {
            // 2. Usamos la constante aquí
            return UsuarioExiste && UsuarioActivo && EsGerente && DistanciaTotal <= LIMITE_DISTANCIA_KILOMETROS;
        }

        public List<string> ObtenerErrores()
        {
            List<string> errores = new List<string>();

            if (!UsuarioExiste)
                errores.Add(Mensajes.ERROR_USUARIO_NO_ENCONTRADO);

            if (UsuarioExiste && !UsuarioActivo)
                errores.Add(Mensajes.ERROR_USUARIO_INACTIVO);

            if (UsuarioExiste && !EsGerente)
                errores.Add(Mensajes.ERROR_ROL_NO_AUTORIZADO);

            // 3. Usamos la constante aquí
            if (DistanciaTotal > LIMITE_DISTANCIA_KILOMETROS)
                errores.Add(Mensajes.ERROR_LIMITE_KILOMETRAJE_VIAJE);

            return errores;
        }
    }
}