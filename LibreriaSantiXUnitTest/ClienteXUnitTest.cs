using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LibreriaSanti
{
    public class ClienteXUnitTest
    {
        private Cliente cliente;

        public ClienteXUnitTest()
        {
            cliente = new Cliente();
        }

        [Fact]
        public void CrearNombreCompleto_InputNombreApellido_ReturnNombreCompleto()
        {
            /* Arrange */

            /* Act */

            cliente.CrearNombreCompleto("Santiago", "Gonzalez");

            /* Assert */
            Assert.Equal("Santiago Gonzalez", cliente.ClienteNombre);
            
            /* Evaluar si cierto texto existe sobre la cadena total */
            Assert.Contains("Gonzalez",cliente.ClienteNombre);
            
            /* Ignorar Mayusculas Minusculas */
            Assert.StartsWith("Santiago",cliente.ClienteNombre);
            
            /* Con que texto empieza la cadena */
            Assert.EndsWith("Gonzalez",cliente.ClienteNombre);
        }

        /* Evalua propiedad ClientNombre */
        [Fact]
        public void ClientNombre_NoValues_ReturnsNull()
        {
            /* Arrange */
            Assert.Null(cliente.ClienteNombre);
        }


        [Fact]
        public void DescuentoEvaluacion_DefaultCliente_ReturnsDescuentoIntervalo()
        {
            int descuento = cliente.Descuento;

            /* Intervalo numerico */
            Assert.InRange(descuento,5,24);
        }

        [Fact]
        public void CrearNombreCompleto_InputNombre_ReturnsNotNull()
        {
            cliente.CrearNombreCompleto("Santiago", "");
            Assert.NotNull(cliente.ClienteNombre);
            Assert.False(string.IsNullOrEmpty(cliente.ClienteNombre));

        }

        /* Captura de excepcion */
        [Fact]
        public void ClienteNombre_InputNombreEnBlanco_ThrowExcepcion()
        {
            var excepcionDetalle = Assert.Throws<ArgumentException>(() => cliente.CrearNombreCompleto("", "Gonzalez"));
            Assert.Equal("El nombre está en blanco", excepcionDetalle.Message);

            /* comparar el objeto excepcion (no el mensaje) */
            Assert.Throws<ArgumentException>(() => cliente.CrearNombreCompleto("", "Gonzalez"));

        }


        [Fact]
        public void GetClienteDetalle_CrearClienteConMenosDe500TotalOrder_ReturnsClienteBasico()
        {
            cliente.OrdenTotal = 150;
            var resultado = cliente.GetClienteDetalle();
            Assert.IsType<ClienteBasico>(resultado);
        }

        [Fact]
        public void GetClienteDetalle_CrearClienteConMasDe500TotalOrder_ReturnsClientePremium()
        {
            cliente.OrdenTotal = 700;
            var resultado = cliente.GetClienteDetalle();
            Assert.IsType<ClientePremium>(resultado);

        }
    }
}
