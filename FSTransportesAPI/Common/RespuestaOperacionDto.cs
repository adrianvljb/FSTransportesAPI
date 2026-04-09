namespace FSTransportesAPI.Common
{
    public class RespuestaOperacionDto
    {
        public bool Exito { get; set; }
        public string Mensaje { get; set; } = string.Empty;
        
        
        public object? Datos { get; set; } 

        // Métodos de ayuda para que sea más fácil instanciar
        public static RespuestaOperacionDto Ok(string mensaje, object? datos = null)
        {
            return new RespuestaOperacionDto { Exito = true, Mensaje = mensaje, Datos = datos };
        }

        public static RespuestaOperacionDto Fallo(string mensaje)
        {
            return new RespuestaOperacionDto { Exito = false, Mensaje = mensaje };
        }
    }
}