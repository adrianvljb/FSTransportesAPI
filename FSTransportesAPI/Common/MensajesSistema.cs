namespace FSTransportesAPI.Common
{
    public static class MensajesSistema
    {
        // Títulos de Error HTTP
        public const string TITULO_BAD_REQUEST = "Solicitud Incorrecta";
        public const string TITULO_NOT_FOUND = "Recurso No Encontrado";
        public const string TITULO_UNAUTHORIZED = "No Autorizado";
        public const string TITULO_CONFLICTO = "Conflicto de Datos";
        public const string TITULO_ERROR_INTERNO = "Error Interno del Servidor";

        // Detalles Seguros para el Cliente (Sin exponer la Base de Datos)
        public const string DETALLE_BAD_REQUEST = "Los datos enviados no tienen el formato correcto o están incompletos.";
        public const string DETALLE_NOT_FOUND = "El recurso que intenta consultar o modificar no existe en el sistema.";
        public const string DETALLE_UNAUTHORIZED = "No tiene los permisos o credenciales necesarias para realizar esta acción.";
        public const string DETALLE_CONFLICTO_BD = "No se pudo procesar la solicitud debido a una restricción en la base de datos (Ej. registro duplicado o información en uso).";
        public const string DETALLE_ERROR_INTERNO = "Ocurrió un error inesperado. Nuestro equipo técnico ha registrado el incidente para solucionarlo.";
    }
}