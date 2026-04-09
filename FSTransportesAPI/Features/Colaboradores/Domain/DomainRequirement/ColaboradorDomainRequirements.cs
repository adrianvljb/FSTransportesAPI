using FSTransportesAPI.Common;

namespace FSTransportesAPI.Features.Colaboradores.Domain.DomainRequirements
{
    public class ColaboradorDomainRequirements
    {
        public bool ColaboradorExiste { get; set; }
        public bool SucursalExiste { get; set; }
        public bool YaEstaAsignado { get; set; }
        public decimal Distancia { get; set; }

        public static ColaboradorDomainRequirements Fill(
            bool existeColaborador,
            bool existeSucursal,
            bool yaAsignado,
            decimal distancia)
        {
            return new ColaboradorDomainRequirements
            {
                ColaboradorExiste = existeColaborador,
                SucursalExiste = existeSucursal,
                YaEstaAsignado = yaAsignado,
                Distancia = distancia
            };
        }

        public bool EsValido() => ObtenerErrores().Count == 0;

        public List<string> ObtenerErrores()
        {
            List<string> errores = new List<string>();

            if (!ColaboradorExiste)
                errores.Add(Mensajes.ERROR_COLABORADOR_NO_ENCONTRADO);

            if (!SucursalExiste)
                errores.Add(Mensajes.ERROR_SUCURSAL_NO_ENCONTRADA);

            if (YaEstaAsignado)
                errores.Add(Mensajes.ASIGNACION_DUPLICADA);

            if (Distancia > 50)
                errores.Add(Mensajes.ERROR_DISTANCIA_SUCURSAL_EXCEDIDA);

            if (Distancia <= 0)
                errores.Add(Mensajes.ERROR_DISTANCIA_CERO);

            return errores;
        }
    }
}