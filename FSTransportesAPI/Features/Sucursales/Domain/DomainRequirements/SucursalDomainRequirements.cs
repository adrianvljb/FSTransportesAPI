namespace FSTransportesAPI.Features.Sucursales.Domain.DomainRequirements
{
    public class SucursalDomainRequirements
    {
        public bool NombreValido { get; set; }
        public bool UbicacionValida { get; set; } // Nueva validación
        public bool NombreDuplicado { get; set; }

        public static SucursalDomainRequirements Fill(string nombre, string ubicacion, bool existeNombre)
        {
            return new SucursalDomainRequirements
            {
                NombreValido = !string.IsNullOrWhiteSpace(nombre),
                UbicacionValida = !string.IsNullOrWhiteSpace(ubicacion),
                NombreDuplicado = existeNombre
            };
        }

        public bool EsValido() => ObtenerErrores().Count == 0;

        public List<string> ObtenerErrores()
        {
            List<string> errores = new List<string>();

            if (!NombreValido)
                errores.Add("El nombre de la sucursal es requerido.");

            if (!UbicacionValida)
                errores.Add("La ubicación de la sucursal es requerida.");

            if (NombreDuplicado)
                errores.Add("Ya existe una sucursal con este nombre.");

            return errores;
        }
    }
}