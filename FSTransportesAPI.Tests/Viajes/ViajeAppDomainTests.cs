using Xunit;
using FSTransportesAPI.Features.Viajes.Domain.DomainService;
using FSTransportesAPI.Features.Viajes.Domain.DomainRequirements;
using FSTransportesAPI.Common;

namespace FSTransportesAPI.Tests.Viajes
{
    public class ViajeAppDomainTests
    {
        private readonly ViajeAppDomain _domain;

        public ViajeAppDomainTests() => _domain = new ViajeAppDomain();

        [Fact]
        public void ValidarRegistroViaje_DebeRetornarError_SiUsuarioNoEsGerente()
        {
            // Arrange
            var req = ViajeDomainRequirements.Fill(
                existeUsuario: true,
                usuarioActivo: true,
                esGerente: false, // <--- No es gerente
                distanciaTotal: 50
            );

            // Act
            var resultado = _domain.ValidarRegistroViaje(req);

            // Assert
            Assert.Equal(Mensajes.ERROR_ROL_NO_AUTORIZADO, resultado);
        }

        [Fact]
        public void ValidarRegistroViaje_DebeRetornarVacio_SiTodoEsCorrecto()
        {
            // Arrange
            var req = ViajeDomainRequirements.Fill(true, true, true, 50);

            // Act
            var resultado = _domain.ValidarRegistroViaje(req);

            // Assert
            Assert.True(string.IsNullOrEmpty(resultado));
        }
    }
}