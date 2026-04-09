namespace FSTransportesAPI.Common
{
    public static class Mensajes
    {
        // ==========================================
        // 1. MENSAJES DE ÉXITO
        // ==========================================
        public const string REGISTRO_EXITOSO = "Registro guardado exitosamente.";
        public const string ACTUALIZACION_EXITOSA = "Registro actualizado exitosamente.";
        public const string ELIMINACION_EXITOSA = "Registro eliminado exitosamente.";

        // ==========================================
        // 2. ERRORES DE AUTENTICACIÓN Y USUARIOS
        // ==========================================
        public const string ERROR_CREDENCIALES_INVALIDAS = "Usuario o contraseña incorrectos.";
        public const string ERROR_USUARIO_INACTIVO = "El usuario se encuentra inactivo.";
        public const string ERROR_ROL_NO_AUTORIZADO = "El usuario no tiene los permisos necesarios. Se requiere rol de Gerente de tienda.";
        public const string ERROR_USUARIO_NO_ENCONTRADO = "El usuario especificado no existe.";

        // ==========================================
        // 3. ERRORES DE NEGOCIO: VIAJES
        // ==========================================
        public const string ERROR_LIMITE_KILOMETRAJE_VIAJE = "El total de distancia acumulada para este viaje excede el límite permitido de 100 kilómetros.";
        public const string ERROR_COLABORADOR_YA_VIAJO_HOY = "Uno o más colaboradores ya tienen un viaje registrado en esta fecha.";
        public const string ERROR_VIAJE_SIN_DETALLES = "El viaje debe contener al menos un colaborador (detalle) asignado.";
        public const string ERROR_VIAJE_FECHA_INVALIDA = "La fecha del viaje no puede ser menor a la fecha actual.";
        public const string ERROR_VIAJE_NO_ENCONTRADO = "El viaje especificado no existe.";
        public const string ERROR_DISTANCIA_MINIMA = "La distancia total del viaje debe ser mayor a 0 km.";
        public const string ERROR_TRANSPORTISTA_NOMBRE_DUPLICADO = "El nombre del transportista ya se encuentra registrado.";
        public const string ERROR_TRANSPORTISTA_TARIFA_INVALIDA = "La tarifa por kilómetro debe ser mayor a cero.";

       // ==========================================
        // 4. ERRORES DE NEGOCIO: COLABORADORES Y SUCURSALES
        // ==========================================
        public const string ERROR_DISTANCIA_SUCURSAL_EXCEDIDA = "La distancia entre el colaborador y la sucursal no puede ser mayor a 50 kilómetros.";
        public const string ERROR_DISTANCIA_CERO = "La distancia debe ser mayor a cero.";
        public const string ASIGNACION_DUPLICADA = "El colaborador ya está asignado a esta sucursal.";
        public const string ERROR_COLABORADOR_NO_ENCONTRADO = "No se pudo encontrar el colaborador ingresado.";
        public const string ERROR_SUCURSAL_NO_ENCONTRADA = "No se pudo encontrar la sucursal ingresada.";

        // ==========================================
        // 5. ERRORES DE NEGOCIO: TRANSPORTISTAS (Próxima Feature)
        // ==========================================
        public const string ERROR_TRANSPORTISTA_NO_ENCONTRADO = "No se pudo encontrar el transportista ingresado.";
        public const string ERROR_TRANSPORTISTA_INACTIVO = "El transportista seleccionado se encuentra inactivo y no puede realizar viajes.";

        // ==========================================
        // 6. ERRORES GENERALES DEL SISTEMA
        // ==========================================
        public const string ERROR_INESPERADO = "Ocurrió un error inesperado. Contacte a soporte técnico.";
        public const string ERROR_CAMPOS_REQUERIDOS = "Faltan campos obligatorios por completar.";
        public const string ERROR_REGISTRO_NO_ENCONTRADO = "El registro solicitado no existe en el sistema.";
    }
}